using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;                 // For HttpCookie, Request, Response
using System.Web.Security;        // For FormsAuthentication, FormsAuthenticationTicket

namespace shoppingcartappusingasp
{
    public partial class Products : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the authentication cookie exists
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName]; // .ASPXAUTH

            if (authCookie == null)
            {
                // No cookie → user not logged in, redirect to login page
                Response.Redirect("~/Account/Login.aspx");
                return;
            }
            if (!IsPostBack)
            {
                BindProducts();

                // ✅ Initialize cart once
                if (Session["Cart"] == null)
                {
                    DataTable cart = new DataTable();
                    cart.Columns.Add("ProductID", typeof(int));
                    cart.Columns.Add("ProductName", typeof(string));
                    cart.Columns.Add("Quantity", typeof(int));
                    cart.Columns.Add("Price", typeof(decimal));
                    cart.Columns.Add("Total", typeof(decimal));
                    Session["Cart"] = cart;
                }
            }
        }

        private void BindProducts()
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                using (SqlConnection con = new SqlConnection(connStr))
                {
                    con.Open();
                    string query = "SELECT ID, Name, Price FROM Products ORDER BY ID";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        ProductList.DataSource = dt;
                        ProductList.DataBind();
                        Session["Products"] = dt;
                    }
                    else
                    {
                        ProductList.DataSource = null;
                        ProductList.DataBind();
                        lblMessage.Text = "No products available.";
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error loading products: " + ex.Message;
            }
        }

        protected void ProductList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            // ✅ Restore quantity from cookie
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                int productId = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "ID"));
                Label qtyLabel = (Label)e.Item.FindControl("QtyLabel");
                HttpCookie cookie = Request.Cookies["Product_" + productId];
                if (cookie != null && !string.IsNullOrEmpty(cookie.Value))
                {
                    qtyLabel.Text = cookie.Value;
                }
                else
                {
                    qtyLabel.Text = "0";
                }

                Button removeBtn = (Button)e.Item.FindControl("RemoveBtn");
                if (removeBtn != null)
                    removeBtn.Enabled = qtyLabel.Text != "0";
            }
        }

        protected void ProductList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int productId = Convert.ToInt32(e.CommandArgument);
            DataTable products = (DataTable)Session["Products"];
            DataTable cart = (DataTable)Session["Cart"];

            DataRow[] selected = products.Select("ID = " + productId);
            if (selected.Length == 0) return;
            DataRow product = selected[0];

            Label qtyLabel = (Label)e.Item.FindControl("QtyLabel");
            int currentQty = 0;

            DataRow[] existing = cart.Select("ProductID = " + productId);
            if (existing.Length > 0)
                currentQty = Convert.ToInt32(existing[0]["Quantity"]);

            if (e.CommandName == "AddToCart")
            {
                if (existing.Length > 0)
                {
                    currentQty++;
                    existing[0]["Quantity"] = currentQty;
                    existing[0]["Total"] = currentQty * Convert.ToDecimal(existing[0]["Price"]);
                }
                else
                {
                    currentQty = 1;
                    cart.Rows.Add(product["ID"], product["Name"], currentQty, product["Price"], currentQty * Convert.ToDecimal(product["Price"]));
                }

                lblMessage.Text = string.Format("{0} item(s) in cart!", currentQty);
            }
            else if (e.CommandName == "RemoveFromCart")
            {
                if (existing.Length > 0)
                {
                    currentQty--;
                    if (currentQty <= 0)
                    {
                        cart.Rows.Remove(existing[0]);
                        currentQty = 0;
                    }
                    else
                    {
                        existing[0]["Quantity"] = currentQty;
                        existing[0]["Total"] = currentQty * Convert.ToDecimal(existing[0]["Price"]);
                    }

                    lblMessage.Text = string.Format("{0} updated to {1} item(s).", product["Name"], currentQty);
                }
            }

            // ✅ Update label and remove button state
            qtyLabel.Text = currentQty.ToString();
            Button removeBtn = (Button)e.Item.FindControl("RemoveBtn");
            if (removeBtn != null)
                removeBtn.Enabled = currentQty > 0;

            // ✅ Update Session Cart
            Session["Cart"] = cart;

            // ✅ Save quantity in cookie
            HttpCookie cookie = new HttpCookie("Product_" + productId, currentQty.ToString());
            cookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(cookie);
        }
    }
}

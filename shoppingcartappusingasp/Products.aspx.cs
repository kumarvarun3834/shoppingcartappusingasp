using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace shoppingcartappusingasp
{
    public partial class Products : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
                string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

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

                        // Save to session for cart reference
                        Session["Products"] = dt;
                    }
                    else
                    {
                        // If no products, show placeholder
                        ProductList.DataSource = null;
                        ProductList.DataBind();

                        // Optional: show a message if you have a Label control like lblMessage
                        lblMessage.Text = "No products available.";
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any SQL or config errors gracefully
                lblMessage.Text = "Error loading products: " + ex.Message;
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

            qtyLabel.Text = currentQty.ToString();

            Button removeBtn = (Button)e.Item.FindControl("RemoveBtn");
            if (removeBtn != null)
                removeBtn.Enabled = currentQty > 0;

            Session["Cart"] = cart;
        }
    }
}

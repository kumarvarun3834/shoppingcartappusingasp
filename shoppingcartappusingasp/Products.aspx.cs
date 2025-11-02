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
            if (e.CommandName == "AddToCart")
            {
                int productId = Convert.ToInt32(e.CommandArgument);
                DataTable products = (DataTable)Session["Products"];
                DataRow[] selected = products.Select("ID = " + productId);

                if (selected.Length > 0)
                {
                    DataRow p = selected[0];
                    DataTable cart = (DataTable)Session["Cart"];

                    // ✅ Check if item already exists in cart
                    DataRow[] existing = cart.Select("ProductID = " + productId);
                    if (existing.Length > 0)
                    {
                        existing[0]["Quantity"] = (int)existing[0]["Quantity"] + 1;
                        existing[0]["Total"] = Convert.ToInt32(existing[0]["Quantity"]) * Convert.ToDecimal(existing[0]["Price"]);

                    }
                    else
                    {
                        cart.Rows.Add(p["ID"], p["Name"], 1, p["Price"], p["Price"]);
                    }

                    Session["Cart"] = cart;
                    lblMessage.Text =  "added to cart!";
                }
            }
        }
    }
}

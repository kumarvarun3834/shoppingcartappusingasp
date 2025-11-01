using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Price", typeof(decimal));

            dt.Rows.Add(1, "Wireless Mouse", 599.00m);
            dt.Rows.Add(2, "USB Keyboard", 799.00m);
            dt.Rows.Add(3, "Headphones", 999.00m);
            dt.Rows.Add(4, "Webcam", 1299.00m);

            ProductList.DataSource = dt;
            ProductList.DataBind();

            Session["Products"] = dt;
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

using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace shoppingcartappusingasp
{
    public partial class Cart : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCartData();
            }
        }

        private void BindCartData()
        {
            // Check if cart exists in session
            if (Session["Cart"] != null)
            {
                DataTable dt = (DataTable)Session["Cart"];
                GridView1.DataSource = dt;
                GridView1.DataBind();

                // Calculate total
                decimal grandTotal = 0;
                foreach (DataRow row in dt.Rows)
                {
                    grandTotal += Convert.ToDecimal(row["Total"]);
                }

                //lblTotal.Text = "Grand Total: ₹" + grandTotal.ToString("N2");
            }
            else
            {
                //lblTotal.Text = "Your cart is empty!";
            }
        }
    }
}

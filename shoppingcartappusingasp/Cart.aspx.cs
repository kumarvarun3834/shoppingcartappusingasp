using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web;                 // For HttpCookie, Request, Response
using System.Web.Security;        // For FormsAuthentication, FormsAuthenticationTicket

namespace shoppingcartappusingasp
{
    public partial class Cart : Page
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

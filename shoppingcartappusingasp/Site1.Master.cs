using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace shoppingcartappusingasp
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName]; // .ASPXAUTH

            if (authCookie != null)
            {
                FormsAuthenticationTicket ticket =
                    FormsAuthentication.Decrypt(authCookie.Value);

                if (ticket != null && !ticket.Expired)
                {
                    lblUser.Text = "Hello, " + ticket.Name;
                    UserPanel.Visible = true;
                    GuestPanel.Visible = false;
                    return;
                }
            }

            // Not logged in
            UserPanel.Visible = false;
            GuestPanel.Visible = true;
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            // Sign out from Forms Authentication
            FormsAuthentication.SignOut();
            Session["Cart"] = null;
            // Clear session (cart, temp data, etc.)
            Session.Clear();
            Session.Abandon();

            // Redirect to login page
            Response.Redirect("~/Account/Login.aspx");
        }
    }
}

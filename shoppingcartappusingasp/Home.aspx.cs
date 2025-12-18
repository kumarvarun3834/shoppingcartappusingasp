using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;        // For FormsAuthentication, FormsAuthenticationTicket

namespace shoppingcartappusingasp
{
    public partial class Home : System.Web.UI.Page
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
        }
    }
}
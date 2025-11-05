using System;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace shoppingcartappusingasp
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // If user is already logged in, redirect to Home
            if (Session["User"] != null)
            {
                Response.Redirect("~/Home.aspx");
            }

            // Attach event handler dynamically
            Login1.Authenticate += new AuthenticateEventHandler(Login1_Authenticate);
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string username = Login1.UserName.Trim();
            string password = Login1.Password.Trim();

            if (Membership.ValidateUser(username, password))
            {
                e.Authenticated = true;

                // ✅ Store user info in session
                Session["User"] = username;
                Session["UserRole"] = Roles.GetRolesForUser(username).FirstOrDefault() ?? "user";
                Session.Timeout = 30; // 30 min session timeout

                // ✅ Redirect user manually (DestinationPageUrl is ignored if you redirect)
                FormsAuthentication.RedirectFromLoginPage(username, false);
            }
            else
            {
                e.Authenticated = false;
            }
        }
    }
}

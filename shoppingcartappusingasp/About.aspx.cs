using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace shoppingcartappusingasp
{
    public partial class About : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // ✅ Check for login
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }
        }
    }
}

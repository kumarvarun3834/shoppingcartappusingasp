using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace shoppingcartappusingasp
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] != null)
                {
                    lblUser.Text = "Hello, " + Session["User"].ToString();
                    UserPanel.Visible = true;
                    GuestPanel.Visible = false;
                }
                else
                {
                    UserPanel.Visible = false;
                    GuestPanel.Visible = true;
                }
            }
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session["User"] = null;
            Session["Cart"] = null;
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Login.aspx");
        }
    }
}

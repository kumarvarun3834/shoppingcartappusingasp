using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace shoppingcartappusingasp
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Cart"] != null)
                {
                    GridView1.DataSource = (DataTable)Session["Cart"];
                    GridView1.DataBind();
                }
                else
                {
                    EmptyCartLabel.Visible = true;
                }
            }
        }
    }
}
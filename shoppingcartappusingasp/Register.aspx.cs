using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;


namespace shoppingcartappusingasp
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
        {
            var user = Membership.GetUser(CreateUserWizard1.UserName);
            String role = ((RadioButtonList)CreateUserWizard1.FindControl("RoleList")).SelectedValue;

            //if (!Roles.RoleExists(role))
             //   Roles.CreateRole(role);

            Roles.AddUserToRole(user.UserName, role);
        }
    }
}
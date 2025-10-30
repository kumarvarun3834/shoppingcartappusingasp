using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace shoppingcartappusingasp
{
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProductList.DataSource = new List<dynamic>
            {
                new { Name = "Laptop", Price = 55000 },
                new { Name = "Headphones", Price = 2000 },
                new { Name = "Mouse", Price = 500 }
            };
                ProductList.DataBind();
            }
        }
    }

}


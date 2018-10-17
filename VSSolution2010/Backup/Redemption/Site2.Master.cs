using System
;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Redemption
{
    public partial class Site2Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                {
                   
                  
                    SignupLi.Visible = false;
                }
                else 
                {
                  
                    SignupLi.Visible = true;
                }
            }
        }

   
    }
}

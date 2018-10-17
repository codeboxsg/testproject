using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace RedemptionAdmin.Admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Hashtable aReplaceValues = new Hashtable();
            //EmailManager.SendClaimPointApprovalMail("edwintkh@gmail.com", "edwin", aReplaceValues,"");
            //EmailManager.SendClaimPointApprovalMail("edwintkh@gmail.com", "edwin", aReplaceValues, "");

          //  EmailManager.LoadClientEmailValues();
            EmailManager.LoadClientEmailValues(this.Response);
        }
    }
}
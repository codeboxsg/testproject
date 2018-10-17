using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RedemptionData;
namespace Redemption
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TestMemberBut_Click(object sender, EventArgs e)
        {
            ClientManager.insertRedemptionMember(Guid.NewGuid(),
                "firstname", "lastmame",
                "s79247683",
                false, DateTime.Now, "2 surin road", "+6596899920", "535520");
            ClientManager.updateRedemptionMember(new Guid("463809e3-9f33-4bd0-bf72-301bd2699e41"),
               "firstname2", "lastmame2",
               "s789247683",
               true, DateTime.Now, "2 surin road2", "+7596899920", "735520");
            ClientManager.deleteRedemptionMember(new Guid("f3691563-43d2-4ba0-9177-2a31199e68b6"));


            ClientManager.insertRedemptionChild(new Guid("463809e3-9f33-4bd0-bf72-301bd2699e41"),
               "firstname", "lastmame",
              
               false, DateTime.Now);
            ClientManager.updateRedemptionChild(1, Guid.NewGuid(),
            "firstname2", "lastmame2",

            false, DateTime.Now);
            ClientManager.deleteRedemptionChild(1);

        }

    }
}
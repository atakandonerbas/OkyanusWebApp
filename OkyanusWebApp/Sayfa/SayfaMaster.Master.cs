using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OkyanusWebApp.Sayfa
{
    public partial class SayfaMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uye"] != null)
            {
                Uye uye = (Uye)Session["uye"];
            }
        }

        protected void lbtn_uye_cikis_Click(object sender, EventArgs e)
        {
            Session["uye"] = null;
            Response.Redirect("UyeGiris.aspx");
        }
    }
}
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
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uye"] != null)
            {
                Uye uye = (Uye)Session["uye"];
            }

            Sirala();
        }

        protected void lbtn_uye_cikis_Click(object sender, EventArgs e)
        {
            Session["uye"] = null;
            Response.Redirect("UyeGiris.aspx");
        }
        private void Sirala()
        {
            rp_kategoriler.DataSource = dm.KategoriListele();
            rp_kategoriler.DataBind();
        }
    }
}
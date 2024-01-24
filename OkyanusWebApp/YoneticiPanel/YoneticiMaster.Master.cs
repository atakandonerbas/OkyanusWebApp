using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OkyanusWebApp.YoneticiPanel
{
    public partial class YoneticiMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["yonetici"] != null) 
            {
                Yonetici yon = (Yonetici)Session["yonetici"];//Burada unboxing yapıyoruz.
                lbtn_kullanici.Text = yon.KullaniciAdi;
            }
            else
            {
                Response.Redirect("YoneticiGiris.aspx");
            }
        }
        protected void lbtn_cikis_Click(object sender, EventArgs e)
        {
            Session["yonetici"] = null;
            Response.Redirect("YoneticiGiris.aspx");
        }
    }
}
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OkyanusWebApp.YoneticiPanel
{
    public partial class YoneticiGiris : System.Web.UI.Page
    {
        DataModel dm = new DataModel();

        protected void btn_giris_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_kullaniciAdi.Text) && !string.IsNullOrEmpty(tb_sifre.Text))
            {
                Yonetici yonetici = dm.YoneticiGiris(tb_kullaniciAdi.Text, tb_sifre.Text);
                if (yonetici != null)
                {
                    Session["yonetici"] = yonetici;
                    Response.Redirect("Anasayfa.aspx");
                }
                else
                {
                    pnl_hata.Visible = true;
                    lbl_mesaj.Text = "Kullanıcı adı veya şifre yanlış!";
                }
            }
            else
            {
                pnl_hata.Visible = true;
                lbl_mesaj.Text = "Sen hiç hayatında kullanıcı adı ve şifre girmeden giriş yapan admin gördün mü?";
            }
        }
    }
}
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OkyanusWebApp.Sayfa
{
    public partial class UyeGiris : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void btn_giris_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_kullaniciAdi.Text) && !string.IsNullOrEmpty(tb_sifre.Text))
            {
                Uye uye = dm.UyeGiris(tb_kullaniciAdi.Text, tb_sifre.Text);
                if (uye != null)
                {
                    Session["uye"] = uye;
                    Response.Redirect("HomePage.aspx");
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
                lbl_mesaj.Text = "Sen hiç hayatında kullanıcı adı ve şifre girmeden giriş yapan üye gördün mü?";
            }
        }
    }
}
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OkyanusWebApp.YoneticiPanel
{
    public partial class KategoriEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void lbtn_kaydet_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_isim.Text))
            {
                Kategori k = new Kategori();
                k.Isim = tb_isim.Text;
                if (dm.KategoriEkle(k))
                {
                    pnl_basarili.Visible = true;
                    pnl_hata.Visible = false;
                }
                else
                {
                    lbl_mesaj.Text = "Kategori eklerken bir hata oluştu.";
                    pnl_basarili.Visible = false;
                    pnl_hata.Visible = true;
                }
            }
            else
            {
                lbl_mesaj.Text = "Kategori adı boş bırakılamaz.";
                pnl_basarili.Visible = false;
                pnl_hata.Visible = true;
                
            }
        }
    }
}
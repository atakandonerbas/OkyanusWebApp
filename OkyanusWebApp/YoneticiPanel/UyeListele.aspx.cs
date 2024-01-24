using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OkyanusWebApp.YoneticiPanel
{
    public partial class UyeListele : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            Sirala();
        }

        protected void lv_uyeler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if(e.CommandName == "ban")
            {
                dm.UyeBanla(id);
            }
        }

        private void Sirala()
        {
            lv_uyeler.DataSource = dm.UyeListele();
            lv_uyeler.DataBind();
        }
    }

    
}
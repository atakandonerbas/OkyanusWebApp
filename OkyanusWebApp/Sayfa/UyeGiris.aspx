<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UyeGiris.aspx.cs" Inherits="OkyanusWebApp.Sayfa.UyeGiris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Üye Girişi</title>
    <link href="css/UyeGirisStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
     <div class="girisPanel">
         <div class="ust">
             <img src="SayfaResimleri/okyanus_logo.png" />
         </div>
         <div class="alt">
             <div class="satir">
                 <asp:Panel ID="pnl_hata" runat="server" CssClass="hataPanel" Visible="false">
                     <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
                 </asp:Panel>
             </div>
             <div class="satir">
                 <h2>Üye Giriş</h2>
             </div>
             <div class="satir">
                 <label>Kullanıcı Adı:</label><br />
                 <asp:TextBox ID="tb_kullaniciAdi" runat="server" CssClass="metinKutu" placeholder="Bize kullanıcı adınızı bahşeder misiniz?"></asp:TextBox>
             </div>
             <div class="satir">
                 <label>Şifre:</label><br />
                 <asp:TextBox ID="tb_sifre" runat="server" CssClass="metinKutu" placeholder="Yalvarırım şifrenizi buraya giriniz!" TextMode="Password"></asp:TextBox>
             </div>
             <div class="satir">
             <asp:Button ID="btn_giris" runat="server" OnClick="btn_giris_Click" Text="Giriş Yap" CssClass="girisButon" />
             </div>
         </div>
         <div style="clear: both"></div>
     </div>
 </form>
</body>
</html>

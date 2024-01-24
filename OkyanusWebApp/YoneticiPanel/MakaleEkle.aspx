<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPanel/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="MakaleEkle.aspx.cs" Inherits="OkyanusWebApp.YoneticiPanel.MakaleEkle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Plugins/ckeditor/ckeditor.js" ></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formTasiyici">
        <div class="formBaslik">
            <h3>Makale Ekle</h3>
        </div>
        <asp:Panel ID="pnl_hata" runat="server" CssClass="hataPanel" Visible="false">
            <asp:Label ID="lbl_mesaj" runat="server" ></asp:Label>
        </asp:Panel>
        <asp:Panel ID="pnl_basarili" runat="server" CssClass="basariliPanel" Visible="false">
            Makale başarılı bir şekilde eklendi.
        </asp:Panel>
        <div class="makaleUst">
            <div class="satir">
                <label>Makale</label> <br />
                <asp:TextBox runat="server" ID="tb_makale" TextMode="MultiLine" CssClass="metinKutu" ></asp:TextBox>
                <script>
                    CKEDITOR.replace('ContentPlaceHolder1_tb_makale');
                </script>
            </div>
        </div>
        <div class="makaleAlt">
            <div class="satir">
                <label>Başlık</label><br />
                <asp:TextBox ID="tb_baslik" runat="server" CssClass="metinKutu"></asp:TextBox>
            </div>
            <div class="satir satirbosluk">
                <label>Kategori</label>
                <asp:DropDownList ID="ddl_kategoriler" runat="server" CssClass="metinKutu" DataTextField="Isim" DataValueField="ID" ></asp:DropDownList>
            </div>
            <div class="satir satirbosluk">
                <label>Makale Resmi Ekleyiniz</label>
                <asp:FileUpload ID="fu_resim" runat="server" CssClass="metinKutu" />
            </div>
            <div class="satir satirbosluk">
                <label>Makale Özeti</label>
                <asp:TextBox ID="tb_ozet" runat="server" CssClass="metinKutu" TextMode="MultiLine"></asp:TextBox>
            </div>
            <div class="satir satirbosluk">
                <label>Aktiflik</label>
                <asp:CheckBox ID="cb_aktiflik" runat="server" TextAlign="Left" />
            </div>
        </div>
    </div>
</asp:Content>

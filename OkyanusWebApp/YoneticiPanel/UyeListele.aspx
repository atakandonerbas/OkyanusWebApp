<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPanel/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="UyeListele.aspx.cs" Inherits="OkyanusWebApp.YoneticiPanel.UyeListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/ListStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="listeContainer">
        <div class="listeBaslik">
            <h2>Üyeler</h2>
        </div>
        <div class="listeContent">
            <asp:ListView ID="lv_uyeler" runat="server" OnItemCommand="lv_uyeler_ItemCommand">
                <LayoutTemplate>
                    <table>
                        <tr>
                            <th>ID</th>
                            <th>İsim</th>
                            <th>Soyisim</th>
                            <th>Kullanıcı Adı</th>
                            <th>Mail</th>
                            <th>Kayıt Tarihi</th>
                            <th width=15% >Banla</th>
                        </tr>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("ID") %>  </td>
                        <td><%# Eval("Isim") %>  </td>
                        <td><%# Eval("Soyisim") %>  </td>
                        <td><%# Eval("Kullanıcı Adı") %>  </td>
                        <td><%# Eval("Mail") %>  </td>
                        <td><%# Eval("KayitTarihi") %>  </td>
                        <td>
                            <asp:LinkButton ID="lbtn_uyeban" runat="server" title="BANLANDIN EVLAT" CommandName="ban" CommandArgument='<%# Eval("ID") %>'><img src="SiteResimleri/ban-user.png" /></asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>

    </div>
</asp:Content>

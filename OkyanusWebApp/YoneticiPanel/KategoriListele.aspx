<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPanel/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="KategoriListele.aspx.cs" Inherits="OkyanusWebApp.YoneticiPanel.KategoriListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/ListStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="listeContainer">
        <div class="listeBaslik">
            <h2>Kategoriler</h2>
        </div>
        <div class="listeContent">
            <asp:ListView ID="lv_kategoriler" runat="server" OnItemCommand="lv_kategoriler_ItemCommand">
                <LayoutTemplate>
                    <table>
                        <tr>
                            <th>ID</th>
                            <th>İsim</th>
                            <th>Sil</th>
                        </tr>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("ID") %> </td>
                        <td><%# Eval("Isim") %> </td>
                        <td>
                            <asp:LinkButton ID="lbtn_kategorisil" runat="server" title="sil" CommandName="sil" CommandArgument='<%# Eval("ID") %>'><img src="SiteResimleri/delete.png" /></asp:LinkButton> 
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>

    </div>


</asp:Content>

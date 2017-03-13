<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="sitemap.aspx.cs" Inherits="KUCSPROJE.admin.sitemap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width:100%;height:auto;">
        <div style="height:60px; background-color:#808080; color:#fff; font-weight:bolder; text-align:left; border:3px double #000;" >
      <asp:Label ID="lbl_ekle" runat="server" ForeColor="White" Font-Size="28px" Text="SİTEMAP"></asp:Label></div>



        <div style="width:100%;height:auto;margin-left:30px;color:#fff;">
        <asp:TreeView ID="tv_sitemap" runat="server" DataSourceID="SiteMapDataSource1" ImageSet="Arrows">
            <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
            <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="White" HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
            <ParentNodeStyle Font-Bold="False" />
            <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" ForeColor="#5555DD" />
        </asp:TreeView>
        <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
            <div style="width:100%; height:20px"></div>
        <asp:Button ID="btn_sitemap" runat="server" Text="SİTE MAP GÜNCELLE" OnClick="btn_sitemap_Click" ForeColor="Black" />
            </div>
    </div>
</asp:Content>

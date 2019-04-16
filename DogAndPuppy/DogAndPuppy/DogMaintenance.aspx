<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DogMaintenance.aspx.cs" Inherits="DogAndPuppy.DogMaintenance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>

    </div>
    <asp:DropDownList ID="ddlDog" runat="server" OnSelectedIndexChanged="ddlDog_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
     &nbsp &nbsp
    <div id="dvButton" runat="server">
<asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />

    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
    </div>
    
    <br /><br /><br />
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
</asp:Content>

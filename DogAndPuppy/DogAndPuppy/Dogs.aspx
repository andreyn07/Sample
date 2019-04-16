<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dogs.aspx.cs" Inherits="DogAndPuppy.Dogs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<br />
    <div>
        <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
        &nbsp
        <asp:TextBox ID="txtName" runat="server" Width="300px"></asp:TextBox>
    </div>
    <br />
    <br />

<fieldset> 
    <legend><i><b> ---Address--- </b></i></legend>
    <table>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Address"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
            </td>
            <td>City
            </td>
            <td>
                <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:DropDownList ID="ddlState" runat="server" />
            </td>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Zip"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtZip" runat="server"></asp:TextBox>
            </td>
            <td>
                 <asp:DropDownList ID="ddlCountry" runat="server"/>
            </td>
        </tr>
    </table>

 </fieldset> 

    <br />
    <br />

    <fieldset> 
    <legend><i><b>--- Dog Info --- </b></i></legend>
    <table>
        <tr>
            <td>
                <asp:DropDownList ID="ddlSize" runat="server"/>
            </td>
            <td>
                 <asp:DropDownList ID="ddlColor" runat="server"/>
            </td>
            <td>
                   <asp:DropDownList ID="ddlGender" runat="server"/>
            </td>
           <td> 
               <asp:DropDownList ID="ddlBreed" runat="server"/>
                
            </td>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            </td>
          
        </tr>
    </table>

 </fieldset> 
   

    <br />
    <br />
   
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>

    
</asp:Content>

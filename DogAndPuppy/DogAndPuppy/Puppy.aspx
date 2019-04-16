<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Puppy.aspx.cs" Inherits="DogAndPuppy.Puppy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

 <div style="text-align: center; font-size: larger">
        <div>Please select the breed </div>
        <div>
            <asp:DropDownList ID="ddlBreed" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBreed_SelectedIndexChanged" />
        </div>
    </div>
    <div style="text-align: center; font-size: larger" id ="dvDogName" runat="server">
        <div>Please select the Dog Name </div>
        <div>
            <asp:DropDownList ID="ddlDog" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDog_SelectedIndexChanged" />
        </div>
    </div>

    <br />
  
    <asp:Panel ID="pnMain" runat="server">
        <div style="text-align:center">
            <asp:Label ID="Label1" runat="server" Text="Puppy Name"></asp:Label>
            &nbsp
        <asp:TextBox ID="txtName" runat="server" Width="300px"></asp:TextBox>
        </div>
        <div style="text-align:center">
            First Name &nbsp <asp:TextBox ID="txtFirstname" runat="server"></asp:TextBox>
        </div>
        &nbsp&nbsp
         <div style="text-align:center">
            Last Name &nbsp <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
        </div>
        <br />
        <br />

        <fieldset>
            <legend><i><b>---Address--- </b></i></legend>
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
                        <asp:DropDownList ID="ddlCountry" runat="server" />
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
                        <asp:DropDownList ID="ddlSize" runat="server" />
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlColor" runat="server" />
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlGender" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Price
                    </td>
                    <td>
                        <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Date of Birthday
                    </td>
                    <td>
                        <asp:TextBox ID="txtDOB" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                    </td>
                </tr>

            </table>

        </fieldset>
    </asp:Panel>
    <br /><br />
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>

</asp:Content>

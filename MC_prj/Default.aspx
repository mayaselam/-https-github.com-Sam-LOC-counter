<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <%--<p>Candidate: Selam Alemayehu</p>--%>
    </div>

    <div class="row">
        <div class="col-md-4">
            <asp:Label ID="Label3" runat="server" Text="Project Directory:"></asp:Label>
            <br />
            <asp:TextBox ID="txtDirectory" CssClass="form-control input-lg" name="GetAllFiles" runat="server" Width="1000px" Height="25px" TabIndex="1">C:\</asp:TextBox>

            <asp:CheckBox ID="cbSearchSubDiretories" runat="server" Checked="True" Text="&nbsp; Include Sub Diretories" Height="16px" Width="389px" />
            <br />
            <br />

            <asp:Button ID="btnCountNumLines" CssClass="btn btn-default" runat="server" OnClick="Button1_Click" Text="Count Lines" Width="189px" Height="40px" />

            <br />

            <hr style="width: 320%; color: darkgray; height: 2px; vertical-align: middle" />


            <div class="col-md-4">

                <asp:Label ID="lblfilecounted" runat="server" Text="Files Processed Count:" Style="display: block; float: left; width: 175px;"></asp:Label>
                <asp:TextBox ID="txtfilescounted" class="form-control" runat="server" Width="120px"></asp:TextBox>
                <br />
                <asp:Label ID="lblfilecount" runat="server" Text="Total Files With Code Count: " Style="display: block; float: left; width: 180px;"></asp:Label>
                <asp:TextBox ID="txtfilecount" class="form-control" runat="server" Width="120px"></asp:TextBox>
                <br />
                <asp:Label ID="lblcount" runat="server" Text="Line Count: "></asp:Label>
                <asp:TextBox ID="txtlinecount" class="form-control" runat="server" Width="106px"></asp:TextBox>
                <br />

                <p style="display: block; float: left; width: 250px; color: darkred; font-family: 'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif; font-size: large">Testing for none code line</p>

                <br />
                <asp:Label ID="lblComments" runat="server" Text="Comments:"></asp:Label>
                <asp:TextBox ID="txtcomments" class="form-control" runat="server" Width="106px"></asp:TextBox>
                <br />
                <asp:Label ID="lblblankspace" runat="server" Text="White Space:"></asp:Label>
                <asp:TextBox ID="txtempty" class="form-control" runat="server" Width="106px"></asp:TextBox>
                <br />
                <asp:Label ID="lblresult" runat="server" Text="Result: "></asp:Label>
                <asp:TextBox ID="txtresult" class="form-control" runat="server" Width="106px"></asp:TextBox>
                <br />
                <br />



            </div>
            <br />

        </div>

    </div>
</asp:Content>

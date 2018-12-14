<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewResults.aspx.cs" Inherits="WebApplication1.View.ViewResults" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class='form-group'>
        <br />
        <div class='form-group row border'>
            <h1>Listagem de Clientes e Produtos</h1>
        </div>
        <br />
            <asp:Label ID="lblResult" runat="server"></asp:Label>
        
    </div>
</asp:Content>

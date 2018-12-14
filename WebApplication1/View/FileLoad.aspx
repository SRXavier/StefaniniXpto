<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FileLoad.aspx.cs" Inherits="WebApplication1.View.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-group">
        <br />
        <div class='form-group row'>
            <h1>Importar Clientes e Produtos</h1>
        </div>
        <br />
        <label for="lblClientes">Selecione arquivo de clientes</label>
        <asp:FileUpload ID="fupReaderClients" runat="server" AllowMultiple="true" OnLoad="Page_Load" />

        <br />
        <br />
        
        <label for="lblProdutos">Selecione arquivo de produtos</label>
        <asp:FileUpload ID="fupReaderProducts" runat="server" AllowMultiple="true" OnLoad="Page_Load" />

        <br />
        <br />

        <asp:Button ID="btnLoadProducts" runat="server" class="btn btn-primary" Text="Importar" OnClick="btnLoadFiles_Click" />
    </div>
</asp:Content>

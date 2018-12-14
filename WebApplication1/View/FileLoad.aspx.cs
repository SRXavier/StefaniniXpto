using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using XPTOBusiness;
using XPTOModel;

namespace WebApplication1.View
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //File.ReadAllBytes();

        }


        protected void btnLoadFiles_Click(object sender, EventArgs e)
        {
            if(fupReaderClients.HasFile && fupReaderProducts.HasFile)
            {
                var clients = fupReaderClients.FileBytes;
                var products = fupReaderProducts.FileBytes;

                var stringClients = System.Text.Encoding.UTF8.GetString(clients);
                var stringProducts = System.Text.Encoding.UTF8.GetString(products);

                try
                {
                    XPTOBusiness.Client client = new XPTOBusiness.Client();
                    client.ReadClientList(stringClients, stringProducts);

                    Response.Redirect("ViewResults.aspx");

                }
                catch
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('Erro na formatação dos arquivos.');", true);
                }
            }
        }
    }
}
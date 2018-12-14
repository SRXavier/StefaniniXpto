using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.View
{
    public partial class ViewResults : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                XPTOBusiness.Client client = new XPTOBusiness.Client();
                List<XPTOBusiness.ClientProduct> source = client.GetAllClientListWithProducts();

                source = source.OrderBy(x => x.Client.ID).ToList();
                StringBuilder sb = new StringBuilder();
                int currentClient = 0;
                foreach (var item in source)
                {
                    if (currentClient != item.Client.ID)
                    {
                        currentClient = item.Client.ID;

                        sb.AppendFormat(@" <div class='form-group row'>
                                        <label for='NomeCliente' class='col-sm-2 col-form-label'>Cliente:</label>
                                        <div class='col-sm-10'>
                                            <input type = 'text' readonly class='form-control-plaintext' value='{0} {1}' runat='server'>
                                        </div>                                       
                                       </div>", item.Client.Name, item.Client.LastName);

                        var products = source.Where(x => x.Client.ID == currentClient).Select(x => x.Product).ToList();

                        if (products != null && products.Count() > 0)
                        {

                            sb.Append(@"<div class='form-group row'>
                                    <label for= 'Products' class='col-sm-2 col-form-label'>Produtos:</label>
                                 <div class='col-sm-2'>
                                  <ul class='list-group'>");

                            foreach (var product in products)
                            {
                                sb.AppendFormat(@"<li class='list-group-item'>{0}</li>", product.Name);
                            }
                            sb.Append("</ul> </div></div>");
                        }
                    }

                }
                sb.Append(@"</div>");

                lblResult.Text = sb.ToString();

            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('Erro na leitura dos dados.');", true);
            }

        }
    }
}
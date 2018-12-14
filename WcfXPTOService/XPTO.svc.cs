using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using XPTOBusiness;

namespace WcfXPTOService
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da classe "XPTO" no arquivo de código, svc e configuração ao mesmo tempo.
    // OBSERVAÇÃO: Para iniciar o cliente de teste do WCF para testar esse serviço, selecione XPTO.svc ou XPTO.svc.cs no Gerenciador de Soluções e inicie a depuração.
    public class XPTO : IXPTO
    {
        public void ImportClientWithProducts(string StringClients, string StringProducts)
        {
            Client client = new Client();
            client.ReadClientList(StringClients, StringProducts);
        }

        public List<ClientProduct> GetAllClientListWithProducts()
        {
            Client client = new Client();
            return client.GetAllClientListWithProducts();
        }
    }
}

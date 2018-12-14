using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using XPTOBusiness;

namespace WcfXPTOService
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da interface "IXPTO" no arquivo de código e configuração ao mesmo tempo.
    [ServiceContract]
    public interface IXPTO
    {
        [OperationContract]
        void ImportClientWithProducts(string StringClients, string StringProducts);
        List<ClientProduct> GetAllClientListWithProducts();
    }
}

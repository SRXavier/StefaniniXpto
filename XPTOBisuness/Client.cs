using System;
using System.Collections.Generic;
using System.Linq;
using XPTOModel;


namespace XPTOBusiness
{
    public class Client
    {
        public void ReadClientList(string StringClients, string StringProducts)
        {
            string[] clients = StringClients.Split(';');

            List<XPTOModel.Client> Clients = new List<XPTOModel.Client>();

            XPTOContext context = new XPTOContext();
            int aux = 0;
            
            foreach (string client in clients)
            {
                aux = 0;
                string[] data = client.Split(',');
                XPTOModel.Client Client = new XPTOModel.Client();

                //NOTA: O primeiro caractere do arquivo 1 está com problema (aparentemente de encode),por isso esse tratamento com Contains
                if (!Int32.TryParse(data[0], out aux))
                    if (data[0].Contains("1"))
                        aux = 1;

                Client.ID = aux;

                Client.Name = data[1];
                Client.LastName = data[2];
                Client.BirthDay = Convert.ToDateTime(data[3]);
                Client.Gender = data[4];
                Client.Email = data[5];
                Client.Actve = Convert.ToBoolean(data[6]);


                context.Clients.Add(Client);
                Clients.Add(Client);
            }



            string[] products = StringProducts.Split(';');
            List<XPTOModel.Product> Products = new List<XPTOModel.Product>();

            foreach (string product in products)
            {
                string[] data = product.Split(',');
                aux = 0;
                Int32.TryParse(data[0], out aux);
                int idProduct = aux;
                aux = 0;
                Int32.TryParse(data[1], out aux);
                int idClient = aux;
                string productName = data[2];

                if (!Products.Exists(x => x.Name == productName))
                {
                    XPTOModel.Product Product = new Product()
                    {
                        ID = idProduct,
                        Name = productName
                    };
                    Products.Add(Product);
                    context.Products.Add(Product);
                }
                XPTOModel.ClientProduct clientProduct = new XPTOModel.ClientProduct();

                clientProduct.ProductId = Products.Where(x => x.ID == idProduct).FirstOrDefault().ID;
                clientProduct.ClientId = Clients.Where(x => x.ID == idClient).FirstOrDefault().ID;


                context.ClientProducts.Add(clientProduct);
            }

            context.SaveChanges();
        }

        public List<ClientProduct> GetAllClientListWithProducts()
        {
            XPTOContext context = new XPTOContext();
            List<XPTOModel.ClientProduct> clientProducts = context.ClientProducts.AsParallel<XPTOModel.ClientProduct>().AsOrdered<XPTOModel.ClientProduct>().ToList<XPTOModel.ClientProduct>();

            List<ClientProduct> result = new List<ClientProduct>();

            foreach (var item in clientProducts)
            {
                ClientProduct clientProduct = new ClientProduct();

                clientProduct.Id = item.ID;
                clientProduct.Client = context.Clients.Find(item.ClientId);
                clientProduct.Product = context.Products.Find(item.ProductId);

                result.Add(clientProduct);
            }

            return result;
        }
    }
}

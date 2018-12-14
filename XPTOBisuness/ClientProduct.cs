using System;
using System.Collections.Generic;
using System.Text;

namespace XPTOBusiness
{
    public class ClientProduct
    {
        public int Id { get; set; }
        public XPTOModel.Client Client { get; set; }
        public XPTOModel.Product Product { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Interfaces
{
    public interface IProduct
    {
        string ProductType { get; }
        string ProductName { get; }
        int Price { get; }
    }
}

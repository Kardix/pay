using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Product:IComparable
    {
        public string name { get; set; }
        public double price { get; set; }
        public int amount { get; set; }
        public Product()
        {
            name = "";
            price = 0;
            amount = 0;
        }
        public Product (string _name, double _price, int _amount)
        {
            name = _name;
            price = _price;
            amount = _amount;
        }
        public static bool operator < (Product lhs, Product rhs)
        {
            bool status = false;
            if (lhs.price < rhs.price )
            {
                status = true;
            }
            return status;
        }
        public static bool operator >(Product lhs, Product rhs)
        {
            bool status = false;
            if (lhs.price > rhs.price)
            {
                status = true;
            }
            return status;
        }

        public int CompareTo(object _obj)
        {
            if (_obj != null)
            {
                Product obj = _obj as Product;
                return obj.price.CompareTo(price);
            }
            return 0;
        }
    }
}

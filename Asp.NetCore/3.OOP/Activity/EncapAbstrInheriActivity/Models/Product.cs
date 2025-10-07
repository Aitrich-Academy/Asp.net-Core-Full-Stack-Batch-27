using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncapAbstrInheriActivity.Models
{
    public class Product
    {
        private int id;
        private string name;
        private decimal price;
        private int stock;

        public Product(int ID, string NAME, decimal PRICE, int STOCK)
        {
            id = ID;
            name = NAME;
            price = PRICE;
            stock = STOCK;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    name = value;
                }
                else
                {
                    Console.WriteLine("Name cannot be empty");
                }

            }
        }

        public decimal Price
        {
            get { return price; }
            set
            {
                if (value >= 0)
                {
                    price = value;
                }
                else
                {
                    Console.WriteLine("Price cannot be negative.");
                }

            }
        }

        public int Stock
        {
            get { return stock; }
            set
            {
                if (value >= 0)
                {
                    stock = value;
                }
                else
                {
                    Console.WriteLine("Stock cannot be negative.");
                }
            }

        }
    }


    public class ElectronicProduct:Product
    {
        public int WarrantyPeriod;
        public string brand;

        public ElectronicProduct(int id,string name,decimal price,int stock,int warrantyPeriod, string Brand):base(id,name,price,stock)
        {
            WarrantyPeriod = warrantyPeriod;
            brand = Brand;
        }
    }


    public class ClothingProduct:Product
    {
        public int size;
        public string material;

        public ClothingProduct(int id, string name, decimal price, int stock, int Size, string Material) : base(id, name, price, stock)
        {
            size = Size;
            material = Material;
        }
    }
}

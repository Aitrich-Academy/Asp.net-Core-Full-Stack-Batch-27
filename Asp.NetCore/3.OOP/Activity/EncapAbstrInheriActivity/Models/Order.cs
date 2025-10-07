using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncapAbstrInheriActivity.Models
{
   public abstract class Order
   {
        public int orderId;
        public string customerName;
        public DateOnly orderDate;

        public Order(int OrderID,string CustomerName,DateOnly OrderDate)
        {
            orderId = OrderID;
            customerName = CustomerName;
            orderDate = OrderDate;
        }

        public abstract decimal CalculateTotal();
   }

    public class Ordering : Order
    {
        public Product[] p = new Product[3];
        public Ordering(int orderId, string customerName, DateOnly orderDate)
            : base(orderId, customerName, orderDate)
        {
        }


        public override decimal CalculateTotal()
        {
            decimal total = 0;
            for (int i = 0; i < p.Length; i++)
            {
                
                    if (p[i] != null)
                    {
                        total += p[i].Price;
                    }   
            }
            return total;
        }


        public void DisplayDetails()
        {
            Console.WriteLine("Products in the order\n");

            for (int i = 0; i < p.Length; i++)
            {
              

                if (p[i] is ElectronicProduct ep)
                {
                    Console.WriteLine($"{ep.Name}: ${ep.Price} (Brand: {ep.brand}, Warranty: {ep.WarrantyPeriod} years)");
                }

                if (p[i] is ClothingProduct cp)
                {
                    Console.WriteLine($"{cp.Name}: ${cp.Price} (Size: {cp.size}, Material: {cp.material})");
                }
                
            }

            Console.WriteLine($"\nOrder Total: ${CalculateTotal()}");
        }
    }
}

using Assessment.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Models
{
    public class CabService
    {
        public List<Cab> cabs=new List<Cab>();
      

        public void AddCab()
        {
            Console.WriteLine("Enter the Cab ID: ");
            int cabId=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Driver Name: ");
            string driverName=Console.ReadLine();
            Console.WriteLine("Enter the Cab Type (Sedan,SUV,Mini): ");
            string cabType=Console.ReadLine();
            Console.WriteLine("Is it availabe (true/false): ");
            bool isAvailabe = Convert.ToBoolean(Console.ReadLine());


            Cab newCab = new Cab(cabId, driverName, cabType,isAvailabe)
            {
                CabID = cabId,
                DriverName = driverName,
                CabType = cabType,
                IsAvailable = isAvailabe
            };

            cabs.Add(newCab);
            Console.WriteLine("\n!!Cab added successfully!!\n");
        }

        public void DisplayCab()
        {
            Console.WriteLine("\nCab Details:");

            var w=from e in cabs
                  where e.IsAvailable == true
                  select e;


            foreach (Cab item in w)
            {
                Console.WriteLine($"Cab ID: {item.CabID}  |  Driver Name: {item.DriverName}  |  Cab Type: {item.CabType}  |  IsAvailable: {item.IsAvailable}");
            }
            Console.WriteLine();

        }

        public void RemoveCab()
        {
            Console.WriteLine("Enter the Cab ID to remove cab from the list: ");
            int cabId = Convert.ToInt32(Console.ReadLine());

            Cab CabToRemove = cabs.Find(i => i.CabID.Equals(cabId));

            if (CabToRemove != null)
            {
                cabs.Remove(CabToRemove);
                Console.WriteLine($"\n!!Cab with ID-{cabId} removed successfully!!\n");
            }
            else
            {
                throw new CabNotExistException($"\n!!Cab with ID-{cabId} doesnt exist!!\n");
            }
        }

        public void BookCab()
        {
            Console.WriteLine("Enter the Cab ID to book cab: ");
            int cabId = Convert.ToInt32(Console.ReadLine());

            Cab CabToBook = cabs.Find(i => i.CabID.Equals(cabId));




            if (CabToBook == null)
            {
                throw new CabNotExistException($"\n!!Cab with ID-{cabId} doesnt exist !!\n");
            }



            if (CabToBook.IsAvailable == true)
            {

               
                Console.WriteLine($"\n!!Cab with ID-{cabId} booked Successfully!!\n");
                
                
            }
            else if (CabToBook.IsAvailable == false)
            {

                throw new CabNotAvailableException("\n!!Cab not availabe!!\n");
            }


            else
             {
                throw new AlreadyBookedException("\n!!Cab already Booked!!\n");
             }

           

        }

        public void CancelCab()
        {
            Console.WriteLine("Enter the Cab ID to cancel the booked cab: ");
            int cabId = Convert.ToInt32(Console.ReadLine());

            Cab CabToCancel = cabs.Find(i => i.CabID.Equals(cabId));

            if (CabToCancel == null)
            {
                throw new CabNotExistException($"\n!!Cab with ID-{cabId} doesnt exist!!\n");
            }


            if (CabToCancel.CabID==cabId)
            {
                Console.WriteLine($"\n!!Cancelled the booked ticket with ID-{cabId}\n!!");
            }
            
        }
    }
}

using EncapAbstrInheriActivity.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        ElectronicProduct ep = new ElectronicProduct(101, "Mobile", 50000, 4, 6, "Samsung");

        ClothingProduct cp = new ClothingProduct(201, "Shirt", 1000, 10, 44, "Cotton");

        Ordering od = new Ordering(3102,"Abhinav", DateOnly.FromDateTime(DateTime.Now));
        od.p[0] = ep;
        od.p[1] = cp;

        od.DisplayDetails();

        
    }
}
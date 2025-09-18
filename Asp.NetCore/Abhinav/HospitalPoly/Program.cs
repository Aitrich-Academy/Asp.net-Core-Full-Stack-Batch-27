using HospitalPoly.Models;

internal class Program
{
    private static void Main(string[] args)
    {
       
        Patient p1 = new Patient("Abhinav", 22, "Fever");                                            //encap
        Console.WriteLine($"Patient: {p1.GetName()}, Age: {p1.GetAge()}, Disease: {p1.GetDisease()}");

      
        Staff d1 = new Doctor("Dr.A ","Cardio");                                             //in,pol
        Staff n1 = new Nurse("Nurse B");
        Staff r1 = new Receptionist("Receptionist C");

        Console.WriteLine($"{d1.Name} Salary: {d1.CalculateSalary()}");
        Console.WriteLine($"{n1.Name} Salary: {n1.CalculateSalary()}");
        Console.WriteLine($"{r1.Name} Salary: {r1.CalculateSalary()}");

        
        Appointment online = new OnlineAppointment(p1, d1);                                     //ab
        Appointment offline = new OfflineAppointment(p1, n1);

        online.ScheduleAppointment();
        offline.ScheduleAppointment();

    }
}
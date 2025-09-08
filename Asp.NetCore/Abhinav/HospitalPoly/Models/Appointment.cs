using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalPoly.Models
{
    public abstract class Appointment
    {
        public Patient Patient;
        public Staff Staff;
        public Appointment(Patient patient, Staff staff)
        {
            Patient = patient;
            Staff = staff;
        }

        public abstract void ScheduleAppointment();
    }

    public class OnlineAppointment : Appointment
    {
        
        public OnlineAppointment(Patient patient, Staff staff) : base(patient, staff) 
        {
        }

        public override void ScheduleAppointment()
        {
            Console.WriteLine($"Online appointment set for {Patient.GetName()} with {Staff.Name},{Staff.Specialization}.");
        }
    }

    class OfflineAppointment : Appointment
    {
        public OfflineAppointment(Patient patient, Staff staff) : base(patient, staff) 
        {
        }

        public override void ScheduleAppointment()
        {
            Console.WriteLine($"Offline appointment set for {Patient.GetName()} with {Staff.Name}.");
        }
    }
}


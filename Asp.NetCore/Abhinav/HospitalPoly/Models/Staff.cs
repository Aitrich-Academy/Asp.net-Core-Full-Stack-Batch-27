using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalPoly.Models
{
    public class Staff
    {
        public string Name { get; set; }

        public Staff(string name)
        {
            Name = name;
        }

        public virtual double CalculateSalary()
        {
            return 0;
        }
    }

   public class Doctor : Staff
    {
        public string pecialization { get; set; }
        public Doctor(string name,string specialization) : base(name)
        {
            this.specialization = specialization;
        }

        public override double CalculateSalary()
        {
            return 100000; 
        }
    }

    public class Nurse : Staff
    {
        public Nurse(string name) : base(name) 
        {
        }

        public override double CalculateSalary()
        {
            return 50000; 
        }
    }

    public class Receptionist : Staff
    {
        public Receptionist(string name) : base(name)
        {
        }

        public override double CalculateSalary()
        {
            return 30000; 
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalPoly.Models
{

    public class Patient
    {
        private string name;
        private int age;
        private string disease;

        public Patient(string name, int age, string disease)
        {
            this.name = name;
            this.age = age;
            this.disease = disease;
        }

        public string GetName()
        {
            return name; 
        }
        public int GetAge() 
        {
            return age; 
        }
        public string GetDisease() 
        {
            return disease; 
        }
        public void SetDisease(string newDisease) 
        {
            disease = newDisease; 
        }
    }

}


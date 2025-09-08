using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobProvider.Model
{ 

    public class Job
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string salary { get; set; }
        public string Location { get; set; }

        public Job(int id, string title, string description, string salary, string location)
        {
            this.id = id;
            this.title = title;
            this.description = description;
            this.salary = salary;
            Location = location;
        }
    }
}

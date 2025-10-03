using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Models
{
    public class Cab
    {
        private int cabId;
        private string driverName;
        private string cabType;
        private bool isAvailable;


 
        public int CabID
        {
            get { return cabId; }
            set { cabId = value; }
        }

        public string DriverName
        { 
            get { return driverName; } 
            set { driverName = value; } 
        }

        public string CabType
        {
            get { return cabType; }
            set { cabType = value; }
        }

        public bool IsAvailable
        {
            get { return isAvailable; }
            set { isAvailable = value; }
        }

        public Cab(int cabid,string driverName,string cabType,bool isAvailable)
        {
            CabID=cabid;
            DriverName=driverName;
            CabType=cabType;
            IsAvailable = isAvailable;
          
        }
       

    }
}

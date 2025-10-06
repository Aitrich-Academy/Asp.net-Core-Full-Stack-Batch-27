using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Exception
{
    public class CabNotAvailableException:ApplicationException
    {
        public CabNotAvailableException(string message):base(message) { }
    }
}

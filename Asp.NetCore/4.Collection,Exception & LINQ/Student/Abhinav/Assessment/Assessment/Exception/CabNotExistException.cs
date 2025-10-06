using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Exception
{
    public class CabNotExistException:ApplicationException
    {
        public CabNotExistException(string message):base(message) { }
    }
}

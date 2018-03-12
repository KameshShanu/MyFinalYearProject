using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomDataHelper.Exceptions
{
   public class MyVehicleTrackerException: Exception
    {
        public MyVehicleTrackerException() { }
        public MyVehicleTrackerException(string message) : base(message) { }
        public MyVehicleTrackerException(string message, MyVehicleTrackerException inner) : base(message, inner) { }
        protected MyVehicleTrackerException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}

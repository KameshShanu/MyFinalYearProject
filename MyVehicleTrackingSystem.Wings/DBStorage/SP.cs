using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBStorage
{
    public abstract class SP
    {
        protected SP() { }
        public virtual string GetName()
        {
            return this.GetType().Name;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocContainer
{   
    //class to store implementation types, lifecycle and instances
    class RegisteredObject
    {
        public Type Implementation { get; set; }
        public LifeCycle LifeCycle { get; set; }
        public object Instance { get; set; }

       //Method to create Instance from the parameters constructors
        internal void CreateInstance(object[] parameters)
        {
            try
            {
                this.Instance = Activator.CreateInstance(this.Implementation,parameters);
            }
            catch
            {
                throw new UnableToCreateConstructorException
                    (
                        string.Format("RequiredParameterlessConstructor: ", this.Implementation)
                    );
            }
        }
    }
}

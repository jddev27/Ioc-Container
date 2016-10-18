using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocContainer
{
    public class Ioc
    {   
        //Creating dictionary to store Types for registration
        private Dictionary<Type, RegisteredObject> registeredObjects = new Dictionary<Type, RegisteredObject>();

        //Register method to perform registration of the types
        //Default lifecycle is transient
        public void Register<TContract, TImplementation>()
        {
            Register<TContract, TImplementation>(LifeCycle.Transient);
        }

        public void Register<Tcontract, TImplementation>(LifeCycle lifeCycle)
        {
            Register(typeof(Tcontract), typeof(TImplementation), lifeCycle);
        }

        private void Register(Type Tcontract, Type TImplementation, LifeCycle lifeCycle)
        {
            //Initializing the registered object with the respecting implementation and lifecycle
            RegisteredObject registeredObj = new RegisteredObject { Implementation = (TImplementation), LifeCycle = lifeCycle };
            //Add the Types to the Types to the dictonary
            registeredObjects.Add(Tcontract, registeredObj);        
        }

        //Resolve method to resolve the types
        public Tcontract Resolve<Tcontract>() 
        {
            object implementationType;
            implementationType = Resolve(typeof(Tcontract));
            return (Tcontract) implementationType;
        }

        //Method to check for non-registered Types
        public object Resolve(Type Tcontract)
        {
            object implementationType;

            if (!registeredObjects.ContainsKey(Tcontract))
            {
                throw new InterfaceNotRegisteredException("The Interface is not registered");
            }

            else
            {   //Getting implementation attributes from specific type
                RegisteredObject implementationObject = registeredObjects[Tcontract];
                implementationType = ResolveObject(implementationObject);
            }

            return implementationType;
        }

        //Method to resolve the object and check for lifecycle
        private object ResolveObject(RegisteredObject implementationObject)
        {
            if (implementationObject.Instance == null ||
               implementationObject.LifeCycle == LifeCycle.Transient)
            {
                var parameters = ResolveConstructorParameters(implementationObject);
                //Creating instances from parameters
                implementationObject.CreateInstance(parameters.ToArray());
            }
            return implementationObject.Instance;
        }

       //Getting constructors and constructors patrameters
        private IEnumerable<object> ResolveConstructorParameters(RegisteredObject registeredObject)
        {
            var constructorInfo = registeredObject.Implementation.GetConstructors().First();
            foreach (var parameter in constructorInfo.GetParameters())
            {
                yield return Resolve(parameter.ParameterType);
            }
        }
    }
}

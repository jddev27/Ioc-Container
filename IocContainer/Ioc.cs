using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocContainer
{
    public class Ioc
    {
        private Dictionary<Type, RegisteredObject> registeredObjects = new Dictionary<Type, RegisteredObject>();


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
          
                
                RegisteredObject registeredObj = new RegisteredObject { Implementation = (TImplementation), LifeCycle = lifeCycle };
                registeredObjects.Add(Tcontract, registeredObj);
                
            
        }

        public Tcontract Resolve<Tcontract>() 
        {
            object implementationType;
             

            implementationType = checkForObjectToResolve(typeof(Tcontract));
                    
                

            return (Tcontract) implementationType;
        }

        private object checkForObjectToResolve(Type Tcontract)
        {
            object implementationType;

            if (!registeredObjects.ContainsKey(Tcontract))
            {
                throw new InterfaceNotRegisteredException("The Interface is not registered");
            }

            else
            {
                RegisteredObject implementationObject = registeredObjects[Tcontract];
                implementationType = ResolveObject(implementationObject);

            }

            return implementationType;


                
                
        }

        private object ResolveObject(RegisteredObject implementationObject)
        {
            if (implementationObject.Instance == null ||
               implementationObject.LifeCycle == LifeCycle.Transient)
            {
                var parameters = ResolveConstructorParameters(implementationObject);
                implementationObject.CreateInstance(parameters.ToArray());
            }
            return implementationObject.Instance;
        }

       
        private IEnumerable<object> ResolveConstructorParameters(RegisteredObject registeredObject)
        {
            var constructorInfo = registeredObject.Implementation.GetConstructors().First();
            foreach (var parameter in constructorInfo.GetParameters())
            {
                yield return checkForObjectToResolve(parameter.ParameterType);
            }
        }
    }
}

using IocContainer;
using IocContainerTests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IocContainerTests
{
    public class IocContainerTests
    {
        [Fact]
        public void IoC_CallRegisterAndResolve_ObjectWasRegistered()
        {
            //arrange
            Ioc container = new Ioc();
            ICar car = new Car();

            //act
            container.Register<ICar, Car>();
            var actual = container.Resolve<ICar>();

            //assert
            Assert.IsType(car.GetType(), actual);
        }

        [Fact]
        public void Ioc_TransientLifeCycle_ResolvedObjecHasDifferentHashCode()
        {
            //arrange
            Ioc container = new Ioc();
            ICar car = new Car();

            //act
            container.Register<ICar, Car>();
            var actual1 = container.Resolve<ICar>();
            var actual2 = container.Resolve<ICar>();

            //assert
            Assert.NotEqual(actual1.GetHashCode(), actual2.GetHashCode());
        }

        [Fact]
        public void Ioc_SingletonLifeCycle_ResolvedObjecHasSameHashCode()
        {
            //arrange
            Ioc container = new Ioc();
            ICar car = new Car();

            //act
            container.Register<ICar, Car>(LifeCycle.Singleton);
            var actual1 = container.Resolve<ICar>();
            var actual2 = container.Resolve<ICar>();

            //assert
            Assert.Equal(actual1.GetHashCode(), actual2.GetHashCode());
        }

        [Fact]
        public void Ioc_ObjectNotRegisters_ThrowExecption()
        {
            //arrange
            Ioc container = new Ioc();
            ICar car = new Car();

            //act

           //assert
           Assert.Throws<InterfaceNotRegisteredException>(() => container.Resolve<ICar>());
        }

        [Fact]
        public void Ioc_ResolvingRegisteredObjectsWithRegisteredObjectConstructors_ObjectWasResolve()
        {
            //arrange
            Ioc container = new Ioc();
            ISpeakers logitech = new Speakers();
            ICdPlayer pioneer = new CdPlayer();
            ISoundSystem onkio = new SoundSystem(logitech, pioneer);

            container.Register<ISpeakers, Speakers>();
            container.Register<ICdPlayer, CdPlayer>();
            container.Register<ISoundSystem, SoundSystem>();




            //act
            
            var actual = container.Resolve<ISoundSystem>();


            //assert
            Assert.IsType(onkio.GetType(), actual);
        }
    }
}

using Moq;
using Ninject;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Concrete;
using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SportsStore.WebUI.Infrastracture
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public object Mock { get; private set; }

        public NinjectDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;
            AddBindings();
        }

        //private void AddBindings()    // Hardcode.
        //{
        //    Mock<IProductRepository> mock = new Mock<IProductRepository>();
        //    mock.Setup(m => m.Products).Returns(new List<Product>
        //    {
        //        new Product { Name = "Football", Price = 25 },
        //        new Product { Name = "Surf board", Price = 179 },
        //        new Product { Name = "Running shoes", Price = 95 }
        //    });

        //    kernel.Bind<IProductRepository>().ToConstant(mock.Object);
        //}

        private void AddBindings()
        {
            kernel.Bind<IProductRepository>().To<EFProductRepository>();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object>GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}
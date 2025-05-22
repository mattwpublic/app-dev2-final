using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Moq;
using CardSort.Domain.Abstract;
using CardSort.Domain.Entities;
using CardSort.Domain.Concrete;
using System.Configuration;
using CardSort.WebUI.Infrastructure.Abstract;
using CardSort.WebUI.Infrastructure.Concrete;

namespace CardSort.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel mykernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            mykernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type myserviceType)
        {
            return mykernel.TryGet(myserviceType);
        }

        public IEnumerable<object> GetServices(Type myserviceType)
        {
            return mykernel.GetAll(myserviceType);
        }

        private void AddBindings()
        {
            //Mock<ICardRepository> myMock = new Mock<ICardRepository>();
            //myMock.Setup(m => m.Cards).Returns(new List<Card>
            //{
            //    new Card { Name = "Doubling Season", Colors = "G" },
            //    new Card { Name = "Tempest Hawk", Colors = "W"},
            //    new Card { Name = "Rampant Growth", Colors = "G"}
            //});
            //mykernel.Bind<ICardRepository>().ToConstant(myMock.Object);
            mykernel.Bind<ICardRepository>().To<EFCardRepository>();

            mykernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }
    }
}
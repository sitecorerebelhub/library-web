using LibraryWeb.Controllers;
using LibraryWeb.Models;
using LibraryWeb.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LibraryWeb.Tests.Controllers
{
    [TestClass]
    public class BookListControllerTest
    {
        private IPathProvider TestPathProvider()
        {
            Mock<IPathProvider> mockObject = new Mock<IPathProvider>();
            mockObject.Setup(m => m.FilePath("\\XML\\Books.xml"));
            return mockObject.Object;
        }

        private IDeserialize TestDeserialize()
        {
            IPathProvider pp = this.TestPathProvider();
          
            Mock<IDeserialize> mockObject = new Mock<IDeserialize>();
            Deserialize dc = new Deserialize(pp);
            mockObject.Setup(m => m.GetDeserialize());
            return mockObject.Object;
        }

        private ISerialize TestSerialize()
        {
            IPathProvider pp = this.TestPathProvider();
            Mock<ISerialize> mockObject = new Mock<ISerialize>();
            Serialize sc = new Serialize(pp);
            List<book> books = null;
            mockObject.Setup(m => m.GetSerialize(books));
            return mockObject.Object;
        }


        [TestMethod]
        public void Index()
        {

            IDeserialize ds = this.TestDeserialize();
            ISerialize sd = this.TestSerialize();
           
            BookListController controller = new BookListController(ds, sd);

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result.Model);
        }


        [TestMethod]
        public void BookAction()
        {
            BookListController controller = new BookListController();

            var result = controller.BookAction("101", "return") as ActionResult;

            Assert.IsNotNull(result);
        }
    }
}

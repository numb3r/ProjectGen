//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web.Mvc;
//using GlobalEventNepal.Domain.Abstract;
//using GlobalEventNepal.Domain.Entities;
//using GlobalEventNepal.MVC.Controllers;
//using GlobalEventNepal.MVC.Extensions;
//using GlobalEventNepal.MVC.Models;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;

//namespace GlobalEventNepal.MVC.Tests
//{
//    [TestClass]
//    public class UnitTest1
//    {
//        [TestMethod]
//        public void Can_Paginate()
//        {
//            //Arrange
//            Mock<IEventRepository> mock = new Mock<IEventRepository>();
//            mock.Setup(m => m.Events).Returns(new Event[]
//            {
//                new Event {EventName = "P1", Id = new Guid("908D2E7A-8188-42A9-B81E-771D7973F399")},
//                new Event {EventName = "P2", Id = new Guid("94103549-7318-48A1-B807-9EF086CD0054")},
//                new Event {EventName = "P3", Id = new Guid("8F6B5A6E-6505-492C-AD27-239FD4951BB1")},
//                new Event {EventName = "P4", Id = new Guid("F319399C-89C1-486B-ABD3-AB1EC9DB81F2")},
//                new Event {EventName = "P5", Id = new Guid("EB72D8CF-31AC-41C1-A052-7629BFD908D0")},
//            }.AsQueryable());

//            HomeController controller = new HomeController(mock.Object);
//            controller.PageSize = 3;

//            //Act
//            EventListViewModel result = (EventListViewModel) controller.List(2).Model;

//            //Assert
//            Event[] eventArray = result.Events.ToArray();
//            Assert.IsTrue(eventArray.Length == 2);
//            Assert.AreEqual(eventArray[0].EventName, "P4");
//            Assert.AreEqual(eventArray[1].EventName, "P5");
//        }

//        [TestMethod]
//        public void Can_Generate_Page_Links()
//        {
//            //Arrange - define html helper to apply extension method
//            HtmlHelper myHelper = null;

//            //Arrange - create PagingInfo data
//            PagingInfo pagingInfo = new PagingInfo
//            {
//                CurrentPage = 2,
//                TotalItems = 28,
//                ItemsPerPage = 10
//            };

//            //Arrange - set up delegate using lambda expression
//            Func<int, string> pageUrlDelegate = i => "Page" + i;

//            //Act
//            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);

//            //Assert
//            Assert.AreEqual(result.ToString(), @"<a href=""Page1"">1</a>"
//                + @"<a class=""selected"" href=""Page2"">2</a>"
//                + @"<a href=""Page3"">3</a>");
//        }

//        [TestMethod]
//        public void Can_Send_Pagination_View_Model()
//        {
//            //Arrange
//            Mock<IEventRepository> mock = new Mock<IEventRepository>();
//            mock.Setup(m => m.Events).Returns(new Event[]
//            {
//                new Event {EventName = "P1", Id = new Guid("908D2E7A-8188-42A9-B81E-771D7973F399")},
//                new Event {EventName = "P2", Id = new Guid("94103549-7318-48A1-B807-9EF086CD0054")},
//                new Event {EventName = "P3", Id = new Guid("8F6B5A6E-6505-492C-AD27-239FD4951BB1")},
//                new Event {EventName = "P4", Id = new Guid("F319399C-89C1-486B-ABD3-AB1EC9DB81F2")},
//                new Event {EventName = "P5", Id = new Guid("EB72D8CF-31AC-41C1-A052-7629BFD908D0")},
//            }.AsQueryable());

//            HomeController controller = new HomeController(mock.Object);
//            controller.PageSize = 3;

//            //Act
//            EventListViewModel result = (EventListViewModel)controller.List(2).Model;

//            //Assert
//            PagingInfo pageInfo = result.PagingInfo;
//            Assert.AreEqual(pageInfo.CurrentPage, 2);
//            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
//            Assert.AreEqual(pageInfo.TotalPages, 2);
//            Assert.AreEqual(pageInfo.TotalItems, 5);

//        }

//    }
//}

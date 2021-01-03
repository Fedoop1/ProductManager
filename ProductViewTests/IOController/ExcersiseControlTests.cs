using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductView.IOController;
using ProductView.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductView.IOController.Tests
{
    [TestClass()]
    public class ExcersiseControlTests
    {
        [TestMethod()]
        public void ExcerciseAddTest()
        {
            //Arrange
            string name = "user";
            string actname = "actname";
            Random rnd = new Random();
            double calories = rnd.Next(1, 50);
            var activity = new Activity(actname,calories);
            User user = new User(name);
            DateTime begin = DateTime.Now;
            DateTime end = DateTime.Now.AddHours(1);


            //Act
            IOUserControl iOUserControl = new IOUserControl(user);
            ExcersiseControl excersiseControl = new ExcersiseControl(iOUserControl.CurrentUser);
            excersiseControl.ExcerciseAdd(activity, begin, end);

            //Assert
            Assert.AreEqual(actname, excersiseControl.ActivitiList.First().Name);
        }
    }
}
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
    public class EatingControlTests
    {
        [TestMethod()]
        public void EatingAddTest()
        {
            //Arange
            string name = Guid.NewGuid().ToString();
            string foodname = Guid.NewGuid().ToString();
            User user = new User(name);
            IOUserControl userControl = new IOUserControl(name);
            Random rnd = new Random();
            Food food = new Food(foodname, rnd.Next(0,500), rnd.Next(0,50), rnd.Next(0,50), rnd.Next(0,50));
            EatingControl eatingControl = new EatingControl(userControl.CurrentUser);
            //Act
            eatingControl.EatingAdd(food,400);
            //Assert
            Assert.AreEqual(food.Name, eatingControl.UserEating.FoodList.Single().Key.Name);
        }
    }
}
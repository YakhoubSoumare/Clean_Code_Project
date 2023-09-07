//As this is not what unit test is all about but it helped me!

using Moq;
using Project_Library.UIs;
using Project_Library.Logic_And_Controller;
using System.Reflection;
using Project_Library.StatisticCollections;

namespace Project_Tests.NotReusableTest
{
    [TestClass]
    public class TestOfPrivatesGameController
    {
        Mock<IUI> uiObject;
        Mock<IGameLogic> gameObject;
        Mock<IStatistics> statisticsObject;

        [TestInitialize]
        public void Initialize()
        {
            uiObject = new Mock<IUI>();
            gameObject = new Mock<IGameLogic>();
            statisticsObject = new Mock<IStatistics>();
        }


        [TestMethod]
        public void Private_AskAndDisplayUserName_should_update_name()
        {
            //Arrange
            uiObject.Setup(o => o.Input()).Returns("Yakhoub");
            GameController sut =
                new GameController(uiObject.Object, gameObject.Object, statisticsObject.Object);

            MethodInfo? method = sut.GetType().
                GetMethod("AskAndDisplayUserName",
                BindingFlags.NonPublic | BindingFlags.Instance);

            var fieldAccessor = sut.GetType().GetField("name",
                BindingFlags.NonPublic | BindingFlags.Instance);

            string expected = "Yakhoub";
            string privateActual = string.Empty;

            //Act
            try
            {
                method.Invoke(sut, null);
                privateActual = (string)fieldAccessor.GetValue(sut);

            }
            catch (Exception ex)
            {
                Assert.AreEqual("System.NullReferenceException", ex.GetType().ToString());
            }

            //Assert
            Assert.AreEqual(expected, privateActual);
        }


        [TestMethod]
        public void Private_Start_should_update_actualValues()
        {
            //Arrange
            gameObject.Setup(o => o.GenerateActualValues()).Returns("1465");
            GameController sut =
                new GameController(uiObject.Object, gameObject.Object, statisticsObject.Object);

            MethodInfo? method = sut.GetType().
                GetMethod("Start",
                BindingFlags.NonPublic | BindingFlags.Instance);

            var fieldAccessor = sut.GetType().GetField("actualValues",
                BindingFlags.NonPublic | BindingFlags.Instance);

            string expected = "1465";
            string privateActual = string.Empty;

            //Act
            try
            {
                method.Invoke(sut, null);
                privateActual = (string)fieldAccessor.GetValue(sut);

            }
            catch (Exception ex)
            {
                Assert.AreEqual("System.NullReferenceException", ex.GetType().ToString());
            }

            //Assert
            Assert.AreEqual(expected, privateActual);
        }


        [TestMethod]
        public void Private_Continue_should_update_playOn()
        {
            //Arrange
            uiObject.Setup(o => o.Input()).Returns("n");
            GameController sut =
                new GameController(uiObject.Object, gameObject.Object, statisticsObject.Object);

            MethodInfo? method = sut.GetType().
                GetMethod("Continue",
                BindingFlags.NonPublic | BindingFlags.Instance);

            var fieldAccessor = sut.GetType().GetField("playOn",
                BindingFlags.NonPublic | BindingFlags.Instance);

            bool expected = false;
            bool privateActual = true;


            //Act
            try
            {
                method.Invoke(sut, null);
                privateActual = (bool)fieldAccessor.GetValue(sut);

            }
            catch (Exception ex)
            {
                Assert.AreEqual("System.NullReferenceException", ex.GetType().ToString());
            }

            //Assert
            Assert.AreEqual(expected, privateActual);
        }
    }
}

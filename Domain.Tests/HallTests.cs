
namespace Domain.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class HallTests
    {
        private Picture picture;

        [SetUp]
        public void Setup()
        {
            this.picture = new Picture(1, "Бурлаки на Волге");
        }

        [Test]
        public void Ctor_WrongData_EmptyName_Fail()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = GetHall(string.Empty));
        }


        [Test]
        public void AddPictureToHall_ValidData_Success()
        {
            // arrange
            var hall = GetHall("Носов");

            // act
            var result = hall.AddPicture(this.picture);

            // assert
            Assert.AreEqual(true, result);
        }

        private static Hall GetHall(string name = null)
        {
            return new Hall(1, name ?? "Тестовый");
        }
    }
}

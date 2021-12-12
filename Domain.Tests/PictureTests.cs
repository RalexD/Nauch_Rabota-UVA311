namespace Domain.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class PictureTests
    {
        private Author author;

        [SetUp]
        public void Setup()
        {
            this.author = new Author(1, "Васнецов", "Виктор");
        }


        [Test]
        public void To_String_ValidData_Success()
        {
            //arrange
            var picture = new Picture(1, "Бурлаки на волге", author);

            //act
            var result = picture.ToString();
            //assert
            Assert.AreEqual("Бурлаки на волге  Васнецов В.", result);
        }

        [Test]
        public void Ctor_WrongData_EmptyName_Fail()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = GetPicture(string.Empty));
        }

        private static Picture GetPicture(string name = null, Author author = null)
        {
            return new Picture(1, name ?? "Тестовый", author);
        }
    }
}


namespace Domain.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AuthorTests
    {
        [Test]

        public void To_String_ValidData_Success()
        {
            //arrange
            var author = new Author(1, "Васнецов", "Виктор");

            //act
            var result = author.ToString();
            //assert
            Assert.AreEqual("Васнецов В.", result);
        }
        [Test]
        public void Constr_data_invalid()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Author(1, "Васнецов", ""));
        }

        [Test]
        public void AddPictureToAuthor_ValidData_Success()
        {
            //arrange
            var author = new Author(2, "Репин", "Илья");
            var picture = new Picture(2, "Бурлаки на Волге");

            //act
            var result = author.AddPicture(picture);

            //assert
            Assert.AreEqual(true, result);

        }
    }
}
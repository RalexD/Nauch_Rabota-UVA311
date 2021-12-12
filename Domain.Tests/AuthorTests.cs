namespace Domain.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AuthorTests
    {
        private Picture picture;

        [SetUp]
        public void Setup()
        {
            this.picture = new Picture(1, "Бурлаки на Волге");
        }


        [Test]
        public void To_String_ValidData_Success()
        {
            //arrange
            var author = new Author(1,"Васнецов", "Виктор");

            //act
            var result = author.ToString();
            //assert
            Assert.AreEqual("Васнецов В.", result);
        }
      
        [Test]
        public void Ctor_WrongData_EmptySecondName_Fail()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = GetAuthor(string.Empty, "Васнецов"));
        }

        [Test]
        public void Ctor_WrongData_EmptyFirstName_Fail()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = GetAuthor("Виктор", string.Empty));
        }



        [Test]
        public void AddPictureToAuthor_ValidData_Success()
        {
            // arrange
            var author = GetAuthor("Носов", "Николай");

            // act
            var result = author.AddPicture(this.picture);

            // assert
            Assert.AreEqual(true, result);
        }

        private static Author GetAuthor(string lastName = null, string firstName = null)
        {
            return new Author(1, lastName ?? "Тестовый", firstName ?? "Автор");
        }
    }
}
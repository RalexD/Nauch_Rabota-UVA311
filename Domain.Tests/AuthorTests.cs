using NUnit.Framework;

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
            this.picture = new Picture(1, "������� �� �����");
        }


        [Test]
        public void To_String_ValidData_Success()
        {
            //arrange
            var author = new Author(1, "��������", "������");

            //act
            var result = author.ToString();
            //assert
            Assert.AreEqual("�������� �.", result);
        }
        [Test]
        public void Constr_data_invalid()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Author(1, "��������", ""));
        }



        [Test]
        public void AddPictureToAuthor_ValidData_Success()
        {
            // arrange
            var author = GetAuthor("�����", "�������");

            // act
            var result = author.AddPicture(this.picture);

            // assert
            Assert.AreEqual(true, result);
        }

        private static Author GetAuthor(string lastName = null, string firstName = null)
        {
            return new Author(1, lastName ?? "��������", firstName ?? "�����");
        }
    }
}
namespace ORM.Tests
{
    using Domain;
    using FluentNHibernate.Testing;
    using NUnit.Framework;

    /// <summary>
    /// ����� �������� ��� ������ <see cref="Mappings.AuthorMap"/>.
    /// </summary>
    [TestFixture]
    public class AuthorMapTests : BaseMapTests
    {
        [Test]
        public void PersistenceSpecification_ValidSimpleData_Success()
        {
            // arrange
            var author = new Author(1, "��������", "������");

            // act & assert
            new PersistenceSpecification<Author>(this.Session)
                .VerifyTheMappings(author);
        }

        [Test]
        public void PersistenceSpecification_ValidComplexData_Success()
        {
            // arrange
            var author = new Author(1, "��������", "������");

            var picture = new Picture(1, "������� �� �����", author);
            var hall = new Hall(1, "������������� ��������");

            // act & assert
            new PersistenceSpecification<Author>(this.Session)

                .VerifyTheMappings(author);
        }
    }
}
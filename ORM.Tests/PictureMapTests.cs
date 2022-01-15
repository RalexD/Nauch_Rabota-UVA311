namespace ORM.Tests
{
    using Domain;
    using FluentNHibernate.Testing;
    using NUnit.Framework;

    /// <summary>
    /// Тесты маппинга для Автора <see cref="Mappings.PictureMap"/>.
    /// </summary>
    [TestFixture]
    public class PictureMapTests : BaseMapTests
    {
        [Test]
        public void PersistenceSpecification_ValidSimpleData_Success()
        {
            // arrange
            var picture = new Picture(1, "Утро в сосновом лесу");

            // act & assert
            new PersistenceSpecification<Picture>(this.Session)
            .VerifyTheMappings(picture);
        }

        [Test]
        public void PersistenceSpecification_ValidComplexData_Success()
        {
            // arrange
            var author = new Author(1, "Васильев", "Кирилл");

            var picture = new Picture(1, "Утро в сосновом лесу", author);
            var hall = new Hall(1, "ЗалТестовый");
            hall.AddPicture(picture);

            // act & assert
            new PersistenceSpecification<Picture>(this.Session)

            .VerifyTheMappings(picture);
        }
    }
}
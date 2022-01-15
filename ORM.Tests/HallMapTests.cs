namespace ORM.Tests
{
    using Domain;
    using FluentNHibernate.Testing;
    using NUnit.Framework;

    /// <summary>
    /// Тесты маппинга для Зала <see cref="Mappings.HallMap"/>.
    /// </summary>
    [TestFixture]
    public class HallMapTests : BaseMapTests
    {
        [Test]
        public void PersistenceSpecification_ValidSimpleData_Success()
        {
            // arrange
            var hall = new Hall(1, "Третьяковская галерея");

            // act & assert
            new PersistenceSpecification<Hall>(this.Session)
            .VerifyTheMappings(hall);
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
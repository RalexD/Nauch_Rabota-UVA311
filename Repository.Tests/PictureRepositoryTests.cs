namespace Repository.Tests
{
    using System.Linq;
    using Domain;
    using NHibernate;
    using NUnit.Framework;
    using ORM.Mappings;
    using ORM.Repositories;

    [TestFixture]
    public class PictureRepositoryTests
    {
        [Test]
        public void Add_Picture()
        {
            var savedPicture = GeneratePicture();
            _iRep.Create(savedPicture);
            Assert.AreEqual(1, _iRep.GetAll().Count());
            Assert.AreEqual("Бурлаки на Волге", savedPicture.Name);
        }

        [Test]
        public void Delete_PictureById()
        {
            var deletePicture = _iRep.Get(1);
            _iRep.Delete(1);
            Assert.AreEqual(0, _iRep.GetAll().Count());
        }

        [Test]
        public void UpdatePictureByName()
        {
            var savedPicture = GeneratePicture(2);
            _iRep.Create(savedPicture);
            var updatePicture = _iRep.Get(2);
            updatePicture.Name = "Копия";

            _iRep.Update(updatePicture);
            Assert.AreEqual("Копия", updatePicture.Name);
        }

        private static Picture GeneratePicture(int id = 1, string Name = null, Author author = null) => new(1, Name ?? "Бурлаки на Волге", author);

        private static readonly ISession _session = NHibernateTestsConfigurator.BuildSessionForTest();

        private static readonly IRepository<Picture> _iRep = new PictureRepository(_session);
    }
}
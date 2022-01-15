namespace Repository.Tests
{
    using System.Linq;
    using Domain;
    using NHibernate;
    using NUnit.Framework;
    using ORM.Mappings;
    using ORM.Repositories;

    [TestFixture]
    public class HallRepositoryTests
    {
        [Test]
        public void Add_Hall()
        {
            var savedHall = GenerateHall();
            _iRep.Create(savedHall);
            Assert.AreEqual(1, _iRep.GetAll().Count());
            Assert.AreEqual("Третьяковская галерея", savedHall.Nazvanie);
        }

        [Test]
        public void Delete_HallById()
        {
            var deleteHall = _iRep.Get(1);
            _iRep.Delete(1);
            Assert.AreEqual(0, _iRep.GetAll().Count());
        }

        [Test]
        public void UpdateHallByName()
        {
            var savedHall = GenerateHall(2);
            _iRep.Create(savedHall);
            var updateHall = _iRep.Get(2);
            updateHall.Nazvanie = "Галерея";

            _iRep.Update(updateHall);
            Assert.AreEqual("Галерея", updateHall.Nazvanie);
        }

        private static Hall GenerateHall(int id = 1, string Name = null) =>
            new(1, Name ?? "Третьяковская галерея");

        private static readonly ISession _session = NHibernateTestsConfigurator.BuildSessionForTest();

        private static readonly IRepository<Hall> _iRep = new HallRepository(_session);
    }
}
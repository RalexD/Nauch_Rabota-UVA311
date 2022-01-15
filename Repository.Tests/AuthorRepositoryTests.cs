namespace Repository.Tests
{
    using System.Linq;
    using Domain;
    using NHibernate;
    using NUnit.Framework;
    using ORM.Mappings;
    using ORM.Repositories;

    [TestFixture]
    public class AuthorRepositoryTests
    {
        [Test]
        public void Add_Author()
        {
            var savedAuthor = GenerateAuthor();
            _iRep.Create(savedAuthor);
            Assert.AreEqual(1, _iRep.GetAll().Count());
            Assert.AreEqual("Виктор", savedAuthor.FirstName);
        }

        [Test]
        public void Delete_AuthorById()
        {
            var deleteAuthor = _iRep.Get(1);
            _iRep.Delete(1);
            Assert.AreEqual(0, _iRep.GetAll().Count());
        }

        [Test]
        public void UpdateAuthorByLastName()
        {
            var savedAuthor = GenerateAuthor(2);
            _iRep.Create(savedAuthor);
            var updateAuthor = _iRep.Get(2);
            updateAuthor.LastName = "Нетребко";

            _iRep.Update(updateAuthor);
            Assert.AreEqual("Нетребко", updateAuthor.LastName);
        }

        private static Author GenerateAuthor(int id = 1, string secondName = null, string firstName = null) => new(1, secondName ?? "Васнецов", firstName ?? "Виктор");

        private static readonly ISession _session = NHibernateTestsConfigurator.BuildSessionForTest();

        private static readonly IRepository<Author> _iRep = new AuthorRepository(_session);
    }
}
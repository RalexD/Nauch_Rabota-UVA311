

namespace ORM.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Domain;
    using NHibernate;

    /// <summary>
    /// Репозиторий для Авторов.
    /// </summary>
    public class AuthorRepository : IRepository<Author>
    {
        private readonly ISession _session;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="AuthorRepository"/>.
        /// </summary>
        /// <param name="session">Сессия для Авторов.</param>
        public AuthorRepository(ISession session)
        {
            this._session = session
                ?? throw new ArgumentNullException(nameof(session));
        }

        /// <inheritdoc/>
        public IQueryable<Author> Filter(Expression<Func<Author, bool>> predicate)
        {
            return this.GetAll().Where(predicate);
        }

        /// <inheritdoc/>
        public Author Find(Expression<Func<Author, bool>> predicate)
        {
            return this.GetAll().FirstOrDefault(predicate);
        }

        /// <inheritdoc/>
        public Author Get(int id)
        {
            return this._session.Get<Author>(id);
        }

        /// <inheritdoc/>
        public IQueryable<Author> GetAll()
        {
            return this._session.Query<Author>();
        }

        /// <inheritdoc/>
        public bool TryGet(int id, out Author author)
        {
            author = this.GetAll().SingleOrDefault(p => p.Id == id);
            return author != null;
        }

        /// <inheritdoc/>
        public Author Create(Author author)
        {
            var id = (int)this._session.Save(author);
            this._session.Flush();
            return author;
        }

        /// <inheritdoc/>
        public void Delete(int id)
        {
            if (!this.TryGet(id, out var author))
            {
                return;
            }

            this._session.Delete(author);
            this._session.Flush();
        }

        /// <inheritdoc/>
        public void Update(Author author)
        {
            this._session.Update(author);
            this._session.Flush();
        }
    }
}

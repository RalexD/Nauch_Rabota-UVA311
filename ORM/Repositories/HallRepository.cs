

namespace ORM.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Domain;
    using NHibernate;

    /// <summary>
    /// Репозиторий для Залов.
    /// </summary>
    public class HallRepository : IRepository<Hall>
    {
        private readonly ISession _session;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="HallRepository"/>.
        /// </summary>
        /// <param name="session">Сессия для Залов.</param>
        public HallRepository(ISession session)
        {
            this._session = session
                ?? throw new ArgumentNullException(nameof(session));
        }

        /// <inheritdoc/>
        public IQueryable<Hall> Filter(Expression<Func<Hall, bool>> predicate)
        {
            return this.GetAll().Where(predicate);
        }

        /// <inheritdoc/>
        public Hall Find(Expression<Func<Hall, bool>> predicate)
        {
            return this.GetAll().FirstOrDefault(predicate);
        }

        /// <inheritdoc/>
        public Hall Get(int id)
        {
            return this._session.Get<Hall>(id);
        }

        /// <inheritdoc/>
        public IQueryable<Hall> GetAll()
        {
            return this._session.Query<Hall>();
        }

        /// <inheritdoc/>
        public bool TryGet(int id, out Hall hall)
        {
            hall = this.GetAll().SingleOrDefault(p => p.Id == id);
            return hall != null;
        }

        /// <inheritdoc/>
        public Hall Create(Hall hall)
        {
            var id = (int)this._session.Save(hall);
            this._session.Flush();
            return hall;
        }

        /// <inheritdoc/>
        public void Delete(int id)
        {
            if (!this.TryGet(id, out var hall))
            {
                return;
            }

            this._session.Delete(hall);
            this._session.Flush();
        }

        /// <inheritdoc/>
        public void Update(Hall hall)
        {
            this._session.Update(hall);
            this._session.Flush();
        }
    }
}

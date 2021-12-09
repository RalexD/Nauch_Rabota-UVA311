namespace ORM.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Domain;
    using NHibernate;

    /// <summary>
    /// Репозиторий для картин.
    /// </summary>
    public class PictureRepository : IRepository<Picture>
    {
        private readonly ISession _session;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="PictureRepository"/>.
        /// </summary>
        /// <param name="session">Сессия для Картин.</param>
        public PictureRepository(ISession session)
        {
            this._session = session
                ?? throw new ArgumentNullException(nameof(session));
        }

        /// <inheritdoc/>
        public IQueryable<Picture> Filter(Expression<Func<Picture, bool>> predicate)
        {
            return this.GetAll().Where(predicate);
        }

        /// <inheritdoc/>
        public Picture Find(Expression<Func<Picture, bool>> predicate)
        {
            return this.GetAll().FirstOrDefault(predicate);
        }

        /// <inheritdoc/>
        public Picture Get(int id)
        {
            return this._session.Get<Picture>(id);
        }

        /// <inheritdoc/>
        public IQueryable<Picture> GetAll()
        {
            return this._session.Query<Picture>();
        }

        /// <inheritdoc/>
        public bool TryGet(int id, out Picture picture)
        {
            picture = this.GetAll().SingleOrDefault(p => p.Id == id);
            return picture != null;
        }

        /// <inheritdoc/>
        public Picture Create(Picture picture)
        {
            var id = (int)this._session.Save(picture);
            this._session.Flush();
            return picture;
        }

        /// <inheritdoc/>
        public void Delete(int id)
        {
            if (!this.TryGet(id, out var picture))
            {
                return;
            }

            this._session.Delete(picture);
            this._session.Flush();
        }

        /// <inheritdoc/>
        public void Update(Picture picture)
        {
            this._session.Update(picture);
            this._session.Flush();
        }
    }
}

namespace Domain
{
    using System;
    using System.Collections.Generic;
    using Staff.Extensions;

    /// <summary>
    /// Зал.
    /// </summary>
    public class Hall
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Hall"/>.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <param name="nazvanie">Название.</param>

        public Hall(int id, string nazvanie)
        {
            this.Id = id;
            this.Nazvanie = nazvanie.TrimorNull() ?? throw new ArgumentOutOfRangeException(nameof(Nazvanie));
        }

        [Obsolete("For ORM only", true)]
        protected Hall()
        {
        }

        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        public virtual int Id { get; protected set; }

        /// <summary>
        /// Название.
        /// </summary>
        public virtual string Nazvanie { get; protected set; }



        /// <summary>
        /// Список картин холла.
        /// </summary>
        public virtual ISet<Picture> Pictures { get; protected set; } = new HashSet<Picture>();


        /// <summary>
        /// Добавить картину холла
        /// </summary>
        /// <param name="picture"> добавляемая картина.</param>
        /// <returns>
        /// <see langword="true"/> если картина была добавлена.
        /// </returns>
        public virtual bool AddPicture(Picture picture)
        {
            return this.Pictures.TryAdd(picture) ?? throw new ArgumentNullException(nameof(picture));
        }
    }
}
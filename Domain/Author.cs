namespace Domain
{
    using System;
    using System.Collections.Generic;
    using Staff.Extensions;

    /// <summary>
    /// Автор.
    /// </summary>
    public class Author
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Author"/>.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <param name="lastName">Фамилия.</param>
        /// <param name="firstName">Имя.</param>

        public Author(int id, string lastName, string firstName)
        {
            this.Id = id;
            this.LastName = lastName ?? throw new ArgumentOutOfRangeException(nameof(lastName));
            this.FirstName = firstName ?? throw new ArgumentOutOfRangeException(nameof(firstName));
        }

        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        public int Id { get; protected set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string LastName { get; protected set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string FirstName { get; protected set; }

        /// <summary>
        /// Список картин автора.
        /// </summary>
        public ISet<Picture> Pictures { get; protected set; } = new HashSet<Picture>();

        /// <summary>
        /// Полное имя.
        /// </summary>
        public string FullName => $"{this.LastName} {this.FirstName?[0]}.".Trim();

        /// <summary>
        /// Добавить картину автору
        /// </summary>
        /// <param name="picture"> добавляемая картина.</param>
        /// <returns>
        /// <see langword="true"/> если книга была добавлена.
        /// </returns>
        public bool AddPicture(Picture picture)
        {
            return this.Pictures.TryAdd(picture) ?? throw new ArgumentNullException(nameof(picture));
        }

        public override string ToString() => this.FullName;
    }
}
namespace Domain
{
    using System;
    using System.Collections.Generic;
    using String.Extensions;

    /// <summary>
    /// Автор.
    /// </summary>
    public class Author
    {
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
    }
}
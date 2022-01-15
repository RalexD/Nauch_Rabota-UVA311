// <copyright file="Author.cs" company="МИИТ_УВА-311">
// Copyright (c) МИИТ_УВА-311. All rights reserved.
// </copyright>

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
            this.LastName = lastName.TrimorNull() ?? throw new ArgumentOutOfRangeException(nameof(lastName));
            this.FirstName = firstName.TrimorNull() ?? throw new ArgumentOutOfRangeException(nameof(firstName));
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Author"/>.
        /// </summary>
        [Obsolete("For ORM only", true)]
        protected Author()
        {
        }

        /// <summary>
        /// Получает или задает уникальный идентификатор.
        /// </summary>
        public virtual int Id { get; protected set; }

        /// <summary>
        /// Получает или задает фамилия.
        /// </summary>
        public virtual string LastName { get; set; }

        /// <summary>
        /// Получает или задает имя.
        /// </summary>
        public virtual string FirstName { get; set; }

        /// <summary>
        /// Получает или задает список картин автора.
        /// </summary>
        public virtual ISet<Picture> Pictures { get; set; } = new HashSet<Picture>();

        /// <summary>
        /// Получает полное имя.
        /// </summary>
        public virtual string FullName => $"{this.LastName} {this.FirstName?[0]}.".Trim();

        /// <summary>
        /// Добавить картину автору.
        /// </summary>
        /// <param name="picture"> добавляемая картина.</param>
        /// <returns>
        /// <see langword="true"/> если книга была добавлена.
        /// </returns>
        public virtual bool AddPicture(Picture picture)
        {
            return this.Pictures.TryAdd(picture) ?? throw new ArgumentNullException(nameof(picture));
        }

        /// <inheritdoc/>
        public override string ToString() => this.FullName;
    }
}
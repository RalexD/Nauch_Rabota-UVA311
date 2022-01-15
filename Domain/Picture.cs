// <copyright file="Picture.cs" company="МИИТ_УВА-311">
// Copyright (c) МИИТ_УВА-311. All rights reserved.
// </copyright>

namespace Domain
{
    using System;
    using Staff.Extensions;

    /// <summary>
    /// Картина.
    /// </summary>
    public class Picture
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Picture"/>.
        /// </summary>
        /// <param name="id">Уникальный идентификатор.</param>
        /// <param name="name">Название картины.</param>
        /// <param name="author">автор.</param>
        public Picture(int id, string name, Author author = null)
        {
            this.Id = id;

            this.Name = name.TrimorNull() ?? throw new ArgumentOutOfRangeException(nameof(name));

            this.Picture_author = author;
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Picture"/>.
        /// </summary>
        [Obsolete("For ORM only", true)]
        protected Picture()
        {
        }

        /// <summary>
        /// Получает или задает уникальный идентификатор.
        /// </summary>
        public virtual int Id { get; protected set; }

        /// <summary>
        /// Получает или задает название картины.
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Получает или задает список автора.
        /// </summary>
        public virtual Author Picture_author { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{this.Name}  {this.Picture_author.FullName}";
        }
    }
}

// <copyright file="Picture.cs" company="МИИТ_УВА-311">
// Copyright (c) МИИТ_УВА-311. All rights reserved.
// </copyright>

namespace Domain
{
    using System;
    using System.Collections.Generic;
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
        /// <param name="authors">Список авторов.</param>
        public Picture(int id, string name, params Author[] authors)
            : this(id, name, new HashSet<Author>(authors))
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Picture"/>.
        /// </summary>
        /// <param name="id">Уникальный идентификатор.</param>
        /// <param name="name">Название картины.</param>
        /// <param name="authors">список авторов.</param>
        public Picture(int id, string name, ISet<Author> authors = null)
        {
            this.Id = id;

            this.Name = name.TrimorNull() ?? throw new ArgumentOutOfRangeException(nameof(name));

            if (authors != null)
            {
                foreach (var author in authors)
                {
                    this.Authors.Add(author);
                    author.AddPicture(this);
                }
            }
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
        public virtual string Name { get; protected set; }

        /// <summary>
        /// Получает или задает список Авторов.
        /// </summary>
        public virtual ISet<Author> Authors { get; protected set; } = new HashSet<Author>();

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{this.Name}  {this.Authors.Join()}";
        }
    }
}

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
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="authors"></param>
        public Picture(int id, string name, params Author[] authors)
            : this(id, name, new HashSet<Author>(authors))
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="authors"></param>
        public Picture(int id, string name, ISet<Author> authors = null)
        {
            this.Id = id;

            this.Name = name.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(name));

            if (authors != null )
            {
                foreach (var author in authors)
                {
                    this.Authors.Add(author);
                    author.AddPicture(this);
                }
            }
        }

        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        public int Id { get; protected set; }

        /// <summary>
        /// Название картины.
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Список Авторов.
        /// </summary>
        public ISet<Author> Authors { get; protected set; } = new HashSet<Author>();

        public override string ToString()
        {
            return $"{this.Name}  {this.Authors.Join()}";
        }
    } 
}

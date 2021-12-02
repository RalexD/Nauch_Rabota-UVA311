// <copyright file="PictureMap.cs" company="МИИТ_УВА-311">
// Copyright (c) МИИТ_УВА-311. All rights reserved.
// </copyright>

namespace ORM.Mappings
{
    using Domain;
    using FluentNHibernate.Mapping;

    /// <summary>
    /// Класс, описывающий правила отображения <see cref="Picture"/> на таблицу и на оборот.
    /// </summary>
    internal class PictureMap : ClassMap<Picture>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="PictureMap"/>.
        /// </summary>
        public PictureMap()
        {
            this.Schema("dbo");

            this.Table("Pictures");

            this.Id(x => x.Id);

            this.Map(x => x.Name);

            this.HasManyToMany(x => x.Authors).Inverse();
        }
    }
}

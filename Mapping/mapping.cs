using System;
using Domain;
using FluentNHibernate.Mapping;

namespace Mapping
{
    public class AuthorMap : ClassMap<Author>
    {
        public AuthorMap()
        {
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.FirstName).Not.Nullable();
            Map(x => x.LastName).Not.Nullable();
            Map(x => x.FullName);
            HasMany(x => x.Pictures).KeyColumns.Add("AuthorID").Inverse().Cascade.All();
        }
    }



    public class PictireMap : ClassMap<Picture>
    {
        public PictireMap()
        {
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.Name);
            References(x => x.Authors).Column("AuthorID");
        }
    }
}

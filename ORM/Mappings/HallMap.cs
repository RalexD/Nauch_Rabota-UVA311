namespace ORM.Mappings
{
    using Domain;
    using FluentNHibernate.Mapping;

    /// <summary>
    /// Класс, описывающий правила отображения <see cref="Hall"/> на таблицу и на оборот.
    /// </summary>
    internal class HallMap : ClassMap<Hall>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="HallMap"/>.
        /// </summary>
        public HallMap()
        {
            this.Schema("dbo");

            this.Table("Halls");

            this.Id(x => x.Id);

            this.Map(x => x.Nazvanie).Not.Nullable();

            this.HasMany(x => x.Pictures);
        }
    }
}
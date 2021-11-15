using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
namespace ORM
{
    using NHibernate.Tool.hbm2ddl;
    using NHibernate.Cfg;

    public class NHibernateConfigurator
    {
        private static FluentConfiguration fluentConfiguration;
        public static ISessionFactory GetSessionFactory(Assembly assembly = null, bool showSQL = false)
        {
            return GetConfiguration(assembly ?? Assembly.GetExecutingAssembly(), showSQL).BuildSessionFactory();
        }

        private static FluentConfiguration GetConfiguration(Assembly assembly, bool showSQL = false)
        {
            if (fluentConfiguration is null)
            {
                var databaseConfiguration = MsSqlConfiguration.MsSql2012.ConnectionString(
                    x => x.Server(@"localhost\SQLEXPRESS")
                        .Database("PictureGallery")
                        .TrustedConnection()
                    );

                if (showSQL)
                {
                    databaseConfiguration = databaseConfiguration.ShowSql().FormatSql();
                }
                fluentConfiguration = Fluently.Configure()
                    .Database(databaseConfiguration)
                    .Mappings(m => m.FluentMappings.AddFromAssembly(assembly))
                    .ExposeConfiguration(BuildSchema);
            }
            return fluentConfiguration;
        }

        private static void BuildSchema(Configuration configuration)
        {
            new SchemaExport(configuration).Execute(true, true, false);
        }
    }
}

namespace PictureGallery
{
    using NHibernate;
    using System;
    using System.Reflection;
    public class Program
    {
        private static void Main(string[] args)
        {
            var author = new Domain.Author(1, "Васнецов", "Виктор");
            var picture = new Domain.Picture(1, "Богатыри");
            author.AddPicture(picture);

            Console.WriteLine($"{picture} {author}");

            var sessionFactory = ORM.NHibernateConfigurator.GetSessionFactory(showSQL: true);

            using(var session = sessionFactory.OpenSession())
            {
                session.Save(author);
                session.Save(picture);
                session.Flush();
            }
        }
    }
}

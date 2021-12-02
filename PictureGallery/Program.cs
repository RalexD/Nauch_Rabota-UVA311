// <copyright file="Program.cs" company="МИИТ_УВА-311">
// Copyright (c) МИИТ_УВА-311. All rights reserved.
// </copyright>

namespace PictureGallery
{
    using System;
    using Domain;
    using ORM;

    /// <summary>
    /// The profram.
    /// </summary>
    internal class Program
    {
        private static void Main()
        {
            var author = new Author(1, "Васнецов", "Виктор");

            var picture = new Picture(1, "Богатыри", author);

            author.AddPicture(picture);

            Console.WriteLine($"{picture} {author}");

            using var sessionFactory = NHibernateConfigurator.GetSessionFactory(showSql: true);

            using var session = sessionFactory.OpenSession();
            session.Save(author);
            session.Save(picture);
            session.Flush();
        }
    }
}

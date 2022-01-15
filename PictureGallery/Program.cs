// <copyright file="Program.cs" company="МИИТ_УВА-311">
// Copyright (c) МИИТ_УВА-311. All rights reserved.
// </copyright>

namespace PictureGallery
{
    using ORM;
    using Domain;
    using ORM.Repositories;
    /// <summary>
    /// Исполняемый класс.
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var db = NHibernateConfigurator.GetSessionFactory())
            {
                Author author = new Author(1, "Носов", "Николай");
                Author author1 = new Author(2, "Макртумян", "Артём");
                Picture picture = new Picture(1, "Миит");
                author1.AddPicture(picture);
                Hall hall = new Hall(1, "Третьяковская галерея");
                hall.AddPicture(picture);

                var session = db.OpenSession();
                AuthorRepository authorRepository = new AuthorRepository(session);
                PictureRepository pictureRepository = new PictureRepository(session);
                HallRepository hallRepository = new HallRepository(session);
                
                pictureRepository.Create(picture);
                authorRepository.Create(author);
                authorRepository.Create(author1);
                hallRepository.Create(hall);
                
                
                
          
            }
        }
    }
}
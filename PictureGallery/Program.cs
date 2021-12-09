// <copyright file="Program.cs" company="МИИТ_УВА-311">
// Copyright (c) МИИТ_УВА-311. All rights reserved.
// </copyright>

namespace PictureGallery
{
    using ORM;
    using Domain;
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
            }
        }
    }
}
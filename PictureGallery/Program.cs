namespace PictureGallery
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var author = new Domain.Author(1, "Васнецов", "Виктор");
            var picture = new Domain.Picture(1, "Богатыри");
            author.AddPicture(picture);
            
            Console.WriteLine($"{picture} {author}");
        }
    }
}

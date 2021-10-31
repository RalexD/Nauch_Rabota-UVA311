namespace PictureGallery
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var author = new Domain.Author(1, "Васнецов", "Виктор");
            var picture = new Domain.Picture(1, "Богатыри", author);
            author.AddPicture(picture);

            Console.WriteLine($"{picture} {author}");
        }
    }
}

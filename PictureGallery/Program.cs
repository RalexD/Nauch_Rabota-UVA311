using System;

namespace PictureGallery
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Domain.Picture();
            var author = new Domain.Author();

            Console.WriteLine($"{book} {author}");
        }
    }
}

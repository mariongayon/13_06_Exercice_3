using System;
using System.IO;

namespace Netflix
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = @"C:\Users\Administrateur\source\repos\13_06_Exercice_3\Netflix\NetflixTitles.csv";
            using FileStream fs = File.OpenRead(fileName);
            byte[] films = new byte[fs.Length];

            int f;

          

            while ((f = fs.Read(films, 0, films.Length)) > 0)
            {
                Console.WriteLine(System.Text.Encoding.UTF8.GetString(films, 0, f));
            }


            byte[] buffer = new byte[fs.Length];
            string value = "";

            fs.Seek(0, SeekOrigin.Begin);
            
     
           int read = 0;

            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
           

            while (read < fs.Length) 
            {
                int read1 = fs.Read(buffer.AsSpan());

                read += read1;

                value = encoder.GetString(buffer.AsSpan().Slice(0, read1));

            }


            value = "";
            read = 0;

            while (read < fs.Length)
            {
                int read2 = fs.Read(buffer, read, (int)fs.Length);

                value = System.Text.Encoding.UTF8.GetString(buffer.AsSpan().Slice(0, read2));

                read += read2;
            }

        }
    }
}

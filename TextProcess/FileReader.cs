using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextProcess
{
    public class FileReader
    {
        public void Reader()
        {
            /* по хорошему, куда-то надо сохранять класс, а не вызывать его new, каждый раз
             * но тогда, возможно, появится проблема с закрытием потока записи или чтения, хз 
             * Connection() - точно достаточно сделать один раз */
            new Database.Database().Connection();
            new Database.Database().Write();

            return;

            string filePath = @"C:\Users\Mvideo\source\repos\TextProcess\Sport_article.txt";
            string[] words;
            char[] chars = new char[] { ' ', '\r', '\n' };

            using (StreamReader sr = new StreamReader(filePath))
            {
                words = sr.ReadToEnd().Split(chars); 
            }

            Console.WriteLine("!!!!");



        }
    }
}

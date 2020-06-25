using System;
using System.Threading.Tasks;

namespace lemafUfla
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string word = ReadWord.Read();
            Console.WriteLine();

            var itemDictionary = await Dictionary.ProcessDictionary(word);
            Console.WriteLine(itemDictionary.Index + " - " + itemDictionary.Word);
            Console.WriteLine();

            /*
            var repositories = await Dictionary.ProcessDictionary(word);

            foreach (var repo in repositories)
            {
                Console.WriteLine(repo.Value1);
                Console.WriteLine(repo.Value2);
                Console.WriteLine();
            }
            */
        }
    }
}

using System;
using System.Threading.Tasks;

namespace lemafUfla
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await EnterWord();
        }

        public static async Task EnterWord()
        {
            string word = ReadWord.Read();
            Console.WriteLine();

            var itemDictionary = await Dictionary.ProcessDictionary(word);
            Console.WriteLine(itemDictionary.Index + " - " + itemDictionary.Word);
            Console.WriteLine();
            await EnterWord();
        }
    }
}

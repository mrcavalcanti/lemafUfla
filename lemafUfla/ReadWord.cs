using System;

namespace lemafUfla
{
    public class ReadWord
    {
        public static string Read()
        {
            Console.WriteLine("Digite uma palavra:");
            string w = "";
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    w += key.KeyChar;
                    Console.Write(key.KeyChar);
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && w.Length > 0)
                    {
                        w = w.Substring(0, (w.Length - 1));
                        Console.Write("\b \b");
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            } while (true);
            return w;
        }
    }
}

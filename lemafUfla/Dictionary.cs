using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace lemafUfla
{
    public class Dictionary
    {
        private static readonly List<ItemDictionary> wordList = new List<ItemDictionary>();
        public static async Task<ItemDictionary> ProcessDictionary(string word)
        {
            ItemDictionary item = null;
            bool alreadyExist = wordList.Any(el => el.Word == word);
            if (!alreadyExist)
            {
                item = await Rest.GetItemDictionary(1);
                if (item.Index > -1)
                {
                    wordList.Add(item);
                }
            }
            return item;
                
        }

    }
}
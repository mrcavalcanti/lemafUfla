using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace lemafUfla
{
    public class Dictionary
    {
        private static readonly List<ItemDictionary> wordList = new List<ItemDictionary>();
        public static async Task<ItemDictionary> ProcessDictionary(string word)
        {
            ItemDictionary item = null;

            ItemDictionary itemList = wordList.Find(el => el.Word == word);
            if (itemList == null)
            {
                do
                {
                    item = await Rest.GetItemDictionary(wordList.Count);
                    if (item.Index > -1)
                    {
                        wordList.Add(item);
                        if (item.Word == word)
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                } while (true);
            }
            else
            {
                item = itemList;
            }
            return item;
                
        }

    }
}
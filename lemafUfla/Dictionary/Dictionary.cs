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
            int deadTrees = 0;
            ItemDictionary itemList = wordList.Find(el => el.Word == word);
            if (itemList == null)
            {
                do
                {
                    item = await Rest.GetItemDictionary(wordList.Count);
                    deadTrees += 1;
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
                // neste ponto verifica-se a posicao real no webservice, e se for necessario zera a lista da memoria e comeca a contar novamente para otimizacao (arores mortas)
            }
            item.tree = deadTrees;
            return item;
                
        }

    }
}
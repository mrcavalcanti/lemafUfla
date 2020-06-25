using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace lemafUfla
{
    public class Rest
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string urlLemaf = "http://testes.ti.lemaf.ufla.br/api/Dicionario/";
        public static async Task<ItemDictionary> GetItemDictionary(int index)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var streamTask = client.GetStreamAsync(urlLemaf + index); // index max: 99999
            ItemDictionary item;
            try
            {
                var word = await JsonSerializer.DeserializeAsync<String>(await streamTask);

                item = new ItemDictionary
                {
                    Index = index,
                    Word = word
                };
            }
            catch
            {
                item = new ItemDictionary
                {
                    Index = -1,
                    Word = "Palavra não encontrada no dicionário"
                };
            }
            return item;
        }
    }
}

using DomainApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace DomainApp.Logic
{
    public class DomainLogic
    {
        static public List<Domain> GetDomains(List<string> words, List<string> tlds)
        {
            List<Domain> domains = new List<Domain>();

            List<string> usedWords = new List<string>();

            for (int i = 0; i <= 10; i++)
            {
                var random = new Random();
                int numberOfWords = random.Next(1, 3);

                List<string> wordsChosen = new List<string>();

                for (int g = 0; g < numberOfWords; g++)
                {
                    var index = random.Next(0, words.Count);

                    var wordChosen = words[index];

                    if (numberOfWords == 1)
                    {
                        wordsChosen.Add(wordChosen);
                    }
                    else if (numberOfWords > 1 && !wordsChosen.Contains(wordChosen))
                    {
                        wordsChosen.Add(wordChosen);
                    }
                }

                var tldIndex = random.Next(0, 2);

                var findDomain = domains.Find(c => c.URL == String.Join("-", wordsChosen.ToArray()) + tlds[tldIndex]);

                if (findDomain == null)
                {
                    Domain newDomain = new Domain()
                    {
                        URL = String.Join("-", wordsChosen.ToArray()) + tlds[tldIndex],
                        Rating = 0
                    };

                    domains.Add(newDomain);
                }
            }

            return domains;
        }

        static public void WriteToFile(List<Domain> domains, string path)
        {
            try
            {
                var jsonList = JsonSerializer.Serialize(domains);
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(jsonList);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}

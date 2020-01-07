using DomainApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DomainApp.Logic
{
    public class DomainLogic
    {
        static public List<Domain> GetDomains(List<string> words, List<string> tlds)
        {
            List<Domain> domains = new List<Domain>();

            List<string> usedWords = new List<string>();

            for (int i = 0; i < 10; i++)
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

                Domain newDomain = new Domain()
                {
                    URL = String.Join("-", wordsChosen.ToArray()) + tlds[tldIndex],
                    Rating = 0
                };

                domains.Add(newDomain);
            }

            return domains;
        }

        static public void WriteToFile(List<Domain> domains, string path)
        {
            try
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    foreach (var domain in domains)
                    {
                        Console.WriteLine(domain.URL);
                        sw.WriteLine(domain.URL);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}

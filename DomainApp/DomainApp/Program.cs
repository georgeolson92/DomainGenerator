using DomainApp.Logic;
using System;
using System.Collections.Generic;
using System.IO;

namespace DomainApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> tlds = new List<string>()
            {
                ".com",
                ".net"
            };

            List<string> words = new List<string>();

            /*string answerToQuestion = "Y";

            while (answerToQuestion == "Y" || answerToQuestion == "y")
            {
                Console.WriteLine("Please enter in a word that can be used in your randomly generated domains.");
                var newWord = Console.ReadLine();
                words.Add(newWord);

                Console.WriteLine("Would you like to add another? Please answer 'Y' for yes or 'N' for no.");
                answerToQuestion = Console.ReadLine();
            }*/

            words = new List<string>()
            {
                "hawthorne",
                "gardening",
                "developer",
                "evaluation",
                "site",
                "planting",
                "miracle",
                "scott",
                "gro",
                "code",
                "portland",
                "vancouver"
            };

            var domains = DomainLogic.GetDomains(words, tlds);

            DomainLogic.WriteToFile(domains, "domains.json");
        }
    }
}

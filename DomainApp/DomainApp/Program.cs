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

            string answerToQuestion = "Y";

            while (answerToQuestion == "Y" || answerToQuestion == "y")
            {
                Console.WriteLine("Please enter in a word that can be used in your randomly generated domains.");
                var newWord = Console.ReadLine();
                words.Add(newWord);

                Console.WriteLine("Would you like to add another? Please answer 'Y' for yes or 'N' for no.");
                answerToQuestion = Console.ReadLine();
            }

            /*List<string> words = new List<string>()
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
                "code"
            };*/

            var domains = DomainLogic.GetDomains(words, tlds);

            Console.WriteLine("Please enter in the filepath for the text file you want the domains to be saved to.");

            string filePath = Console.ReadLine();
            if (!filePath.Contains(".txt"))
            {
                filePath = filePath + ".txt";
            }

            DomainLogic.WriteToFile(domains, filePath);
        }
    }
}

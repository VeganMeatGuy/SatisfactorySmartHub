using SatisfactoryCalculator.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactoryCalculator.Presentation
{
    internal class MainMenue
    {
        private RecipeMenue RecipeMenue;

        public MainMenue()
        {
            RecipeMenue = new RecipeMenue(this);
        }


        public void Start()
        {
            UpdateConsole([], string.Empty);

            while (true)
            {
                string Input = Console.ReadLine() ?? string.Empty;

                switch (Input)
                {
                    case "1":
                        Environment.Exit(0);
                        break;
                    case "2":
                        RecipeMenue.CallRecipeMenue();
                        break;
                    case "":
                        UpdateConsole([], $"Alter...geb doch was ein...");
                        break;
                    default:
                        UpdateConsole([], $"{Input} ist kein passender Befehl!");
                        break;
                }
            }
        }

        public void UpdateConsole(string[] p_LinesToWrite, string p_LastAction)
        {
            Console.Clear();
            if (p_LastAction == string.Empty)
            {
                p_LastAction = "Du hast die App erfolgreich gestartet :-)";
            }

            Console.WriteLine(p_LastAction);
            Console.WriteLine();

            Console.WriteLine("Menue | 1 Exit | 2 Rezepte");

            foreach (string line in p_LinesToWrite)
            {
                Console.WriteLine(line);
            }
        }
    }
}

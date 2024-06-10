using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactoryCalculator.Presentation
{
    internal class RecipeMenue(MainMenue p_mainMenue)
    {

        string LastAction = string.Empty;

        public void CallRecipeMenue()
        {
            List<string> list = new List<string>();

            list.Add("Rezepte | 1 Add");
            LastAction = "Rezept Menü geöffnet";
            p_mainMenue.UpdateConsole(list.ToArray(), LastAction);

            string Input = Console.ReadLine() ?? string.Empty;

            switch (Input)
            {
                case "1":
                    LastAction = $"Rezept hinzufügen ausgewählt";
                    ChooseRecipe();
                    break;
                case "":
                    p_mainMenue.UpdateConsole(list.ToArray(), $"Alter...geb doch was ein...");
                    break;
                default:
                    p_mainMenue.UpdateConsole(list.ToArray(), $"{Input} ist kein passender Befehl!");
                    break;
            }


            
        }

        public void ChooseRecipe()
        {
            List<string> list = new List<string>();
            list.Add("Rezepte | 1 Add");
            list.Add("Rezept hinzufügen");
            p_mainMenue.UpdateConsole(list.ToArray(), LastAction);

            string Input = Console.ReadLine() ?? string.Empty;

        }
    }
}

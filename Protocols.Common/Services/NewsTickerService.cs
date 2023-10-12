using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocols.Common.Services
{
    public class NewsTickerService
    {
        private static List<string> newsTickerData = new List<string>
    {
        "Local Man Discovers Coffee Cup That Never Empties",
        "Penguin Dance-Off Declared a Success; Winner Receives Ice Cream",
        "Scientists Prove That Cats Can Sleep Through Anything",
        "Unicorn Parade to Brighten Streets Next Saturday",
        "Local Bakery Offers Free Cupcakes for Smiles",
        "World's Tiniest Violin Stolen from Local Music Shop",
        "Town Mayor Declares Official 'No Pants Day'",
        "Breaking: Sock Missing from Laundry—Authorities on the Hunt",
        "Wombat Successfully Completes Rubik's Cube Puzzle",
        "Panda Refuses to Share Bamboo, Stages Sit-In Protest",
        "Giant Inflatable Rubber Duck Leads Parade Through City",
        "Squirrel Acrobatics Team Stuns Audiences in Park Performance",
        "Local Grandma Sets New World Record for Hugging Everyone in Town",
        "Breaking: Llama Named Official 'Therapist' of Local School",
        "Giraffe Escapes Zoo, Achieves Lifelong Dream of Becoming a Pilot",
        "Artist Paints Masterpiece Using Only Spaghetti and Meatballs",
        "Penguin Bartender Mixes Cocktails, Confuses Local Patrons",
        "Grumpy Cat Elected New Mayor in Surprise Upset",
        "New Study Reveals That Pizza Is Officially the Best Food Ever",
        "Breaking: Local Dogs Form Union, Demand More Belly Rubs"
    };

        public static string GetRandomNewsItem()
        {
            Random random = new Random();
            int index = random.Next(newsTickerData.Count);
            return newsTickerData[index];
        }

        public static List<string> GetAllNews() 
        {
            return newsTickerData;
        }
    }
}

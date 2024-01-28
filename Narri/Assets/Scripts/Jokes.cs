using System.Collections.Generic;

namespace DefaultNamespace
{
    public static class Jokes
    {
        public static List<string> JokeList = new List<string>()
        {
            "Mustanaamio meni nakkikioskille ja tilasi lihapiirakan. Myyjä kysyi, tuleeko kaikki mausteet? Mustanaamio vastaa: Ei.",
            "Montako ohjelmoijaa vaatii tekemään pelin 48 tunnissa? Ainakin yli kaksi!"
        };

        public static IList<Dictionary<string, string[]>> WordFailAlternatives { get; set; } =
            new List<Dictionary<string, string[]>>
            {
                new()
                {
                    { "mustanaamio", new string[] { "Chuck Norris", "Donald Trump" } },
                    { "meni", new string[] { "ajoi", "lensi", "oksensi" } },
                    { "nakkikioskille", new string[] { "Prismaan", "asd2", "asd3" } },
                    { "tilasi", new string[] { "varasti", "nyysi", "taikoi" } },
                    { "lihapiirakan", new string[] { "pihaliirakan", "tietokoneen", "" } },
                    { "myyjä", new string[] { "varasti", "nyysi", "taikoi" } },
                },
                new()
                {
                    { "ohjelmoijaa", new string[] { "nörttiä" } },
                    { "ohjelmoida", new string[] { "spagettikoodata", "oksentaa" } },
                    { "peli", new string[] { "bugi" } },
                    { "tunnissa", new string[] { "kuukaudessa", "vuodessa","valovuodessa" } },
                    { "kaksi", new string[] { "2.3", "NULL" } },
                }
            };
    }
}
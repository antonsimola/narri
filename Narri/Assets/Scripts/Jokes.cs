using System.Collections.Generic;

namespace DefaultNamespace
{
    public static class Jokes
    {
        public static List<string> JokeList = new List<string>()
        {
            "Mustanaamio meni nakkikioskille ja tilasi lihapiirakan. Myyjä kysyi, tuleeko kaikki mausteet? Mustanaamio vastaa: Ei.",
            "Montako ohjelmoijaa vaatii tekemään pelin 48 tunnissa? Ainakin yli kaksi!",
            "Why astronauts are using Linux systems, because they cant open windows",
            "Why do java programmers use glasses, because they cant see sharp",
            "Miksi sukeltajat kaatuvat takaperin veneestä? Jos ne kaatuisi etuperin, niin ne olisi vielä veneessä"
        };

        public static IList<Dictionary<string, string[]>> WordFailAlternatives { get; set; } =
            new List<Dictionary<string, string[]>>
            {
                new()
                {
                    { "mustanaamio", new string[] { "Chuck Norris", "Donald Trump" } },
                    { "meni", new string[] { "ajoi", "lensi", "oksensi" } },
                    { "nakkikioskille", new string[] { "Prismaan", "Lontooseen", "saunaan" } },
                    { "tilasi", new string[] { "varasti", "nyysi", "taikoi" } },
                    { "lihapiirakan", new string[] { "pihaliirakan", "tietokoneen" } },
                    { "myyjä", new string[] { "varasti", "nyysi", "taikoi" } },
                },
                new()
                {
                    { "ohjelmoijaa", new string[] { "nörttiä" } },
                    { "ohjelmoida", new string[] { "spagettikoodata", "oksentaa" } },
                    { "peli", new string[] { "bugi" } },
                    { "tunnissa", new string[] { "kuukaudessa", "vuodessa","valovuodessa" } },
                    { "kaksi", new string[] { "2.3", "NULL" } },
                },
                new()
                {
                    { "astronauts", new string[] { "cosmonauts", "divers" } },
                    { "Linux", new string[] { "javascript" } },
                    { "windows", new string[] { "windows without tek support" } },
                },
                 new()
                {
                    { "java", new string[] { "javascript", "assembly" } },
                },
                new()
                {
                    { "sukeltajat", new string[] { "kalastajat", "kalat", } },
                    { "kaatuvat", new string[] { "hyppäävät", "liukuvat", } },
                    { "veneestä", new string[] { "lentokoneesta", "autosta","junasta" } },
                    { "veneessä", new string[] { "lentokoneessa", "autossa","junassa" } },
                }
            };
    }
}
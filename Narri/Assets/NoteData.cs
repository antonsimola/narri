using System.Collections.Generic;

namespace DefaultNamespace
{
    public class NoteData
    {
        public string Note { get; set; } // e3

        public int Key { get; set; } = 0; // 0,1,2,3,4 ghjkl
        public float StartTime { get; set; }
    }

    public class Song
    {
        public float Tempo { get; set; }
        public IList<NoteData> Notes { get; set; } = new List<NoteData>();
    }
}
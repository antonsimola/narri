using System.Collections.Generic;

namespace DefaultNamespace
{
    public  static class Songs
    {
        public static IList<Song> SongList = new List<Song>()
        {
            new Song()
            {
                Name = "Russian folksong part 1",
                Notes = new List<NoteData>()
                {
                    new NoteData() { Note = "e3", StartTime = 0, Key = 4 },
                    new NoteData() { Note = "b2", StartTime = 1, Key = 1 },
                    new NoteData() { Note = "c3", StartTime = 1.5f, Key = 2 },
                    new NoteData() { Note = "d3", StartTime = 2, Key = 3 },

                    new NoteData() { Note = "c3", StartTime = 2.5f, Key = 2 },
                    new NoteData() { Note = "b2", StartTime = 3.0f, Key = 1 },
                    new NoteData() { Note = "a2", StartTime = 3.5f, Key = 0 },

                    new NoteData() { Note = "a2", StartTime = 4.5f, Key = 0 },
                    new NoteData() { Note = "c3", StartTime = 5.0f, Key = 2 },
                    new NoteData() { Note = "e3", StartTime = 5.5f, Key = 4 },
                }
            },
            new Song()
            {
                Name = "Russian folksong part 2",
                Notes = new List<NoteData>()
                {
                    new NoteData() { Note = "e3", StartTime = 0, Key = 4 },
                    new NoteData() { Note = "d3", StartTime = 0.5f, Key = 3 },
                    new NoteData() { Note = "c3", StartTime = 1.0f, Key = 2 },
                    new NoteData() { Note = "b2", StartTime = 1.5f, Key = 1 },

                    new NoteData() { Note = "b2", StartTime = 2.5f, Key = 1 },
                    new NoteData() { Note = "c3", StartTime = 3.0f, Key = 2 },
                    new NoteData() { Note = "d3", StartTime = 3.5f, Key = 3 },
                    new NoteData() { Note = "e3", StartTime = 4.0f, Key = 4 },

                    new NoteData() { Note = "c3", StartTime = 4.5f, Key = 2 },
                    new NoteData() { Note = "a2", StartTime = 5.0f, Key = 0 },
                    new NoteData() { Note = "a2", StartTime = 6.0f, Key = 0 },
                }
            },
            new Song()
            {
                Name = "Ukko nooa part 1",
                Notes = new List<NoteData>()
                {
                    new NoteData() { Note = "c3", StartTime = 0, Key = 1 },
                    new NoteData() { Note = "c3", StartTime = 1, Key = 1 },
                    new NoteData() { Note = "c3", StartTime = 2, Key = 1 },
                    new NoteData() { Note = "e3", StartTime = 3, Key = 3 },
                    
                    new NoteData() { Note = "d3", StartTime = 4, Key = 2 },
                    new NoteData() { Note = "d3", StartTime = 5, Key = 2 },
                    new NoteData() { Note = "d3", StartTime = 6, Key = 2 },
                    new NoteData() { Note = "f3", StartTime = 7, Key = 4 },
                    
                    new NoteData() { Note = "e3", StartTime = 8, Key = 3 },
                    new NoteData() { Note = "e3", StartTime = 9, Key = 3 },
                    new NoteData() { Note = "d3", StartTime = 10, Key = 2 },
                    new NoteData() { Note = "d3", StartTime = 11, Key = 2 },
                    new NoteData() { Note = "c3", StartTime = 12, Key = 1 },
                    
                    
                }
            },
            new Song()
            {
                Name = "Ukko nooa part 2",
                Notes = new List<NoteData>()
                {
                    new NoteData() { Note = "e3", StartTime = 0, Key = 1 },
                    new NoteData() { Note = "e3", StartTime = 0.5f, Key = 1 },
                    new NoteData() { Note = "e3", StartTime = 1.0f, Key = 1 },
                    new NoteData() { Note = "e3", StartTime = 1.5f, Key = 1 },
                    
                    new NoteData() { Note = "g3", StartTime = 2.0f, Key = 4 },
                    new NoteData() { Note = "f3", StartTime = 3.0f, Key = 3 },
                    
                    new NoteData() { Note = "d3", StartTime = 4.0f, Key = 0 },
                    new NoteData() { Note = "d3", StartTime = 4.5f, Key = 0 },
                    new NoteData() { Note = "d3", StartTime = 5.0f, Key = 0 },
                    new NoteData() { Note = "d3", StartTime = 5.5f, Key = 0 },
                    
                    new NoteData() { Note = "f3", StartTime = 6.0f, Key = 3 },
                    new NoteData() { Note = "e3", StartTime = 7.0f, Key = 2 },
                }
            }
        };
        
        
    }
}
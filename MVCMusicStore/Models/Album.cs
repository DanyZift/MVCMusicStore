using System;
namespace MVCMusicStore.Models
{
    public class Album
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Rating { get; set; }
    }
}

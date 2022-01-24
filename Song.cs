using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JakubToma_utwory
{
    class Song
    {
        public string songTitle { get; set; }
        public string songAlbum { get; set; }
        public string songArtist { get; set; }
        public string songGenre { get; set; }


        public Song() { }

        public Song(string songTitle, string songAlbum, string songArtist, string songGenre)
        {

            this.songTitle = songTitle;
            this.songAlbum = songAlbum;
            this.songArtist = songArtist;
            this.songGenre = songGenre;
        }

        public Song(Song song)
        {
            this.songTitle = song.songTitle;
            this.songAlbum = song.songAlbum;
            this.songArtist = song.songArtist;
            this.songGenre = song.songGenre;

        }

        
    }
}

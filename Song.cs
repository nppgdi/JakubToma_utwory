using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Drawing;
using System.IO;

namespace JakubToma_utwory
{
    class Song
    {
        public int songId { get; set; }
        public string songTitle { get; set; }
        public string songAlbum { get; set; }
        public string songArtist { get; set; }
        public string songGenre { get; set; }
        public string imagePath { get; set; }
        public byte[] imageToByte { get; set; }
        
        public Song() { }

        public Song(int songId, string songTitle, string songAlbum, string songArtist, string songGenre)
        {

            this.songId = songId;
            this.songTitle = songTitle;
            this.songAlbum = songAlbum;
            this.songArtist = songArtist;
            this.songGenre = songGenre;


        }

        public Song(Song song)
        {
            this.songId = song.songId;
            this.songTitle = song.songTitle;
            this.songAlbum = song.songAlbum;
            this.songArtist = song.songArtist;
            this.songGenre = song.songGenre;

        }

        public static List<Song> ListSongs = new List<Song>();

    }
}

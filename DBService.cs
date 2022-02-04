using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data;
using System.Data.SqlClient;
using System.IO;


namespace JakubToma_utwory
{
    class DBService
    {

        private static string connString = @"Data Source = PC-1\SQLEXPRESS; Initial Catalog = songdb; Trusted_Connection=True";
        SqlConnection cnn = new SqlConnection(connString);
                                
        public DBService()
        {
        
        }

       public void DbLoad(DataGrid dataGrid)
        {

            SqlCommand cm = new SqlCommand("SELECT * FROM song;", cnn);
            DataTable dt = new DataTable();
            cnn.Open();

            try
            {
                SqlDataReader dr = cm.ExecuteReader();
                dt.Load(dr);
                dataGrid.ItemsSource = dt.DefaultView;
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Połączenie nie powiodło się \n"+ ex.Message);
            }

        }

        public void DbInsert(TextBox title, TextBox artist, TextBox album, string genre, string img)
        {
            cnn.Open();
            Song song = new Song();
            byte[] imgFile = song.imageToByte = File.ReadAllBytes(img);
            SqlCommand cm = new SqlCommand("INSERT INTO song (song_title, song_artist, song_album, song_genre, song_img, song_img_byte) VALUES (@song_title, @song_artist, @song_album, @song_genre, @song_img, @song_img_byte)", cnn);
            cm.CommandType = CommandType.Text;
            cm.Parameters.AddWithValue("@song_title", title.Text);
            cm.Parameters.AddWithValue("@song_artist", artist.Text);
            cm.Parameters.AddWithValue("@song_album", album.Text);
            cm.Parameters.AddWithValue("@song_genre", genre);
            cm.Parameters.AddWithValue("@song_img", img);
            cm.Parameters.AddWithValue("@song_img_byte", imgFile);

            try
            {
                cm.ExecuteNonQuery();
                cnn.Close();
                MessageBox.Show("Dodano do bazy danych!");
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Dodanie do bazy nie powiodło się!\n" + ex.Message);
            }
        }

        public void DbDelete(string id)
        {
            cnn.Open();
            SqlCommand cm = new SqlCommand("DELETE FROM song WHERE ID = @id", cnn);
            cm.Parameters.AddWithValue("@id", id);
            try
            {
                cm.ExecuteNonQuery();
                cnn.Close();
                MessageBox.Show("Usunięto rekord!");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Operacja nie powiodła się! \n" + ex.Message);
                cnn.Close();
            }
        }

        public void DbUpdate(string id, TextBox title, TextBox artist, TextBox album, string genre, string img)
        {
            cnn.Open();
            Song song = new Song();
            SqlCommand cm = new SqlCommand("UPDATE song SET song_title=@song_title, song_artist=@song_artist, song_album=@song_album, song_genre=@song_genre, song_img=@song_img, song_img_byte=@song_img_byte WHERE id=@id", cnn);
            byte[] imgFile = song.imageToByte = File.ReadAllBytes(img);
            cm.Parameters.AddWithValue("@id", id);
            cm.Parameters.AddWithValue("@song_title", title.Text);
            cm.Parameters.AddWithValue("@song_artist", artist.Text);
            cm.Parameters.AddWithValue("@song_album", album.Text);
            cm.Parameters.AddWithValue("@song_genre", genre);
            cm.Parameters.AddWithValue("@song_img", img);
            cm.Parameters.AddWithValue("@song_img_byte", imgFile); 
            try
            {
                cm.ExecuteNonQuery();
                MessageBox.Show("Zaktualizowano rekord!");
                cnn.Close();
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Operacja nie powiodła się! \n" + ex.Message);
                cnn.Close();
            }



        }

        public void DbGetGenres(ComboBox comboBox)
        {
            SqlCommand cm = new SqlCommand("SELECT * FROM genre;", cnn);
            DataTable dt = new DataTable();
            cnn.Open();
            SqlDataReader dr = cm.ExecuteReader();
            dt.Load(dr);
            comboBox.ItemsSource = dt.DefaultView;
            comboBox.DisplayMemberPath = "genre_name";
            comboBox.SelectedValuePath = "id";
            cnn.Close();
        }
    }
}

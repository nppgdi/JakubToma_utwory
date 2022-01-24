using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace JakubToma_utwory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Song> ListSongs = new List<Song>();
        public MainWindow()
        {
            InitializeComponent();

            ListSongs.Add(new Song("In The End", "Hybrid Theory", "Linkin Park", "Alternative"));

            SongsView.ItemsSource = ListSongs;
        }


        private void PropertiesClick(object sender, RoutedEventArgs e)
        {
            if (SongsView.SelectedItem != null)
            {
                Edit win = new Edit();
                Song song = new Song((Song)SongsView.SelectedItem);
                win.DataContext = song;
                win.ShowDialog();
                if (win.IsOkPressed)
                {
                    int i = ListSongs.IndexOf((Song)SongsView.SelectedItem);
                    ListSongs[i] = song;
                    SongsView.Items.Refresh();
                }
            }

        }
        private void AddClick(object sender, RoutedEventArgs e)
        {
            Add win2 = new Add();
            win2.ShowDialog();
        }

        private void ConnectClick(object sender, RoutedEventArgs e)
        {

            string connectionString;
            SqlConnection cnn;

            connectionString = @"Data Source= PC-2\SQLEXPRESS; Initial Catalog=songdb;
                                Trusted_Connection=True";

            cnn = new SqlConnection(connectionString);
            cnn.Open();
            MessageBox.Show("Połączono z bazą danych!");

            cnn.Close();
        }
    }

}

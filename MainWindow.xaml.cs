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
        public MainWindow()
        {
            InitializeComponent();

            editBtn.IsEnabled = false;
            DBService db = new DBService();
            db.DbLoad(SongsView);

        }


        private void PropertiesClick(object sender, RoutedEventArgs e)
        {
            if (SongsView.SelectedItem != null)
            {
                Edit win = new Edit();
                DBService db = new DBService();
                db.DbGetGenres(win.genreBox);
                string id = ((DataRowView)SongsView.SelectedItem).Row["id"].ToString();
                win.DataContext = SongsView.SelectedItem;
                win.ShowDialog();
                if (win.IsOkPressed)
                {
                    db.DbUpdate(id, win.title, win.artist, win.album, win.genreBox.Text, win.filePath.Text);
                    db.DbLoad(SongsView);
                }
            }

        }
        private void AddClick(object sender, RoutedEventArgs e)
        {
            Edit win = new Edit();
            DBService db = new DBService();
            db.DbGetGenres(win.genreBox);

            win.DataContext = SongsView;
            win.ShowDialog();
            if (win.IsOkPressed)
            {
                db.DbInsert(win.title, win.artist, win.album, win.genreBox.Text, win.filePath.Text);
                db.DbLoad(SongsView);
            }
        }
        
        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            string id = ((DataRowView)SongsView.SelectedItem).Row["id"].ToString();
            DBService db = new DBService();
            db.DbDelete(id);
            db.DbLoad(SongsView);
        }

        private void ReportClick(object sender, RoutedEventArgs e)
        {
            Report win = new Report();
            win.ShowDialog();
        }

        private void GithubClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/nppgdi/JakubToma_utwory");
        }


        private void SongsView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            editBtn.IsEnabled = true;
        }
    }

}

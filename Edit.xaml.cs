using System;
using Microsoft.Win32;
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
using System.Windows.Shapes;
using System.IO;


namespace JakubToma_utwory
{
    public partial class Edit : Window
    {
        public bool IsOkPressed { get; set; }
        public Edit()
        {
            InitializeComponent();
        }

        private void OkClick(object sender, RoutedEventArgs e)
        {
            IsOkPressed = true;
            this.Close();
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            IsOkPressed = false;
            this.Close();
        }

        private void BrowseImg(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();
            filePath.Text = dialog.FileName;
            ImageSource imgSrc = new BitmapImage(new Uri(filePath.Text));
            imageBox.Source = imgSrc;
        }
    }
}

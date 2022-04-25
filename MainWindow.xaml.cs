using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

namespace XvsO_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool CurrentValue;
        public MainWindow()
        {
            InitializeComponent();
            CurrentValue = true;
            ResetUid();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (CurrentValue == true)
                {
                    button.Content = Resources["X"];
                    CurrentValue = false;
                    button.IsEnabled = false;
                    button.Uid = "X";
                }
                else if (CurrentValue == false)
                {
                    button.Content = Resources["O"];
                    CurrentValue = true;
                    button.IsEnabled = false;
                    button.Uid = "O";
                }
                if (CheckWin())
                {
                    MessageBox.Show($"Победитель {button.Uid}");
                    MainWindow mw = new MainWindow();
                    mw.Show();
                    Close();
                }
            }
        }
        private bool CheckWin()
        {
            if ((B1.Uid == B2.Uid && B1.Uid == B3.Uid) || (B1.Uid == B4.Uid && B1.Uid == B7.Uid) || (B1.Uid == B5.Uid && B1.Uid == B9.Uid))
                return true;
            else if (B4.Uid == B5.Uid && B4.Uid == B6.Uid)
                return true;
            else if ((B7.Uid == B8.Uid && B7.Uid == B9.Uid) || (B7.Uid == B5.Uid && B7.Uid == B3.Uid))
                return true;
            else if (B2.Uid == B5.Uid && B2.Uid == B8.Uid)
                return true;
            else if (B3.Uid == B6.Uid && B3.Uid == B9.Uid)
                return true;

            return false;
        }
        private void ResetUid()
        {
            for (int i = 0; i < 9; i++)
            {
                Grid.Children[i].Uid = (i + 1).ToString();
            }
           
        }
    }
}

using System;
using System.Data;
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

namespace Test
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach(UIElement elem in MainRoot.Children)
            {
                if (elem is Button)
                {
                    ((Button)elem).Click += Button_Click;
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = (String)((Button)e.OriginalSource).Content;
            if (str == "AC")
                TextLabel.Text = "";
            else if (str == "=")
            {
                string value = new DataTable().Compute(TextLabel.Text, null).ToString();
                TextLabel.Text = value;
            }
            else if (str == "Стереть")
            {
                TextLabel.Text = TextLabel.Text.Substring(0, TextLabel.Text.Length-1);
            }
            else if (str == "Выход")
            {
                Close();
            }
            else
                TextLabel.Text += str;
        }
    }
}

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
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace CSharpLB6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            using(HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("http://localhost:5161/stock");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    var list = await response.Content.ReadAsStringAsync();

                    

                    test.Content = list;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
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

namespace WpfApPract1
{
    public partial class MainWindow : Window
    {
        static private string? peremennaia;
        static private List<Button> knopki = new List<Button> {};
        List<string> vibr = new List<string>() { "крестики", "нолики" };

        public MainWindow()
        {
            InitializeComponent(); 
            knopki.Add(k1);
            knopki.Add(k2);
            knopki.Add(k3);
            knopki.Add(k4);
            knopki.Add(k5);
            knopki.Add(k6);
            knopki.Add(k7);
            knopki.Add(k8);
            knopki.Add(k9);
            foreach (Button button in knopki)
                button.IsEnabled = false;
            Vibor.ItemsSource = vibr;
            Snova.IsEnabled = false;
        }

        private void Bot()
        {
            string bot;
            if (peremennaia == "крестики") bot = "нолики";
            else bot = "крестики";
            List<Button> botic = new List<Button>() { };
            foreach (Button button in knopki)
            { 
                if (button.IsEnabled)
                    botic.Add(button);
            }
            if (botic.Count == 0) { MessageBox.Show("Поля закончились. Ничья!"); Thread.Sleep(100); Otchistka(); }
            else
            {
                Random random = new Random();
                int index = random.Next(botic.Count);
                botic[index].Content = bot;
                botic[index].Foreground = Brushes.DarkBlue;
                botic[index].IsEnabled = false;
                if (non_finish() != "") { MessageBox.Show("Выиграли " + non_finish()); Thread.Sleep(100); Otchistka(); }
            }
        }
        private void Otchistka() 
        {
            if (peremennaia == "крестики") peremennaia = "нолики";
            else peremennaia = "крестики";
            Vibor.Text = peremennaia;
            foreach (Button button in knopki)
            { button.IsEnabled = true; button.Content = "-"; }
        }
        private void k_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).Content = peremennaia;
            (sender as Button).Foreground = Brushes.Red;
            (sender as Button).IsEnabled = false;
            Snova.IsEnabled = true;
            if (non_finish() == "") Bot();
            else { MessageBox.Show("Выиграли " + non_finish()); Thread.Sleep(100); Otchistka(); }
        }
        private string non_finish()
        {
            if ((k1.Content == k2.Content) && (k2.Content == k3.Content) && (k3.Content != "-")) return k3.Content.ToString();
            else if ((k4.Content == k5.Content) && (k5.Content == k6.Content) && (k6.Content != "-")) return k6.Content.ToString();
            else if ((k1.Content == k4.Content) && (k4.Content == k7.Content) && (k7.Content != "-")) return k7.Content.ToString();
            else if ((k2.Content == k5.Content) && (k5.Content == k8.Content) && (k8.Content != "-")) return k8.Content.ToString();
            else if ((k3.Content == k6.Content) && (k6.Content == k9.Content) && (k9.Content != "-")) return k9.Content.ToString();
            else if ((k7.Content == k8.Content) && (k8.Content == k9.Content) && (k9.Content != "-")) return k9.Content.ToString();
            else if ((k1.Content == k5.Content) && (k5.Content == k9.Content) && (k9.Content != "-")) return k9.Content.ToString();
            else if ((k3.Content == k5.Content) && (k5.Content == k7.Content) && (k7.Content != "-")) return k7.Content.ToString();
            else return "";
        }

        private void Vibor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selected = Vibor.SelectedItem as string;
            if (selected != null)
            {
                Vibor.IsEnabled = false;
                foreach (Button button in knopki)
                    button.IsEnabled = true;
            }
            if (selected == "крестики") peremennaia = "крестики";
            else peremennaia = "нолики";
            
            // @bkrot
        }

        private void Snova_Click(object sender, RoutedEventArgs e)
        {
            Otchistka();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Игра окончена!\nОставь отзыв на моей страничке в ClassRoom");
            foreach (Button button in knopki)
                button.IsEnabled = false;
            Snova.IsEnabled = false;
            Vibor.IsEnabled = false;
            Konec.IsEnabled = false;
            Thread.Sleep(1000);
            Close();
        }
    }
}

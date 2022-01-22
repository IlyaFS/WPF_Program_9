using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

namespace WPF_Program_9
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var uri = new Uri("Dark.xaml", UriKind.Relative);
            ResourceDictionary resource = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resource);

        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string fontName = ((sender as ComboBox).SelectedItem as string);
            if (textBox != null) textBox.FontFamily = new FontFamily();
        }
        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            string fontSize = ((sender as ComboBox).SelectedItem as string);
            if (fontSize == "12") textBox.FontSize = 12;
            else if (fontSize == "14") textBox.FontSize = 14;
            else if (textBox != null) textBox.FontSize = 16;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.FontWeight == FontWeights.Normal) textBox.FontWeight = FontWeights.Bold;
            else textBox.FontWeight = FontWeights.Normal;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (textBox.FontStyle == FontStyles.Normal) textBox.FontStyle = FontStyles.Italic;
            else textBox.FontStyle = FontStyles.Normal;
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (textBox.TextDecorations == TextDecorations.Underline) textBox.TextDecorations = null;
            else textBox.TextDecorations = TextDecorations.Underline;
        }
        private void ColorRed_Checked(object sender, RoutedEventArgs e)
        {
            textBox.Foreground = new SolidColorBrush(Colors.Red);
        }
        private void ColorBlack_Checked(object sender, RoutedEventArgs e)
        {
            if (textBox != null) textBox.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void OpenEx(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt, *.doc)|*.txt;*.doc|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                textBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void SaveEx(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt, *.doc)|*.txt;*.doc|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, textBox.Text);
            }
        }

        private void CloseEx(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void DarkEx(object sender, ExecutedRoutedEventArgs e)
        {
            var uri = new Uri("Dark.xaml", UriKind.Relative);
            ResourceDictionary resource = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resource);
        }

        private void WhiteEx(object sender, ExecutedRoutedEventArgs e)
        {
            var uri = new Uri("White.xaml", UriKind.Relative);
            ResourceDictionary resource = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resource);
        }
    }
}

using Panuon.WPF;
using Panuon.WPF.UI;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Objection_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        string imgSource, audioSource;
        public MainWindow()
        {
            InitializeComponent();
            img.Visibility = Visibility.Hidden;
            langCombo.SelectedIndex = 2;
        }

        private void langCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch(langCombo.SelectedIndex)
            {
                case 0:
                    objection_.Content = "异议！";
                    break;
                case 1:
                    objection_.Content = "異議あり！";
                    break;
                case 2:
                    objection_.Content = "Objection!";
                    break;
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            
            switch (langCombo.SelectedIndex)
            {
                case 0:
                    audioSource = "C:\\Program Files (x86)\\Half-Auto OBJECTION!\\Objection! 文件\\zh.mp3";
                    imgSource = "C:\\Program Files (x86)\\Half-Auto OBJECTION!\\Objection! 文件\\zh.png";
                    break;
                case 1:
                    audioSource = "C:\\Program Files (x86)\\Half-Auto OBJECTION!\\Objection! 文件\\ja.mp3";
                    imgSource = "C:\\Program Files (x86)\\Half-Auto OBJECTION!\\Objection! 文件\\ja.png";
                    break;
                case 2:
                    audioSource = "C:\\Program Files (x86)\\Half-Auto OBJECTION!\\Objection! 文件\\en.mp3";
                    imgSource = "C:\\Program Files (x86)\\Half-Auto OBJECTION!\\Objection! 文件\\en.png";
                    break;
            }
            if (imgText.Text != string.Empty)
            {
                imgSource = imgText.Text;
            }
            if (audioText.Text != string.Empty)
            {
                audioSource = audioText.Text;
            }
            try
            {
                mediaElement.Volume = volume.Value;
                mediaElement.Position = TimeSpan.Zero;
                mediaElement.Source = new Uri(Convert.ToString(audioSource));
                mediaElement.Play();
                img.Source = new BitmapImage(new Uri(Convert.ToString(imgSource)));
                img.Visibility = Visibility.Visible;
                await Task.Delay(1000);
                img.Visibility = Visibility.Hidden;
            }
            catch
            {
                if (urlAuto.IsChecked == true)
                {
                    string[] a = new string[3] { "http://", "https://", "" };
                    bool succeed = false;
                    for (int i = 0; i <= 2; i++)
                    {
                        for (int j = 0; i <= 2; i++)
                        {
                            try
                            {
                                mediaElement.Volume = volume.Value;
                                mediaElement.Position = TimeSpan.Zero;
                                mediaElement.Source = new Uri(a[i] + Convert.ToString(audioSource));
                                mediaElement.Play();
                                img.Source = new BitmapImage(new Uri(a[j] + Convert.ToString(imgSource)));
                                img.Visibility = Visibility.Visible;
                                await Task.Delay(1000);
                                img.Visibility = Visibility.Hidden;
                                succeed = true;
                                break;
                            }
                            catch
                            {
                                succeed = false;
                            }
                        }
                    }
                    if (succeed == false)
                    {
                        MessageBoxX.Show("自定义路径错误，\n请先按照说明解压，\n如果链接是URL，请检查格式！", "无法异议", MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBoxX.Show("自定义路径错误，\n请先按照说明解压，\n如果链接是URL，请不要忘记前缀", "无法异议", MessageBoxIcon.Error);
                }
            }
        }
    }
}
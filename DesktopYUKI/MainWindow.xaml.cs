using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Threading;

namespace DesktopYUKI {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            chatwindow = new ChatWindow();
            chatwindow.Show();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5.0);
            timer.Tick += timer_Tick;
            timer.Start();
        }
        DispatcherTimer timer;
        ChatWindow chatwindow;

        int count = 0;
        void timer_Tick(object sender, EventArgs e) {
            count++;
            if (count == 1) {
                chatwindow.DisplayMessage("ぬるぽ");
            } else {
                count = 0;
                chatwindow.DisplayMessage("ガッ！！");
            }
        }

        protected override void OnClosing(CancelEventArgs e) {
            base.OnClosing(e);
            if(chatwindow != null) {
                chatwindow.Close();
            }
        }

        // Clickした時の動作
        private void Quit_Clicked(object sender, RoutedEventArgs e) {
            Close();
        }

        // 掴める機能の追加
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e) {

            base.OnMouseLeftButtonDown(e);
            DragMove();
        }
    }
}

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
using System.Windows.Shapes;

namespace DesktopYUKI {
    /// <summary>
    /// ChatWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class ChatWindow : Window {
        public ChatWindow() {
            InitializeComponent();
        }

        // 台詞の表示
        public void DisplayMessage(string message) {
            Dispatcher.Invoke(() => this.ChatField.Text = message);
        }

        // 台詞の消去
        public void ClearMessage() {
            DisplayMessage(string.Empty);
        }
    }
}

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
using System.Windows.Threading;
using System.Runtime.InteropServices;
using System.Windows.Interop;

namespace DesktopYUKI {
    /// <summary>
    /// ChatWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class ChatWindow : Window {

		public ChatWindow()	{
			InitializeComponent();
		}

		// 台詞の表示
		public void DisplayMessage(string message)	{
			Dispatcher.Invoke(() => this.ChatField.Text = message);
		}

		// 台詞の消去
		public void ClearMessage()	{
			DisplayMessage(string.Empty);
		}

		//--------------------------------
		private DispatcherTimer dispatcherTimer = new DispatcherTimer();
		private IntPtr hwndThis;

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			dispatcherTimer.Interval = new TimeSpan(200000);    // 100ナノ秒単位で指定
			dispatcherTimer.Tick += dispatcherTimer_Tick;
			dispatcherTimer.Start();

			// Windowクラスのプロパティにウィンドウハンドルがないので取得して覚えておく
			var hwndSource = HwndSource.FromVisual(this) as HwndSource;
			hwndThis = hwndSource.Handle;
		}


		private void dispatcherTimer_Tick(object sender, EventArgs e)
		{
			IntPtr hwnd = GetForegroundWindow();
			if (hwnd == hwndThis)    // 自分自身への追従はしない
				return;

			RECT rect = new RECT();
			GetWindowRect(hwnd, ref rect);
			this.Left = rect.left;
			this.Top = rect.top - this.Height;
		}

		[DllImport("user32.dll")]
		private static extern IntPtr GetForegroundWindow();

		struct RECT {
			public int left;
			public int top;
			public int right;
			public int bottom;
		}

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);
		//---------------------------------------------------------------------------
	}
}

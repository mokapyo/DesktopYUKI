﻿using System;
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
using System.Drawing;

namespace DesktopYUKI {

    public partial class MainWindow : Window {
		BitmapImage m_MainImage = null;

		public MainWindow() {
            InitializeComponent();

            chatwindow = new ChatWindow();
            chatwindow.Show();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(3.0);
            timer.Tick += timer_Tick;
            timer.Start();
        }
        DispatcherTimer timer;
        ChatWindow chatwindow;

		// 通常時は踊らせておく
        int count = 0;
        void timer_Tick(object sender, EventArgs e) {
            count++;
			m_MainImage = new BitmapImage();
			m_MainImage.BeginInit();
			if (count == 1) {
				m_MainImage.UriSource = new Uri("/pict/He.png", UriKind.Relative);
				chatwindow.DisplayMessage("ぬるぽ");
            } else {
                count = 0;
				m_MainImage.UriSource = new Uri("/pict/He2.png", UriKind.Relative);
				chatwindow.DisplayMessage("ガッ！！");
            }
			m_MainImage.EndInit();
			MainImage.Source = m_MainImage;
		}

		// 終了時処理
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
			chatwindow.Hide();
			base.OnMouseLeftButtonDown(e);
			timer.Stop();
			m_MainImage = new BitmapImage();
			m_MainImage.BeginInit();
			m_MainImage.UriSource = new Uri("/pict/Drag.png", UriKind.Relative);
			m_MainImage.EndInit();
			MainImage.Source = m_MainImage;
            DragMove();
        }

		protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
		{
			chatwindow.Show();
			base.OnMouseLeftButtonUp(e);
			timer.Start();
			m_MainImage = new BitmapImage();
			m_MainImage.BeginInit();
			m_MainImage.UriSource = new Uri("/pict/He.png", UriKind.Relative);
			m_MainImage.EndInit();
			MainImage.Source = m_MainImage;
		}
	}
}

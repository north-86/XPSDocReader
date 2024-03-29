﻿using Microsoft.Win32;
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
using System.Windows.Xps;
using System.Windows.Xps.Packaging;

namespace XPSDocReader
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XPS Files (*.xps)|*.xps";
            if (openFileDialog.ShowDialog() == true)
            {
                XpsDocument doc = new XpsDocument(openFileDialog.FileName, FileAccess.Read);
                docViewer.Document = doc.GetFixedDocumentSequence();
                tbstatusBar2.Text = openFileDialog.FileName;
                tbstatusBar3.Text = "Pages:  " + docViewer.PageCount.ToString();
                doc.Close();
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            docViewer.Document = null;
            tbstatusBar2.Text = null;
            tbstatusBar3.Text = null;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            var url = "https://github.com/northernman86/XPSDocReader";
            var info = new ProcessStartInfo(url)
            {
                UseShellExecute = true,
            };
            Process.Start(info);
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            About about = new About();
            about.Owner = this;
            about.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tbstatusBar.Text = "In Action";
        }
    }
}

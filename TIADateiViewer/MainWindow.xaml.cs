using Microsoft.Win32;
using System;
using System.Windows;

namespace TIADateiViewer
{
    public partial class MainWindow : Window
    {

        Backend backend;

        public MainWindow()
        {
            InitializeComponent();
            this.backend = new TiaDateiViewerBackend();
        }

        public void openTiaFile(Object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "TIA Files (*.tia)|*.tia|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                var a = openFileDialog.FileName;
            }
        }

    }

}

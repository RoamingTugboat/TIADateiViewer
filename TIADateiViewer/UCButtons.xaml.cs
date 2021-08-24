using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace TIADateiViewer
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UCButtons : UserControl
    {
        public UCButtons()
        {
            InitializeComponent();
        }

        public void buttonClicked(Object sender, RoutedEventArgs e)
        {
            openTiaFile(sender, e);
        }

        public void openTiaFile(Object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "TIA Files (*.tia)|*.tia|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {

            }
        }

    }

}

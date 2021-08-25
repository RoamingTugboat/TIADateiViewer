using Microsoft.Win32;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

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

        public void openTiaFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "TIA Files (*.tia)|*.tia|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                var tiaFilePath = openFileDialog.FileName;
                backend.openTiaFile(tiaFilePath);
                this.Title = tiaFilePath;
            }

            if (!backend.isValidFileOpen()) {
                return;
            }
            generateNodeSelection(backend.getNodes());

        }

        void generateNodeSelection(Dictionary<string, List<node>> nodeDict)
        {
            viewTopPanel.Children.Clear();
            foreach(var entry in nodeDict)
            {
                viewTopPanel.Children.Add(new Label() { Content = $"{entry.Key} ({entry.Value.Count})" });
            }
        }
        
    }

}

using Microsoft.Win32;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace TIADateiViewer
{
    public partial class MainWindow : Window
    {

        Backend backend;
        Dictionary<string, List<node>> nodeDict;
        readonly string WindowTitle = "TIA Selection Tool - Datei-Viewer";

        public MainWindow()
        {
            InitializeComponent();
            this.backend = new TiaDateiViewerBackend();
            this.Title = WindowTitle;
        }

        public void openTiaFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "TIA Files (*.tia)|*.tia|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                var tiaFilePath = openFileDialog.FileName;
                backend.openTiaFile(tiaFilePath);
                this.Title = $"{WindowTitle} - \"{tiaFilePath}\"";
            }

            if (!backend.isValidFileOpen())
            {
                return;
            }
            this.nodeDict = backend.getTiaNodesDictionary();
            refreshTopPanel();
        }

        void refreshTopPanel()
        {
            viewTopPanel.Children.Clear();
            foreach (var entry in this.nodeDict)
            {
                var dictButton = new TypeSelectorButton();
                dictButton.TypeName = entry.Key;
                dictButton.Content = $"{entry.Key} ({entry.Value.Count})";
                dictButton.Click += typeSelectorButtonClicked;

                viewTopPanel.Children.Add(dictButton);
            }
        }

        void typeSelectorButtonClicked(object sender, RoutedEventArgs e)
        {
            if (!(sender is TypeSelectorButton))
            {
                return;
            }
            var dictTypeName = ((TypeSelectorButton)sender).TypeName;
            refreshMainPanel(dictTypeName);
        }

        void refreshMainPanel(string dictTypeName)
        {
            listBox.Items.Clear();
            foreach (var node in this.nodeDict[dictTypeName])
            {
                var nodeNameOrIdentifierProperty = node.properties.FirstOrDefault(e => e.key.Equals("Name"));
                if (nodeNameOrIdentifierProperty == null)
                {
                    nodeNameOrIdentifierProperty = node.properties.FirstOrDefault(e => e.key.Equals("Id"));
                }
                listBox.Items.Add(new ListBoxItem() { Content = $"{nodeNameOrIdentifierProperty.value}\t|Eigenschaften:{node.properties.Count}" });
            }
        }


    }
}

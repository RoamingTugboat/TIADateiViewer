using Microsoft.Win32;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using System;

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
                try
                {
                    var tiaFilePath = openFileDialog.FileName;
                    backend.openTiaFile(tiaFilePath);
                    this.Title = $"{WindowTitle} - \"{tiaFilePath}\"";
                } catch(InvalidOperationException ex)
                {
                    MessageBox.Show("Ungueltiges Dateiformat. Das Programm kann nur valide .tia-Dateien einlesen.");
                }
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
            if(this.nodeDict == null)
            {
                return;
            }
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
            if (this.nodeDict == null)
            {
                return;
            }
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

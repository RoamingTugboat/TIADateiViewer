using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace TIADateiViewer
{
    public partial class MainWindow : Window
    {

        Backend backend;
        List<string> nodes;

        public MainWindow()
        {
            InitializeComponent();
            this.backend = new TiaDateiViewerBackend();
            this.nodes = new List<string>();
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

            generateNodeSelection(backend.getNodeTypes());

        }

        void generateNodeSelection(List<string> nodeTypes)
        {
            List<Button> buttons = new List<Button>();
            foreach(var nodeType in nodeTypes)
            {
                var button = new Button();
                button.Content = nodeType;
                button.Height = 64;
                button.Width = 96;
                buttons.Add(button);
            }
            this.nodes = backend.getNodeTypes();
            viewTopPanel.Children.Clear();
            foreach(var nodeName in this.nodes)
            {
                viewTopPanel.Children.Add(new Label() { Content = nodeName });
            }
        }

        void selectNode(string nodeType)
        {

        }

        
    }

}

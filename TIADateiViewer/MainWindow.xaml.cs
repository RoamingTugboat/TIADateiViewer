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
        List<string> nodeTypes;

        public MainWindow()
        {
            InitializeComponent();
            this.backend = new TiaDateiViewerBackend();
            nodeTypes = new List<string>();
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
            generateNodeSelection(backend.getTiaNodesDictionary());

        }

        void generateNodeSelection(Dictionary<string, List<node>> nodeDict)
        {
            viewTopPanel.Children.Clear();
            foreach(var entry in nodeDict)
            {
                viewTopPanel.Children.Add(new Label() { Content = $"{entry.Key} ({entry.Value.Count})" });
                this.nodeTypes.Add(entry.Key);
            }

            listBox.Items.Clear();
            var thirdDictItem = nodeTypes[2];
            foreach(var node in nodeDict[thirdDictItem])
            {
                var nodeNameOrIdentifierProperty = node.properties.FirstOrDefault(e => e.key.Equals("Name"));
                if(nodeNameOrIdentifierProperty == null)
                {
                    nodeNameOrIdentifierProperty = node.properties.FirstOrDefault(e => e.key.Equals("Id"));
                }
                listBox.Items.Add(new ListBoxItem() { Content = $"{nodeNameOrIdentifierProperty.value}\t|Eigenschaften:{node.properties.Count}" });
            }
            


        }
        
    }

}

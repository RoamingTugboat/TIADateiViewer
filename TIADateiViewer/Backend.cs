using System.Collections.Generic;

namespace TIADateiViewer
{
    interface Backend
    {
        void generateTestTiaFile();

        void openTiaFile(string path);

        bool isValidFileOpen();

        List<string> getNodeTypes();

        node findNode(string typeName);
    }
}

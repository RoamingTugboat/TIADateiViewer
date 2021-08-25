using System.Collections.Generic;

namespace TIADateiViewer
{
    interface Backend
    {
        void openTiaFile(string path);

        bool isValidFileOpen();

        Dictionary<string, List<node>> getTiaNodesDictionary();
    }
}

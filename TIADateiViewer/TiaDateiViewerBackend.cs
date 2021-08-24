namespace TIADateiViewer
{
    class TiaDateiViewerBackend : Backend
    {

        public string FilePath { get; private set; }

        public TiaDateiViewerBackend()
        {

        }

        public void selectFile(string filePath)
        {
            interpretTiaFile(filePath);
            this.FilePath = filePath;
        }

        void interpretTiaFile(string filePath)
        {

        }

    }
}

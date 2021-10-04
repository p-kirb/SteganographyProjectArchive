using System.Windows.Forms;
using System.IO;

namespace Steganography_Project
{
    abstract class Data                         //Class is abstract and therefore never instantiated - is generalization of SourceImage and HiddenData.
    {
        protected string filePath;              //Protected allows access only to this and derived classes.
        protected string fileType;
        protected long size;

        public virtual bool Set()                                   //bool - return value used as validation check to ensure file was selected and values set.
        {                                                           //virtual - allows overriding in the derived class.
            using (OpenFileDialog dialog = new OpenFileDialog())    //Creates a temporary OpenFileDialog object to browse computers files.
            {
                if (dialog.ShowDialog() == DialogResult.OK)         //Shows the dialog box and runs code if choice was selected (i.e. OK button pressed).
                {
                    filePath = dialog.FileName;                     //Sets "filePath" to the file path of the file selected in the dialog window.
                    fileType = Path.GetExtension(filePath);         //Sets "fileType" to the image file type so it can be saved in the same format once encrypted.
                    size = new FileInfo(filePath).Length;           //Sets "size" the size of the file in bytes.
                    return true;
                }
                else
                {
                    return false;                                           //Returns false if "cancel" was selected in dialog.
                }
            }
        }

        public string GetFilePath()
        {
            return filePath;
        }

        public string GetFileType()
        {
            return fileType;
        }

        public long GetFileSize()
        {
            return size;
        }

    }
}


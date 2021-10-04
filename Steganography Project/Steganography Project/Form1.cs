using System;
using System.Threading;
using System.Windows.Forms;

namespace Steganography_Project
{
    public partial class Form1 : Form
    {
        Thread alternateThread;                                 //Thread used at points where program slows down - allows for a loading bar to show the program still working.
        SourceImage source = new SourceImage();                        //Object handles the source image.
        EncryptedImage encrypted = new EncryptedImage();        //Object handles the encrpted verion of the source image.
        HiddenData hidden = new HiddenData();                   //Object handles the data thats hidden within the image.

        void resetForm(bool state)                              //Method to reset the form
        {
            source = new SourceImage();                                //Resets the objects
            encrypted = new EncryptedImage();
            hidden = new HiddenData();

            sourceImg.Image = null;                             //Resets images
            encryptedImg.Image = null;

            textBoxFileToEncrypt.Text = null;                   //Resets text
            labelFileType.Text = "File type:";
            labelMaxData.Text = "Maximum file size:";

            checkBoxDecrypt.Checked = !state;                   //Enables/disables buttons based on whether true or false argument passed
            checkBoxEncrypt.Checked = state;
            btnEncrypt.Enabled = state;
            btnSaveImage.Enabled = state;
            textBoxFileToEncrypt.Enabled = state;
            btnBrowseLoadFile.Enabled = state;
            btnDecryptFile.Enabled = !state;
            btnSaveFile.Enabled = !state;
            toolTipEncryptEnabled.Active = state;
            toolTipDecryptEnabled.Active = !state;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void sourceImg_Click(object sender, EventArgs e)
        {
            if (source.Set())                                           //Runs Set() in "source" - if true returned: values for "source" have been set and following code can run.
            {
                sourceImg.Image = source.GetBitmapFromPath();       //Sets the "sourceImg" PictureBox in the form to the image at filepath of "source".
                labelMaxData.Text = ("Maximum file size: " + source.GetAvailableSize() + " bytes.");
            }
            else
            {
                source = new SourceImage();                         //Resets the Data object to avoid problems with values having already been set.
                sourceImg.Image = null;
            }
        }

        private void checkBoxEncrypt_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxEncrypt.Checked)
            {
                resetForm(true);                                                    //"true" represents state of checkBoxEncrypt
            }
        }

        private void checkBoxDecrypt_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDecrypt.Checked)
            {
                resetForm(false);
            }
        }

        #region Code for encrypting images

        //Events that may occur when "checkBoxEncrypt" is checked.

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            try                                                         //Exception handling - ensures program doesn't crash if subroutines are trying to execute with null values.
            {
                if (source.GetAvailableSize() > hidden.GetFileSize())   //Checks that the file represented by "source" is big enough to conceal the file represented by "hidden".
                {
                    encrypted.Set(source, hidden);                      //Overloading - sets "encrypted" with the Data and HiddenData objects as arguments.
                    encryptedImg.Image = encrypted.GetBitmap();         //Sets the "encryptedImg" PictureBox in the form to the image just created by encrypting file into "source".
                }
                else                                                    //Runs if the file represented by "hidden" is too large to fit into file represented by "source".
                {
                    MessageBox.Show("File too large to encrypt - please select a larger image or a smaller file.", "Error", MessageBoxButtons.OK);
                }
            }
            catch                                                       //Runtime error will occur if values for "source" or "hidden" haven't been set yet.
            {
                MessageBox.Show("Ensure all data values are filled.", "Error", MessageBoxButtons.OK);
            }
        }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            encrypted.SaveImage();
        }

        private void btnBrowseLoadFile_Click(object sender, EventArgs e)
        {
            if (hidden.Set())                                           //Runs Set() in "hidden" - if true returned: values for "hidden" have been set and following code can run.
            {
                textBoxFileToEncrypt.Text = hidden.GetFilePath();       //Shows the filepath of the file on the form.
                alternateThread = new Thread(hidden.SetBitstream);      //Creates a new thread used to execute "hidden.SetBitstream()" as the method takes a long time to finish.
                                                                        //Having another thread means that the form can still be active while "hidden.SetBitsream()" works in the background.
                alternateThread.Start(progressBar);                     //Starts the thread passing "progressBar" as an argument - this effectively runs "hidden.SetBitstream(progressBar)" in the background.
            }
        }

        #endregion

        #region Code for decrypting images

        //Events that may occur when "checkBoxDecrypt" is checked.

        private void encryptedImg_Click(object sender, EventArgs e)
        {                                                               //Method works in the same way as "sourceImg_Click()" but for "encrypted" and "encryptedImg" rather than "source" and "sourceImg".
            if (checkBoxDecrypt.Checked && encrypted.Set())             //Runs Set() with no arguments in "encrypted" - if true returned: values for "encrypted" have been set and following code can run.
            {
                encryptedImg.Image = encrypted.GetBitmapFromPath(); //Sets the "encryptedImg" PictureBox in the form to the image at filepath of "encrypted".
                Console.WriteLine(encrypted.GetFilePath());
            }
            else
            {
                encrypted = new EncryptedImage();
                encryptedImg.Image = null;
            }
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            hidden.SaveFile();
        }

        private void btnDecryptFile_Click(object sender, EventArgs e)
        {
            if(source.GetFilePath()!= null && encrypted.GetFilePath() != null)                              //Checks "filePath" in "source" and "filePath" in "encrypted" have been assigned values
            {
                if(hidden.ExtractMetaData(source.GetBitmapFromPath(), encrypted.GetBitmapFromPath()))       //Code only runs if ExtractMetaData returns true (if it executes correctly)
                {
                    labelFileType.Text = "File type: " + hidden.GetFileType();                                                                      //Displays the file type on the form.
                    alternateThread = new Thread(() => hidden.SetBytes(source.GetBitmapFromPath(), encrypted.GetBitmapFromPath(), progressBar));    //use lambda function to allow multiple arguments to be passed.
                    alternateThread.Start();                                                                                                        //Starts the new thread
                }
                else                                                                                        //Codepath runs if an error occured while executing ExtractMetadata()
                {
                    MessageBox.Show("Enusure images are the same size.", "Error", MessageBoxButtons.OK);
                }
            }
            else                                                                                            //Codepath runs if "filePath" in "source" or "filePath" in "encrypted" are null.
            {
                MessageBox.Show("Select 2 images.", "Error", MessageBoxButtons.OK);
            }

        }

        #endregion

    }
}


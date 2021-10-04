using System.Drawing;
using System.Windows.Forms;


namespace Steganography_Project
{
    class EncryptedImage : SourceImage
    {
        //All attributes used for encrypting. When decrypting the object acts as a plain "data" object.

        private Bitmap bmp;

        public void Set(SourceImage image, HiddenData data)                         //Overloading - Both set methods set values but this method is used when creating new image from the original image and a bistream.
        {            
            SetBitmap(data.GetBitstream(), image.GetBitmapFromPath());              //Calls "Setbitmap()" within the class using "Data" and "HiddenData" objects as objects.
            fileType = image.GetFileType();                                         //Sets "fileType" - used so the encrypted image is saved as the same type as original image.
        }

        private void SetBitmap(string bitstream, Bitmap tempImage)                      //Assigns "bpm" a value - generated from the objects passed as arguments.
        {
            Color colour;                                                               //Creates an RGB "Colour" object.
            int i = 0;                                                                  //Variable used to count through the bitstream.
            int blueValue;                                                              //Stores the integer value of the blue component of each pixel.
            for (int y = 0; y < tempImage.Height; y++)                                  //Loops through the height of the image.
            {
                for (int x = 0; x < tempImage.Width; x++)                               //Loops through the width of the image.
                {
                    colour = tempImage.GetPixel(x, y);                                  //Sets "colour" to the current pixel.
                    blueValue = colour.B;                                               //Sets "blueValue" to the integer value of the blue component of the current pixel.
                    blueValue = blueValue ^ int.Parse(bitstream[i].ToString());         //Sets "blueValue" to the result of a bitwise XOR between the current "blueValue" and the current bit in "bitstream".
                    colour = Color.FromArgb(colour.A, colour.R, colour.G, blueValue);   //Changes the blue component of "colour" to the newly generated blue value.
                    tempImage.SetPixel(x, y, colour);                                   //Replaces the current pixel with the newly generated one.
                    i++;                                                                //Increments "i" to cout through "bitstream".
                    if (i == bitstream.Length)                                          //Checks if whole bistream has been looped through.
                    {
                        x = tempImage.Width;                                            //Sets "x" and "y" to their maximum values causing the loops to stop.
                        y = tempImage.Height;
                    }
                }
            }
            bmp = tempImage;                                                            //Sets "bmp" to the newly generated encrypted image.
        }

        public void SaveImage()
        {
            if(bmp != null)            //Codepath runs if "bmp" has been generated (i.e. if there is an image to save).
            {
                using (SaveFileDialog dialog = new SaveFileDialog())        //Creates temporary SaveFileDialog object.
                {
                    dialog.Title = "Save Image";                            //Sets title of the window.
                    dialog.ShowDialog();                                    //Shows the dialog window.
                    if (dialog.FileName != "")                              //Codepath runs if a save name has been entered.
                    {
                        bmp.Save(dialog.FileName + fileType);               //Saves the file in the format specified by "fileType".
                    }                                                       //-works by concatenating the filetype at the end of the name.
                }
            }
            else                                                            //If "bmp" is null then the data hasn't been encrypted.
            {
                MessageBox.Show("Encrypt data first.", "Error", MessageBoxButtons.OK);      //Error message popup.
            }
        }

        public Bitmap GetBitmap()
        {
            return ConvertToUnindexed(bmp);
        }
    }
}

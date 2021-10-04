using System;
using System.Collections.Generic;
using System.IO;                //Allows Use of "File" class.
using System.Drawing;
using System.Windows.Forms;

namespace Steganography_Project
{
    class HiddenData : Data
    {
        int decryptedSize;                                                              //Holds the size of the decrypted file in kb;

        static Dictionary<string, string> dataTypes = new Dictionary<string, string>()  //dictionary has both values as keys and pairs to allow reverse lookup
        {
            { ".txt" , "000"  },
            { ".pdf" , "001"  },
            { ".jpg" , "010"  },
            { ".gif" , "011"  },
            { ".mp3" , "100"  },
            { ".mp4" , "101"  },
            { ".zip" , "110"  },
            { "000"  , ".txt" },
            { "001"  , ".pdf" },
            { "010"  , ".jpg" },
            { "011"  , ".gif" },
            { "100"  , ".mp3" },
            { "101"  , ".mp4" },
            { "110"  , ".zip" },
        };

        string bitstream;

        #region Attributes used for encrypting data

        string Pad(byte b)                                  //Method for padding bytes to make them 8 bits.
        {
            string bytestring = Convert.ToString(b, 2);     //Converts from "byte" datatype to string in base 2.
            if (bytestring.Length < 8)                      //Code runs if string is less than 8 characters.
            {
                while (bytestring.Length != 8)              //Loops through string until its 8 characters long.
                {
                    bytestring = 0 + bytestring;            //Adds a 0 to the start of the string.
                }
            }
            return bytestring;
        }

        string Pad(long b)                                  //Method for padding longs to make them 10 bit binary.
        {
            b = 1 + (b / 1000);                             //Converts bytes to kilobytes and adds 1kb for padding.
            string bytestring = Convert.ToString(b, 2);     //Converts from "long" datatype to string in base 2.
            if (bytestring.Length < 10)                     //Code runs if string is less than 10 characters.
            {
                while (bytestring.Length != 10)             //Loops through string until its 10 characters long.
                {
                    bytestring = 0 + bytestring;            //Adds a 0 to the start of the string.
                }
            }
            return bytestring;
        }

        string AddMetaData()                         //Method generates metadata from file type and size.
        {
            string metadata = dataTypes[fileType];   //Looks up "fileType" in "dataTypes" dictionary and sets string to result.
            metadata = metadata + Pad(size);         //Concatenates the size of the file in binary (after padding).
            return metadata;
        }

        public void SetBitstream(object bar)                        //Method for converting any filetype into bitstream.
        {                                                           //"object" as argument because method is called using multithreading.
            var progressBar = (ProgressBar)bar;                     //Creating ProgressBar object from argument.
            if (dataTypes.ContainsKey(fileType))                    //Validates that the selected file is an allowed file (contained in "dataTypes").
            {
                string stream = AddMetaData();                      //Sets the start of the string to be the 13 bit metadata.
                byte[] bytes = File.ReadAllBytes(filePath);         //Creates a "byte" array filled with each byte of data from the file at "filepath".
                int l = bytes.Length;                               //Sets l to the length of the array.
                progressBar.Maximum = l;                            //Sets the maximum value of the progress bar to the length of the array.
                for (int i = 0; i < l; i++)                         //Loops through each element of the array.
                {
                    stream = stream + Pad(bytes[i]);                //Concatenates the current byte of data to "stream" after converting it to binary.
                    progressBar.Increment(1);                       //Increments the progress bar.
                }
                bitstream = stream;                                 //Sets "bitstream" to the temporary "stream" variable.
                progressBar.Value = 0;                              //Resets the progress bar.
            }
            else                                                    //If the filetype isn't in "fileTypes.
            {
                MessageBox.Show("Invalid file selected.", "Error", MessageBoxButtons.OK);       //Error message popup
            }
        }

        public string GetBitstream()
        {
            return bitstream;
        }

        #endregion

        #region Attributes used for decrypting data

        byte[] data;

        public bool ExtractMetaData(Bitmap img1, Bitmap img2)                   //Method sets "decryptedSize" and "fileType" values.
        {
            if (img1.Height != img2.Height && img1.Width != img2.Width)         //Validation - makes sure images are the same size.
            {
                return false;                                                   //Returns false if not.
            }
            string metadata = "";                                               //Sets string to empty to allow concatenation.
            int counter = 0;
            for (int y = 0; y < img1.Height; y++)                               //Loops through the height of the image.
            {
                for (int x = 0; x < img1.Width; x++)                            //loops through the width of the image.
                {
                    metadata = metadata + (img1.GetPixel(x, y).B ^ img2.GetPixel(x, y).B);
                                                                                //^Concatenates result of bitwise XOR between pixel values.
                    if (counter == 12)                                          //If looped 13 times.
                    {
                        y = img1.Height;                                        //Break out of x and y loops.
                        x = img1.Width;
                    }
                    counter = counter + 1;
                }
            }
            fileType = dataTypes[metadata.Substring(0, 3)];                     //Looks value with the metadata as the key and sets "fileType".
            decryptedSize = Convert.ToInt32(metadata.Substring(3), 2);          //Sets "decryptedSize" to denary equivalent of binary metadata.
            return true;                                                        //Returns true if method executed fully.
        }

        void ExtractData(Bitmap img1, Bitmap img2, ProgressBar bar)                                                                             //Method to compare 2 images and extract data from them - sets "bitstream" string
        {
            int counter = 0;
            string stream = "";                                  //Sets string to empty to allow concatenation.
            bar.Maximum = decryptedSize*1000*8;                  //Sets bar values to allow easy incrementation.
            for (int y = 0; y < img1.Height; y++)                //Loops through the height of the image.
            {
                for (int x = 0; x < img1.Width; x++)             //Loops through the width of the image.
                {
                    stream = stream + (img1.GetPixel(x, y).B ^ img2.GetPixel(x, y).B);
                                                                 //^Concatenates result of bitwise XOR between current pixel values.
                    if (counter > (decryptedSize*1000*8))        //Checks if loop has executed enough times
                    {                                            //for all data to have been extracted.
                        y = img1.Height;                         //Breaks out of x and y loops.
                        x = img1.Width;
                    }
                    bar.Increment(1);
                    counter = counter + 1;
                }
            }
            bitstream =  stream;
            bar.Value = 0;                                       //Resets the bar value.
        }

        public void SetBytes(object i1, object i2, object bar)              //Method to parse bitstream into array of bytes.
        {
            var img1 = (Bitmap)i1;                                          //Converts objects passed as arguments
            var img2 = (Bitmap)i2;                                          //to instances of their actual classes.
            var progressBar = (ProgressBar)bar;
            ExtractData(img1, img2, progressBar);                           //Calls ExtractData() with converted objects.
            bitstream = bitstream.Remove(0, 13);                            //Removes metadata from start of bitstream.
            bitstream = RemoveZeros(bitstream);                             //Removes redundant data from back of bitstream.
            List<byte> bytes = new List<byte>();                            //Creates new list, each element is 1 byte of data.
            for (int i = 0; i < bitstream.Length - 9; i = i + 8)            //Loops through the string 8 characters at a time
            {                                                               //to parse bitstream into a list of bytes.
                bytes.Add(Convert.ToByte(bitstream.Substring(i, 8), 2));    //Adds next chunk of 8 bits to a new element in the list.
            }
            data = bytes.ToArray();                                         //Converts list to array.
        }

        string RemoveZeros(string bits)                 //Method to remove redundant data from back of a bitstream.
        {
            bool done = false;                          //Used for while loop.
            int i;                                      //Counter variable.
            while(done == false)
            {
                i = bits.Length - 8;                    //Loop decrements 8 characters (1 byte) at a time.
                if (bits.Substring(i) == "00000000")    //If the last 8 characters are 0.
                {
                    bits = bitstream.Remove(i);         //Remove them.
                }
                else                                    //If the last 8 characters arent 0.
                {
                    done = true;                        //Break while loop.
                }
            }
            return bits;
        }

        public void SaveFile()
        {
            if(data != null)                                    //Ensures that "data" has been assigned a value.
            {
                SaveFileDialog dialog = new SaveFileDialog();   //Creates new SaveFileDialog object.
                dialog.Title = "Save File";                     //Sets window title.
                dialog.ShowDialog();
                if (dialog.FileName != "")                      //Ensures the file has been named.
                {
                    File.WriteAllBytes(dialog.FileName + fileType, data);   //Writes the data to a file with the  
                }                                                           //file type at the end of the name
            }                                                               //to save it in the right format.
            else                                                //Code runs if "data" hasn't been set.
            {
                MessageBox.Show("Decrypt data before saving.");
            }
        }

        #endregion
    }
}

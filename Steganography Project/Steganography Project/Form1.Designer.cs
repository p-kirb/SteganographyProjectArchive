namespace Steganography_Project
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.sourceImg = new System.Windows.Forms.PictureBox();
            this.encryptedImg = new System.Windows.Forms.PictureBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnSaveImage = new System.Windows.Forms.Button();
            this.labelMaxData = new System.Windows.Forms.Label();
            this.checkBoxEncrypt = new System.Windows.Forms.CheckBox();
            this.checkBoxDecrypt = new System.Windows.Forms.CheckBox();
            this.textBoxFileToEncrypt = new System.Windows.Forms.TextBox();
            this.btnBrowseLoadFile = new System.Windows.Forms.Button();
            this.btnSaveFile = new System.Windows.Forms.Button();
            this.toolTipEncryptEnabled = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipDecryptEnabled = new System.Windows.Forms.ToolTip(this.components);
            this.btnDecryptFile = new System.Windows.Forms.Button();
            this.labelFileType = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.sourceImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.encryptedImg)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sourceImg
            // 
            this.sourceImg.BackColor = System.Drawing.SystemColors.Window;
            this.sourceImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sourceImg.Location = new System.Drawing.Point(15, 18);
            this.sourceImg.Name = "sourceImg";
            this.sourceImg.Size = new System.Drawing.Size(360, 360);
            this.sourceImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.sourceImg.TabIndex = 0;
            this.sourceImg.TabStop = false;
            this.toolTipEncryptEnabled.SetToolTip(this.sourceImg, "Source Image - Click to change.");
            this.toolTipDecryptEnabled.SetToolTip(this.sourceImg, "Source Image - Click to change.");
            this.sourceImg.Click += new System.EventHandler(this.sourceImg_Click);
            // 
            // encryptedImg
            // 
            this.encryptedImg.BackColor = System.Drawing.SystemColors.Window;
            this.encryptedImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.encryptedImg.Location = new System.Drawing.Point(431, 18);
            this.encryptedImg.Name = "encryptedImg";
            this.encryptedImg.Size = new System.Drawing.Size(360, 360);
            this.encryptedImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.encryptedImg.TabIndex = 1;
            this.encryptedImg.TabStop = false;
            this.toolTipEncryptEnabled.SetToolTip(this.encryptedImg, "Encrypted Image.");
            this.toolTipDecryptEnabled.SetToolTip(this.encryptedImg, "Encrypted Image - Click to change.");
            this.encryptedImg.Click += new System.EventHandler(this.encryptedImg_Click);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(171, 438);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(97, 23);
            this.btnEncrypt.TabIndex = 4;
            this.btnEncrypt.Text = "Encrypt File";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.Location = new System.Drawing.Point(273, 438);
            this.btnSaveImage.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(100, 23);
            this.btnSaveImage.TabIndex = 7;
            this.btnSaveImage.Text = "Save Image";
            this.btnSaveImage.UseVisualStyleBackColor = true;
            this.btnSaveImage.Click += new System.EventHandler(this.btnSaveImage_Click);
            // 
            // labelMaxData
            // 
            this.labelMaxData.AutoSize = true;
            this.labelMaxData.BackColor = System.Drawing.SystemColors.Control;
            this.labelMaxData.Location = new System.Drawing.Point(121, 380);
            this.labelMaxData.Name = "labelMaxData";
            this.labelMaxData.Size = new System.Drawing.Size(91, 13);
            this.labelMaxData.TabIndex = 8;
            this.labelMaxData.Text = "Maximum file size:";
            // 
            // checkBoxEncrypt
            // 
            this.checkBoxEncrypt.AutoSize = true;
            this.checkBoxEncrypt.BackColor = System.Drawing.SystemColors.Control;
            this.checkBoxEncrypt.Checked = true;
            this.checkBoxEncrypt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxEncrypt.Location = new System.Drawing.Point(12, 380);
            this.checkBoxEncrypt.Name = "checkBoxEncrypt";
            this.checkBoxEncrypt.Size = new System.Drawing.Size(62, 17);
            this.checkBoxEncrypt.TabIndex = 9;
            this.checkBoxEncrypt.Text = "Encrypt";
            this.checkBoxEncrypt.UseVisualStyleBackColor = false;
            this.checkBoxEncrypt.CheckedChanged += new System.EventHandler(this.checkBoxEncrypt_CheckedChanged);
            // 
            // checkBoxDecrypt
            // 
            this.checkBoxDecrypt.AutoSize = true;
            this.checkBoxDecrypt.BackColor = System.Drawing.SystemColors.Control;
            this.checkBoxDecrypt.Location = new System.Drawing.Point(427, 380);
            this.checkBoxDecrypt.Name = "checkBoxDecrypt";
            this.checkBoxDecrypt.Size = new System.Drawing.Size(63, 17);
            this.checkBoxDecrypt.TabIndex = 10;
            this.checkBoxDecrypt.Text = "Decrypt";
            this.checkBoxDecrypt.UseVisualStyleBackColor = false;
            this.checkBoxDecrypt.CheckedChanged += new System.EventHandler(this.checkBoxDecrypt_CheckedChanged);
            // 
            // textBoxFileToEncrypt
            // 
            this.textBoxFileToEncrypt.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxFileToEncrypt.Location = new System.Drawing.Point(12, 405);
            this.textBoxFileToEncrypt.Name = "textBoxFileToEncrypt";
            this.textBoxFileToEncrypt.ReadOnly = true;
            this.textBoxFileToEncrypt.Size = new System.Drawing.Size(280, 20);
            this.textBoxFileToEncrypt.TabIndex = 11;
            // 
            // btnBrowseLoadFile
            // 
            this.btnBrowseLoadFile.Location = new System.Drawing.Point(298, 404);
            this.btnBrowseLoadFile.Name = "btnBrowseLoadFile";
            this.btnBrowseLoadFile.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseLoadFile.TabIndex = 12;
            this.btnBrowseLoadFile.Text = "Browse";
            this.toolTipEncryptEnabled.SetToolTip(this.btnBrowseLoadFile, "Browse for file to be encrypted.");
            this.btnBrowseLoadFile.UseVisualStyleBackColor = true;
            this.btnBrowseLoadFile.Click += new System.EventHandler(this.btnBrowseLoadFile_Click);
            // 
            // btnSaveFile
            // 
            this.btnSaveFile.Enabled = false;
            this.btnSaveFile.Location = new System.Drawing.Point(688, 438);
            this.btnSaveFile.Name = "btnSaveFile";
            this.btnSaveFile.Size = new System.Drawing.Size(100, 23);
            this.btnSaveFile.TabIndex = 13;
            this.btnSaveFile.Text = "Save File";
            this.btnSaveFile.UseVisualStyleBackColor = true;
            this.btnSaveFile.Click += new System.EventHandler(this.btnSaveFile_Click);
            // 
            // toolTipDecryptEnabled
            // 
            this.toolTipDecryptEnabled.Active = false;
            // 
            // btnDecryptFile
            // 
            this.btnDecryptFile.Enabled = false;
            this.btnDecryptFile.Location = new System.Drawing.Point(582, 438);
            this.btnDecryptFile.Name = "btnDecryptFile";
            this.btnDecryptFile.Size = new System.Drawing.Size(100, 23);
            this.btnDecryptFile.TabIndex = 14;
            this.btnDecryptFile.Text = "Decrypt File";
            this.btnDecryptFile.UseVisualStyleBackColor = true;
            this.btnDecryptFile.Click += new System.EventHandler(this.btnDecryptFile_Click);
            // 
            // labelFileType
            // 
            this.labelFileType.AutoSize = true;
            this.labelFileType.Location = new System.Drawing.Point(579, 380);
            this.labelFileType.Name = "labelFileType";
            this.labelFileType.Size = new System.Drawing.Size(49, 13);
            this.labelFileType.TabIndex = 15;
            this.labelFileType.Text = "File type:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox1.Controls.Add(this.sourceImg);
            this.groupBox1.Controls.Add(this.encryptedImg);
            this.groupBox1.Location = new System.Drawing.Point(-3, -6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(809, 383);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 476);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(776, 23);
            this.progressBar.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 511);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.labelFileType);
            this.Controls.Add(this.btnDecryptFile);
            this.Controls.Add(this.btnSaveFile);
            this.Controls.Add(this.btnBrowseLoadFile);
            this.Controls.Add(this.textBoxFileToEncrypt);
            this.Controls.Add(this.checkBoxDecrypt);
            this.Controls.Add(this.checkBoxEncrypt);
            this.Controls.Add(this.labelMaxData);
            this.Controls.Add(this.btnSaveImage);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(816, 550);
            this.MinimumSize = new System.Drawing.Size(816, 550);
            this.Name = "Form1";
            this.Text = "Steganography Tool";
            ((System.ComponentModel.ISupportInitialize)(this.sourceImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.encryptedImg)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox sourceImg;
        private System.Windows.Forms.PictureBox encryptedImg;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnSaveImage;
        private System.Windows.Forms.Label labelMaxData;
        private System.Windows.Forms.CheckBox checkBoxEncrypt;
        private System.Windows.Forms.CheckBox checkBoxDecrypt;
        private System.Windows.Forms.TextBox textBoxFileToEncrypt;
        private System.Windows.Forms.Button btnBrowseLoadFile;
        private System.Windows.Forms.Button btnSaveFile;
        private System.Windows.Forms.ToolTip toolTipEncryptEnabled;
        private System.Windows.Forms.ToolTip toolTipDecryptEnabled;
        private System.Windows.Forms.Button btnDecryptFile;
        private System.Windows.Forms.Label labelFileType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}


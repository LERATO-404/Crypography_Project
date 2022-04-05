using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace Crypyography
{
    public partial class LandingPage : Form
    {

        OpenFileDialog fileToOpen;
        SaveFileDialog saveF;
        StreamWriter swrite;
        Stream s;
        
        public LandingPage()
        {
            InitializeComponent();
            btnChooseFile.Enabled = false;
            btnProceed.Enabled = false;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbFile_CheckedChanged(object sender, EventArgs e)
        {
            enableChoose();
        }

        private void rbFolder_CheckedChanged(object sender, EventArgs e)
        {
            enableChoose();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {


        }

        private void txtFilePath_TextChanged(object sender, EventArgs e)
        {

        }


        /*------------------Methods-------------------*/

        private void enableChoose()
        {
            
            if (rbFile.Checked == true || rbFolder.Checked == true)
            {
                btnChooseFile.Enabled = true;
            }
        }

        private void enableProceed()
        {
            if(cboxOption.SelectedIndex == 0 || cboxOption.SelectedIndex == 1)
            {
                btnProceed.Enabled = true; 
            }
        }

        private void attachementType()
        {
            if (rbFile.Checked)
            {
                fileToOpen = new OpenFileDialog();
                fileToOpen.Title = "Select File";
                fileToOpen.InitialDirectory = @"C:\";//--"C:\\";
                fileToOpen.Filter = "All files (*.*)|*.*|Text File (*.txt)|*.txt";
                fileToOpen.FilterIndex = 2;
                fileToOpen.ShowDialog(); //

                if (openFileDialog1.FileName != "")
                {
                    
                    lblChoosenFile.Text = fileToOpen.FileName;
                    //txtFilePathEn.Text = lblChoosenFile.Text;
                    
                }
                else
                {
                    lblChoosenFile.Text = "You did not select the file!";
                }
            }
            else if (rbFolder.Checked)
            {
                FolderBrowserDialog folderToOpen = new FolderBrowserDialog();
                if (folderToOpen.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    
                    lblChoosenFile.Text = folderToOpen.SelectedPath;
                    //txtFilePathDe.Text = lblChoosenFile.Text;
                }
                else
                {
                    lblChoosenFile.Text = "You did not select the folder!";
                }
            }
        }

        public void deleteAfter(string fileToDelete)
        {
            try
            {
                // Check if file exists with its full path    
                if (File.Exists(fileToDelete))
                {
                    // If file found, delete it    
                    File.Delete(fileToDelete);
                    MessageBox.Show("Original file deleted ", "File deleted", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("File not found", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (IOException ioExp)
            {
                Console.WriteLine(ioExp.Message);
            }
        }


        public void saveFile()
        {
            saveF = new SaveFileDialog();
            saveF.Title = "Save File";
            saveF.InitialDirectory = @"C:\";//--"C:\\";
            saveF.Filter = "All files (*.*)|*.*|Text File (*.txt)|*.txt";

            if (saveF.ShowDialog() == DialogResult.OK)
            {
                string encText = txtKeyEn.Text;
                string decText = txtKeyDe.Text;
                s = File.Open(saveF.FileName, FileMode.CreateNew);
                using (swrite = new StreamWriter(s))
                {
                    if(tControl.SelectedIndex == 1) //encrypt
                    {
                        swrite.Write(encText); // updated text encryption
                        //encryptFile(encText);
                        lblEn.Text = saveF.FileName; // filePath
                    }
                    else if(tControl.SelectedIndex == 2) // decrypt
                    {
                        swrite.Write(decText); // updated text decryption
                        //decyptFile(decText);
                        lblDe.Text = saveF.FileName; // filepath
                    }
                    MessageBox.Show("New File saved at "+saveF.FileName, "Saved File", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
            }

        }


        public static string encryptFile(string encryptString)   
        {
            string EncryptionKey = "0ram@1234xxxxxxxxxxtttttuuuuuiiiiio";  //we can change the code converstion key as per our requirement    
            byte[] clearBytes = Encoding.Unicode.GetBytes(encryptString);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    encryptString = Convert.ToBase64String(ms.ToArray());
                }
            }
            return encryptString;
        }

        /*------------------Methods-------------------*/
        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                attachementType();
            }
            catch (FileNotFoundException ex1)
            {
                MessageBox.Show("File not found" + ex1, "failed", MessageBoxButtons.RetryCancel,
                MessageBoxIcon.Error);
            }
            catch (Exception ex2)
            {
                MessageBox.Show("Exception found" + ex2, "failed", MessageBoxButtons.RetryCancel,
                MessageBoxIcon.Error);
            }
        }

        
        private void btnProceed_Click(object sender, EventArgs e)
        {

            if (rbFile.Checked || rbFolder.Checked)
            {
                if (cboxOption.SelectedIndex == 0)
                {
                    txtFilePathEn.Text = lblChoosenFile.Text;
                    txtKeyEn.Text = File.ReadAllText(fileToOpen.FileName);
                    tControl.SelectedTab = Encrypt;
                    Encrypt.Show();

                }
                else if (cboxOption.SelectedIndex == 1)
                {
                    txtFilePathDe.Text = lblChoosenFile.Text;
                    txtKeyDe.Text = File.ReadAllText(fileToOpen.FileName);
                    tControl.SelectedTab = Decrypt;
                    Decrypt.Show();
                }
            }
        }

        private void cboxOption_SelectedIndexChanged(object sender, EventArgs e)
        {

            enableProceed();
        }

        
        private void btnDoneEn_Click(object sender, EventArgs e)
        {
            string fPath = txtFilePathEn.Text.ToString();
            if (cboxDeleteEn.Checked == true)
            {
                deleteAfter(fPath);
 
            }
        }

        private void btnDoneDe_Click(object sender, EventArgs e)
        {
            string fPath = txtFilePathDe.Text.ToString();
            if (cboxDeleteDe.Checked == true)
            {
                deleteAfter(fPath);

            }
        }

        private void Decrypt_Click(object sender, EventArgs e)
        {

        }

        private void browseDe_Click(object sender, EventArgs e)
        {
            
            saveFile();
        }

        private void browseEn_Click(object sender, EventArgs e)
        {
            
            saveFile();
        }
    }
}

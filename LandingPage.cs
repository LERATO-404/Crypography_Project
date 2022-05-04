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
using System.Data.SqlClient;

namespace Crypyography
{
    public partial class LandingPage : Form
    {

        OpenFileDialog fileToOpen;
        SaveFileDialog saveF;
        StreamWriter swrite;
        Stream s;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapt;
        DataSet ds;
        

        public LandingPage()
        {
            InitializeComponent();
            btnChooseFile.Enabled = false;
            btnProceed.Enabled = false;
            cboxDeleteEn.Enabled = false;
            cboxDeleteDe.Enabled = false;
            rbFolder.Visible = false;
            photoBoxEn.Visible = false;
            photoBoxDe.Visible = false;
            lblUserCount.Text = "0";
            tControl.TabPages.Remove(Admin);
        }

        private void LandingPage_Load_1(object sender, EventArgs e)
        {
            string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=
            C:\Users\LAVAS\Desktop\CMPG 215 - INFORMATION SECURITY\cryptography-project\Crypyography\App_Data\CryptographyDB.mdf;Integrated Security=True";
            con = new SqlConnection(conString);
            


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

        public void cleanTabOne()
        {
            rbFile.Checked = false;
            rbPhoto.Checked = false;
            rbRar.Checked = false;
            lblSelectedFile.Text = "No file Selected";
        }

        public  void cleanTabTwo()
        {
            txtFilePathEn.Clear();
            txtFileEnContent.Clear();
            txtKeyEn.Clear();
            txtRepeatKeyEn.Clear();
            lblEn.Text = "...";
            photoBoxEn.Visible = false;
            tControl.SelectedTab = ChooseFile;
            ChooseFile.Show();
        }

        public void cleanTabThree()
        {
            txtFilePathDe.Clear();
            txtFileDe.Clear();
            txtKeyDe.Clear();
            lblDe.Text = "...";
            photoBoxDe.Visible = false;
            tControl.SelectedTab = ChooseFile;
            ChooseFile.Show();
        }

        private void enableChoose()
        {
            
            if (rbFile.Checked == true || rbFolder.Checked == true || rbPhoto.Checked == true || rbRar.Checked == true)
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
            fileToOpen = new OpenFileDialog();
            fileToOpen.Title = "Select File";
            fileToOpen.InitialDirectory = @"C:\";
            fileToOpen.Filter = "All files (*.*)|*.*|Text File (*.txt)|*.txt|Image Files(*.jpg; *.jpeg; *.gif; *.png; *.bmp)| *.jpg; *.jpeg; *.gif; *.png; *.bmp)|PDF Documents (.pdf)|*.pdf|ZIP|*.zip|RAR|*.rar";
            fileToOpen.FilterIndex = 2;
            fileToOpen.ShowDialog();

            if (rbFile.Checked || rbPhoto.Checked || rbRar.Checked)
            {
                if (openFileDialog1.FileName != "")
                {
                    lblSelectedFile.Text = fileToOpen.FileName;
                }
                else
                {
                 
                    lblSelectedFile.Text = "You did not select the file!";
                }
            }
            else if (rbFolder.Checked)
            {
                FolderBrowserDialog folderToOpen = new FolderBrowserDialog();
                if (folderToOpen.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    
                    lblSelectedFile.Text = folderToOpen.SelectedPath;
                    //txtFilePathDe.Text = lblChoosenFile.Text;
                }
                else
                {
                    lblSelectedFile.Text = "You did not select the folder!";
                }
            }
            else
            {
                MessageBox.Show("Select the Attachement type you want to Encrypt or Decrypt", "Select Attachement type", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            saveF.Filter = "All files (*.*)|*.*|Text File (*.txt)|*.txt|Image Files(*.jpg; *.jpeg; *.gif; *.png; *.bmp)| *.jpg; *.jpeg; *.gif; *.png; *.bmp)|PDF Documents (.pdf)|*.pdf|ZIP|*.zip|RAR|*.rar";
           
            if (saveF.ShowDialog() == DialogResult.OK)
            {
                string encText = txtFileEnContent.Text;
                string decText = txtFileDe.Text;
                s = File.Open(saveF.FileName, FileMode.CreateNew);
                using (swrite = new StreamWriter(s))
                {
                    if(tControl.SelectedIndex == 1) //encrypt
                    {

                        swrite.Write(encText); // updated text encryption
                        lblEn.Text = saveF.FileName; // filePath
                    }
                    else if(tControl.SelectedIndex == 2) // decrypt
                    {
                        swrite.Write(decText); // updated text decryption
                        lblDe.Text = saveF.FileName; // filepath
                    }
                    MessageBox.Show("New File saved at "+saveF.FileName, "Saved File", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
            }
        }


       

        public int userCount()
        {
            int usersAvailable = 0;
            string sql = @"SELECT COUNT(*) FROM [user]";
            try
            {
                
                using (cmd = new SqlCommand(sql, con))
                {
                    
                    usersAvailable = (int)cmd.ExecuteScalar();
                }
                return usersAvailable;
                
            }
            catch (Exception ex)
            {
                return 0;
            }
        }




        private bool Encode(string inputFilePath, string outputfilePath)
        {
            bool isFileEncrypted = false;
            try
            {
                string EncryptionKey = "MAKV2SPBNI99212"; //include key in as the parameter
                byte[] saltByte = new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 };
                


                using (Aes encryptor = Aes.Create())
                {
                    encryptor.KeySize = 256;
                    encryptor.BlockSize = 128;

                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, saltByte, 1000);
                    encryptor.Key = pdb.GetBytes(encryptor.KeySize / 8);
                    encryptor.IV = pdb.GetBytes(encryptor.BlockSize / 8);

                    using (FileStream fsOutput = new FileStream(outputfilePath, FileMode.Create))
                    {
                        using (CryptoStream cs = new CryptoStream(fsOutput, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            //if(rbFile.Checked == true)
                            using (FileStream fsInput = new FileStream(inputFilePath, FileMode.Open))
                            {
                                int data;
                                while ((data = fsInput.ReadByte()) != -1)
                                {
                                    cs.WriteByte((byte)data);
                                }
                            }
                        }
                        isFileEncrypted = true;
                        return isFileEncrypted;
                    }
                }

            }
            catch 
            {
                //MessageBox.Show("File is Encypted", "The file is encrypted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return isFileEncrypted;
            }

            
            
        }

        private bool Decode(string inputFilePath, string outputfilePath)
        {
            bool isFileDecrypted = false;
            try
            {
                string EncryptionKey = "MAKV2SPBNI99212";
                byte[] saltB = new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 };
                using (Aes encryptor = Aes.Create())
                {
                    encryptor.KeySize = 256;
                    encryptor.BlockSize = 128;

                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, saltB, 1000);
                    encryptor.Key = pdb.GetBytes(encryptor.KeySize / 8);
                    encryptor.IV = pdb.GetBytes(encryptor.BlockSize / 8);

                    using (FileStream fsInput = new FileStream(inputFilePath, FileMode.Open))
                    {
                        using (CryptoStream cs = new CryptoStream(fsInput, encryptor.CreateDecryptor(), CryptoStreamMode.Read))
                        {

                            using (FileStream fsOutput = new FileStream(outputfilePath, FileMode.Create))
                            {
                                int data;
                                while ((data = cs.ReadByte()) != -1)
                                {
                                    fsOutput.WriteByte((byte)data);
                                }

                            }
                        }
                        isFileDecrypted = true;
                        return isFileDecrypted;
                    }

                }
                
            }
            catch
            {
                //MessageBox.Show("File is Decypted", "The file is encrypted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return isFileDecrypted;
            }

            
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
            try
            {
                if (rbFile.Checked || rbFolder.Checked || rbPhoto.Checked || rbRar.Checked)
                {
                    if (cboxOption.SelectedIndex == 0) //encryption tab
                    {
                        txtFilePathEn.Text = lblSelectedFile.Text;
                        if (rbFile.Checked == true)
                        {
                            photoBoxEn.Visible = false;
                            txtFileEnContent.Text = File.ReadAllText(fileToOpen.FileName);
                        }
                        else if (rbPhoto.Checked == true)
                        {
                            photoBoxEn.Visible = true;
                            // display image in picture box  
                            photoBoxEn.Image = new Bitmap(fileToOpen.FileName);
                        }
                        else if (rbRar.Checked == true)
                        {
                            photoBoxEn.Visible = false;
                            txtFileEnContent.Text = "Rar file";

                        }
                        tControl.SelectedTab = Encrypt;
                        Encrypt.Show();

                    }
                    else if (cboxOption.SelectedIndex == 1) //decryption tab
                    {
                        txtFilePathDe.Text = lblSelectedFile.Text;
                        //txtFileDe.Text = File.ReadAllText(fileToOpen.FileName); 
                        //Show the decrypted file
                        tControl.SelectedTab = Decrypt;
                        Decrypt.Show();
                    }
                }
            }
            catch (Exception invalidAttachmentType)
            {
                MessageBox.Show("Check correct attachement type","Invalid attachement type", MessageBoxButtons.OK,MessageBoxIcon.Error);
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
            cleanTabOne();
            cleanTabTwo();
            ChooseFile.Show();
        }

        private void btnDoneDe_Click(object sender, EventArgs e)
        {
            string fPath = txtFilePathDe.Text.ToString();
            if (cboxDeleteDe.Checked == true)
            {
                deleteAfter(fPath);

            }
            cleanTabOne();
            cleanTabThree();
            ChooseFile.Show();
        }

        private void Decrypt_Click(object sender, EventArgs e)
        {

        }

        private void browseDe_Click(object sender, EventArgs e)
        {
            //call the decryption method/function
            //saveFile();
            //Register validateKey = new Register();
            //bool isKeySame = Register.validatePassword(txtKeyEn.Text, txtRepeatKeyEn.Text);
            try
            {
                if (txtKeyDe.Text != "")
                {
                    string fileName = txtFilePathDe.Text;
                    string fileExtension = Path.GetExtension(txtFilePathDe.Text); // extension of the filePath
                    //string input = fileName + fileExtension; // original filePath + the extension
                    string output = fileName + "_dec" + fileExtension; // the new encrypted file path
                    bool isDecoded = this.Decode(fileName, output); // encode file and save it as output

                    if (isDecoded == true)
                    {
                        MessageBox.Show("File is Decrypted", "The file is decrypted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lblDe.Text = output;
                        if (rbFile.Checked == true)
                        {
                            photoBoxDe.Visible = false;
                            txtFileDe.Text = File.ReadAllText(lblDe.Text);
                        }
                        else if (rbRar.Checked == true)
                        {
                            photoBoxDe.Visible = false;
                            txtFileDe.Text = "Rar File";
                        }   
                        else if (rbPhoto.Checked == true)
                        {
                            photoBoxDe.Visible = true;
                            // display image in picture box 
                            photoBoxDe.Image = new Bitmap(lblDe.Text);
                        }
                        else
                        {
                            MessageBox.Show("Please check the correct attachement type", "Incorrect Attachement Type", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        cboxDeleteDe.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("File not Decrypted", "The file did not get decrypted", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
            }
            catch (IOException ex)
            {
                MessageBox.Show("Enter encryption key", "Enter key", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void browseEn_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUserDeleteId.Text != "")
                {
                    con.Open();
                    adapt = new SqlDataAdapter();
                    string sqlDelete = "DELETE [user] WHERE Id='" + txtUserDeleteId.Text + "'";
                    cmd = new SqlCommand();

                    adapt.DeleteCommand = new SqlCommand(sqlDelete, con);
                    int deleteUser = adapt.DeleteCommand.ExecuteNonQuery();

                    if (deleteUser > 0) { 
                        MessageBox.Show("User Removed", "user removed", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }
                    else { 
                        MessageBox.Show("User Id not found", "Id not found", MessageBoxButtons.OK,MessageBoxIcon.Error);
                        txtUserDeleteId.Focus();
                    }

                    cmd.Dispose();
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Enter user id", "User Id not entered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUserDeleteId.Focus();
                }
                
            }
            catch (Exception ex)
            {

            }
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                
                con.Open();

                string sql;
                adapt = new SqlDataAdapter();
                sql = @"Select * FROM [user]";
                cmd = new SqlCommand(sql, con);
                ds = new DataSet();
                adapt.SelectCommand = cmd;
                adapt.Fill(ds, "Info");
                dataGridViewDelete.DataSource = ds;
                dataGridViewDelete.DataMember = "Info";
                lblUserCount.Text = userCount().ToString();
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUserDeleteId.Clear();
        }

        private void lblLogOff_Click(object sender, EventArgs e)
        {
            LogIn toLogOff = new LogIn();
            toLogOff.Show();
            this.Close();
        }

        private void lblUserCount_Click(object sender, EventArgs e)
        {

        }

        private void txtFileEn_TextChanged(object sender, EventArgs e)
        {

        }

        private void rbPhoto_CheckedChanged(object sender, EventArgs e)
        {
            enableChoose();
        }

        private void rbRar_CheckedChanged(object sender, EventArgs e)
        {
            enableChoose();
        }

        private void btnCancelEn_Click(object sender, EventArgs e)
        {
            cleanTabTwo();

        }

        private void btnCancelDe_Click(object sender, EventArgs e)
        {
            cleanTabThree();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            Register validateKey = new Register();
            bool isKeySame = Register.validatePassword(txtKeyEn.Text, txtRepeatKeyEn.Text);
            try
            {
                if (txtKeyEn.Text != "" && txtRepeatKeyEn.Text != "" && (isKeySame == true))
                {
                    string fileName = txtFilePathEn.Text;
                    string fileExtension = Path.GetExtension(txtFilePathEn.Text); // extension of the filePath
                    //string input = fileName; // original filePath + the extension
                    string output = fileName + "_enc" + fileExtension; // the new encrypted file path
                    bool isEncypted = this.Encode(fileName, output); // encode file and save it as output

                    if (isEncypted == true)
                    {
                        MessageBox.Show("File is Encypted", "The file is encrypted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lblEn.Text = output;
                        cboxDeleteEn.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("File not Encrypted", "The file did not get encrypted", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
            }
            catch(Exception ex)
            {

            }
            //catch(IOException ex)
            //{
               // MessageBox.Show("Enter encryption key", "Enter key", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //} 
        }

        private void lblChoosenFile_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cleanTabOne();
        }
    }
}

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
        SqlDataReader myReader;
        string conString = @"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=
        |DataDirectory|\App_Data\CryptographyDB.mdf; Integrated Security = True";

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
            btnSearch.Enabled = false;
            dataGridViewDelete.Visible = false;
            lblsuggesstions.Visible = false;
            lblRecordsCount.Text = "0";

            
            tControl.TabPages.Remove(Admin);
        }

        private void LandingPage_Load_1(object sender, EventArgs e)
        {
            
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
            btnProceed.Enabled = false;
            
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
            if(cboxOption.SelectedIndex == 1 || cboxOption.SelectedIndex == 2)
            {
                btnProceed.Enabled = true; 
            }
        }

        private void attachementType()
        {
            fileToOpen = new OpenFileDialog();
            fileToOpen.Title = "Select File";
            fileToOpen.InitialDirectory = @"C:\";
            fileToOpen.Filter = "All files (*.*)|*.*|Text File (*.txt)|*.txt|Image Files(*.jpg; *.jpeg; *.gif; *.png; *.bmp)| *.jpg; *.jpeg; *.gif; *.png; *.bmp)|RAR|*.rar";
            fileToOpen.FilterIndex = 1;
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

        public static string generateString() // returns three characters //concatinate the chars to the key if its already taken (recommendation)
        {
            string aphal = "abcdefghijklmnopqrstuvwxyz0123456789";
            string ran = "";

            Random rand = new Random();
            for (int i = 0; i < 3; i++)
            {
                int randAlph = rand.Next(36);
                ran += aphal.ElementAt(randAlph);
            }

            return ran;
        }



        public int userCount()
        {
            
            try
            {
                int usersAvailable = 0;
                string sqlUsers = @"SELECT COUNT(*) FROM [user]";
                string sqlKeys = @"SELECT COUNT(*) FROM [userKey]";
                using (var con = new SqlConnection(conString))
                    if (cBoxShowDatabase.SelectedIndex == 1)
                    {
                        using (cmd = new SqlCommand(sqlUsers, con))
                        {
                            con.Open();
                            usersAvailable = (int)cmd.ExecuteScalar();
                            con.Close();
                        }
                    }
                    else if (cBoxShowDatabase.SelectedIndex == 2)
                    {
                        using (cmd = new SqlCommand(sqlKeys, con))
                        {
                            con.Open();
                            usersAvailable = (int)cmd.ExecuteScalar();
                            con.Close();
                        }
                    }
                    return usersAvailable;
                
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public string attachementTypeSelected()
        {
            string attachedType = "other";
            if (rbFile.Checked == true)
            {
                attachedType = "Text File";
            }
            else if (rbPhoto.Checked == true) { 
                attachedType = "Photo";
            }
            else if (rbRar.Checked == true) {
                attachedType = "Rar File"; 
            }
            return attachedType;
        }

        public int getUserId()
        {
            string sqlId = @"SELECT * FROM [user] WHERE userName LIKE '" + lblWelcome.Text+ "'";
            using (var con = new SqlConnection(conString))
                adapt = new SqlDataAdapter();
                ds = new DataSet();
                cmd = new SqlCommand(sqlId, con);
                adapt.SelectCommand = cmd;
                adapt = new SqlDataAdapter(cmd);
                adapt.Fill(ds);
                int loginID = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                return loginID;  
        }

        public bool insertUserKey(int id, string  path, string attachedType, string keyEntered)
        {
            
            
            string query = @"INSERT INTO [userKey]([userId],[attachementName],[attachementType],[key]) VALUES(@userId, @attachementName, @attachementType, @key)";
            using (var con = new SqlConnection(conString))
                using (var cmd = new SqlCommand(query, con))
                {
              
                    cmd.Parameters.AddWithValue("@userId", id); // id of the user logged in
                    cmd.Parameters.AddWithValue("@attachementName", path);
                    cmd.Parameters.AddWithValue("@attachementType", attachedType);
                    cmd.Parameters.AddWithValue("@key", keyEntered);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        return true;
                    }
                    catch (SqlException err)
                    {
                        
                        lblsuggesstions.Visible = true;
                        lblsuggesstions.Text = "Suggested Key:"+ txtRepeatKeyEn.Text + generateString();
                        txtKeyEn.Clear();
                        txtRepeatKeyEn.Clear();
                        txtKeyEn.Focus();
                        return false;   
                    }
                }   
        }
        private bool Encode(string inputFilePath, string outputfilePath, string EncryptionKey)
        {
            
            try
            {
                //string EncryptionKey = "MAKV2SPBNI99212"; //include key in as the parameter
                //string EncryptionKey = txtRepeatKeyEn.Text; //include key in as the parameter
                byte[] saltByte = new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 };
                bool isFileEncrypted = false;
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
                            if(rbFile.Checked == true || rbRar.Checked == true)
                            {
                                using (FileStream fsInput = new FileStream(inputFilePath, FileMode.Open))
                                {
                                    int data;
                                    while ((data = fsInput.ReadByte()) != -1)
                                    {
                                        cs.WriteByte((byte)data);
                                    }
                                    fsInput.Close();
                                }
                            }
                            else
                            {
                                using (var stream = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                                {
                                    int data;
                                    while ((data = stream.ReadByte()) != -1)
                                    {
                                        cs.WriteByte((byte)data);
                                    }
                                    stream.Close();
                                }
                            }
                        }
                       
                    }
                    string fileSelectedName = Path.GetFileName(inputFilePath);
                    bool isInserted = insertUserKey(getUserId(), fileSelectedName, attachementTypeSelected(), EncryptionKey);
                    if(isInserted == true)
                    {
                        isFileEncrypted = true;
                    }
                        
                }
                return isFileEncrypted;

            }
            catch(Exception ex)
            {
                //MessageBox.Show("File is Encypted"+ex, "The file is encrypted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            
            
        }

        private bool Decode(string inputFilePath, string outputfilePath, string EncryptionKey)
        {
            bool isFileDecrypted = false;
            try
            {
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

                    }
                    isFileDecrypted = true;
                }
                return isFileDecrypted;
            }
            catch(CryptographicException cryptoerr)
            {
                MessageBox.Show("Incorrect decryption key","Incorrect Key",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtKeyDe.Focus();
                return false;
            } 
            //string EncryptionKey = "MAKV2SPBNI99212";         
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

                    if (cboxOption.SelectedIndex == 1 && !(lblSelectedFile.Text.Contains("_enc"))) //encryption tab
                    {
                        txtFilePathEn.Text = lblSelectedFile.Text;
                        if (rbFile.Checked == true && ((lblSelectedFile.Text.Contains(".txt")) || (lblSelectedFile.Text.Contains(".docx")) || (lblSelectedFile.Text.Contains(".pdf"))))
                        {
                            photoBoxEn.Visible = false;
                            txtFileEnContent.Text = File.ReadAllText(fileToOpen.FileName);
                            tControl.SelectedTab = Encrypt;
                            Encrypt.Show();

                        }
                        else if (rbPhoto.Checked == true)
                        {
                            photoBoxEn.Visible = true;
                            // display image in picture box  
                            photoBoxEn.Image = new Bitmap(fileToOpen.FileName);
                            tControl.SelectedTab = Encrypt;
                            Encrypt.Show();

                        }
                        else if (rbRar.Checked == true && (lblSelectedFile.Text.Contains(".rar")))
                        {
                            photoBoxEn.Visible = false;
                            txtFileEnContent.Text = "Rar file";
                            tControl.SelectedTab = Encrypt;
                            Encrypt.Show();

                        }
                        else
                        {
                            MessageBox.Show("Please select the correct file", "Selected File incorect", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (cboxOption.SelectedIndex == 2 && (lblSelectedFile.Text.Contains("_enc") && !(lblSelectedFile.Text.Contains("_dec")))) //decryption tab
                    {
                        
                        if (rbFile.Checked == true && ((lblSelectedFile.Text.Contains(".txt")) || (lblSelectedFile.Text.Contains(".docx")) || (lblSelectedFile.Text.Contains(".pdf"))))
                        {
                          
                            txtFilePathDe.Text = lblSelectedFile.Text;
                            tControl.SelectedTab = Decrypt;
                            Decrypt.Show();

                        }
                        else if (rbPhoto.Checked == true)
                        {
                            
                            txtFilePathDe.Text = lblSelectedFile.Text;
                            tControl.SelectedTab = Decrypt;
                            Decrypt.Show();

                        }
                        else if (rbRar.Checked == true && (lblSelectedFile.Text.Contains(".rar")))
                        {
                            txtFilePathDe.Text = lblSelectedFile.Text;
                            tControl.SelectedTab = Decrypt;
                            Decrypt.Show();

                        }
                        else
                        {
                            MessageBox.Show("Please select the correct file", "Selected File incorect", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select the correct file", "Selected File incorect", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show("Please select an Attachement Type and Choose a file", "Attachement Type", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   
                }
            }
            catch (Exception invalidAttachmentType)
            {
                MessageBox.Show("Please select the correct file", "Selected File incorect", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            try
            {
                if (txtKeyDe.Text != "")
                {
                    
                        string fileName = txtFilePathDe.Text;
                        string fileExtension = Path.GetExtension(txtFilePathDe.Text); // extension of the filePath
                        string output = fileName.Replace("_enc", "_dec");
                        //string input = fileName + fileExtension; // original filePath + the extension
                        //string output = fileName + "_dec" + fileExtension; // the new encrypted file path
                        
                        bool isDecoded = this.Decode(fileName, output, txtKeyDe.Text); // encode file and save it as output
                        if (isDecoded == true)
                        {
                            MessageBox.Show("File Decrypted Successfully", "The file is decrypted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            lblDe.Text = output;
                            if (rbFile.Checked == true && ((lblSelectedFile.Text.Contains(".txt")) || (lblSelectedFile.Text.Contains(".docx")) || (lblSelectedFile.Text.Contains(".pdf"))))
                        {
                                photoBoxDe.Visible = false;
                                txtFileDe.Text = File.ReadAllText(lblDe.Text);
                            }
                            else if (rbRar.Checked == true && (lblSelectedFile.Text.Contains(".rar")))
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
                    
                }
                else
                {
        
                    MessageBox.Show("Please enter key to decrypt the file", "Failed to decrypt", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    using (var con = new SqlConnection(conString))
                        
                        using (adapt = new SqlDataAdapter()) {
                            string sqlDelete = "";
                            if (cBoxShowDatabase.SelectedIndex == 1)
                            {
                                sqlDelete = "DELETE [user] WHERE Id='" + txtUserDeleteId.Text + "'";
                            }
                            else if (cBoxShowDatabase.SelectedIndex == 2)
                            {
                                sqlDelete = "DELETE [userKey] WHERE KeyId='" + txtUserDeleteId.Text + "'";
                            }
                            adapt.DeleteCommand = new SqlCommand(sqlDelete, con);
                            con.Open();
                            int deleteRecord = adapt.DeleteCommand.ExecuteNonQuery();
                            con.Close();
                            if (deleteRecord > 0)
                            {
                                MessageBox.Show("Id Removed", "Id removed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                MessageBox.Show("Id not found", "Id not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtUserDeleteId.Focus();
                            }
                        }
                        cmd.Dispose();
                }
                else
                {
                    MessageBox.Show("Enter id", "Id not entered", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                dataGridViewDelete.Visible = true;
                if (cBoxShowDatabase.SelectedIndex == 0) // users
                {
                    dataGridViewDelete.Visible = false;
                    //btnSearch.Enabled = true;
                }
                else if (cBoxShowDatabase.SelectedIndex == 1)
                {
                    using (var con = new SqlConnection(conString))
                        if (con.State != ConnectionState.Open)
                            con.Open();
                        string sqlUsers = @"Select * FROM [user]";
                        adapt = new SqlDataAdapter();
                        ds = new DataSet();
                        cmd = new SqlCommand(sqlUsers, con);
                        adapt.SelectCommand = cmd;
                        adapt.Fill(ds, "UserInfo");
                        dataGridViewDelete.DataSource = ds;
                        dataGridViewDelete.DataMember = "UserInfo";
                        lblRecordsCount.Text = userCount().ToString();
                        if (con.State == ConnectionState.Open)
                            con.Close();
                }
                else if(cBoxShowDatabase.SelectedIndex == 2)
                {
                    using (var con = new SqlConnection(conString))
                        if (con.State != ConnectionState.Open)
                            con.Open();
                        string sqlKeys = @"Select * FROM [userKey]";
                        adapt = new SqlDataAdapter();
                        ds = new DataSet();
                        cmd = new SqlCommand(sqlKeys, con);
                        adapt.SelectCommand = cmd;
                        adapt.Fill(ds, "KeyInfo");
                        dataGridViewDelete.DataSource = ds;
                        dataGridViewDelete.DataMember = "KeyInfo";
                        lblRecordsCount.Text = userCount().ToString();
                        if (con.State == ConnectionState.Open)
                            con.Close();
                }
                else
                {
                    MessageBox.Show("Please select the table to show","Select table",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                
               
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dataGridViewDelete.Visible = false;
            btnSearch.Enabled = false;
            lblRecordsCount.Text = "x";
            cBoxShowDatabase.SelectedIndex = 0;
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
                    string output = "";
                    if (fileName.Contains("_dec"))
                    {
                        output = fileName.Replace("_dec", "_enc");
                    }
                    else
                    {
                        output = Path.ChangeExtension(fileName, "_enc" + fileExtension);
                    }
                    
                    //string input = fileName; // original filePath + the extension
                    //string output = fileName + "_enc" + fileExtension; // the new encrypted file path
                    bool isEncypted = this.Encode(fileName, output, txtRepeatKeyEn.Text); // encode file and save it as output
                    
                    if (isEncypted == true)
                    {
                        lblEn.Text = output;
                        cboxDeleteEn.Enabled = true;
                        MessageBox.Show("File Encypted Successfully. Please do not change the file name", "The file is encrypted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    else
                    {
                        MessageBox.Show("File not Encrypted", "Failed to Encrypt the file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
            }
            catch(Exception ex)
            {

            }
        }

        private void lblChoosenFile_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cleanTabOne();
            cboxOption.SelectedIndex = 0;
        }

        private void cBoxShowDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxShowDatabase.SelectedIndex == 1 || cBoxShowDatabase.SelectedIndex == 2)
                btnSearch.Enabled = true;
        
        }
    }
}

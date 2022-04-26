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
            fileToOpen.Filter = "All files (*.*)|*.*|Text File (*.txt)|*.txt|Images (*.png)|*.jpg|PDF Documents (.pdf)|*.pdf|ZIP|*.zip|RAR|*.rar";
            fileToOpen.FilterIndex = 2;
            fileToOpen.ShowDialog();

            if (rbFile.Checked)
            {
                if (openFileDialog1.FileName != "")
                {
                    lblChoosenFile.Text = fileToOpen.FileName;
                }
                else
                {
                    lblChoosenFile.Text = "You did not select the file!";
                }
            }
            else if (rbPhoto.Checked)
            {

            }
            else if (rbRar.Checked)
            {

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
            else
            {

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
                string encText = txtFileEn.Text;
                string decText = txtFileDe.Text;
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
                    txtFileEn.Text = File.ReadAllText(fileToOpen.FileName);
                    tControl.SelectedTab = Encrypt;
                    Encrypt.Show();

                }
                else if (cboxOption.SelectedIndex == 1)
                {
                    txtFilePathDe.Text = lblChoosenFile.Text;
                    txtFileDe.Text = File.ReadAllText(fileToOpen.FileName);
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
            //call the decryption method/function
            saveFile();
            cboxDeleteDe.Enabled = true;
        }

        private void browseEn_Click(object sender, EventArgs e)
        {
            //call the Encryption method/function
            Register validateKey = new Register();
            bool isKeySame = Register.validatePassword(txtKeyEn.Text , txtRepeatKeyEn.Text);
            try
            {
                if (txtKeyEn.Text != "" && txtRepeatKeyEn.Text != "" && (isKeySame == true))
                {
                    saveFile();
                    cboxDeleteEn.Enabled = true;
                }
            }
            catch(IOException ioEx)
            {
                MessageBox.Show("Enter encryption key", "Enter key", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                adapt = new SqlDataAdapter();
                string sqlDelete = "DELETE [user] WHERE Id='"+txtUserDeleteId.Text+"'";
                //string sqlDeleteAll = "DELETE * FROM [user]";
                cmd = new SqlCommand();

                adapt.DeleteCommand = new SqlCommand(sqlDelete, con);
                adapt.DeleteCommand.ExecuteNonQuery();

                MessageBox.Show("User Removed", "user removed", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

                cmd.Dispose();
                con.Close();
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
    }
}

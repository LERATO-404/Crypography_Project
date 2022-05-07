using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace Crypyography
{
    public partial class LogIn : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader myReader;

        private static string encryptPass = "";
        
        public LogIn()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=
            C:\Users\LAVAS\Desktop\CMPG 215 - INFORMATION SECURITY\cryptography-project\Crypyography\App_Data\CryptographyDB.mdf;Integrated Security=True";
            con = new SqlConnection(conString);
        }

        /*=================================Methods===============================*/

        public static string decryptPassword(string encodedData)
        {
            try
            {
                System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder utf8Decode = encoder.GetDecoder();
                byte[] todecode_byte = Convert.FromBase64String(encodedData);
                int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                char[] decoded_char = new char[charCount];
                utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                string result = new String(decoded_char);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        private static string encryptPassword(string pass)
        {
            try
            {
                byte[] encData_byte = new byte[pass.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(pass);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        /*=================================Methods===============================*/
        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                con.Open();
                if (txtUserNameEmail.Text != "" && txtPasswordLog.Text != "")
                {
                    
                    encryptPass = encryptPassword(txtPasswordLog.Text);
                    string userNameAdmin = txtUserNameEmail.Text.ToLower();
                       
                    string query = "SELECT * from [user] WHERE username ='" + txtUserNameEmail.Text + "' AND password ='" + encryptPass + "'";
                    
                    if (txtPasswordLog.Text == decryptPassword(encryptPass))
                    {
                        
                        
                        cmd = new SqlCommand(query, con);
                        myReader = cmd.ExecuteReader();
                        if (myReader.HasRows)
                        {
                            LandingPage landingP = new LandingPage();
                            if (userNameAdmin == "admin"  && decryptPassword(encryptPass) == "admin" )
                            {
                                //landingP.Admin.Enabled = true;
                                landingP.tControl.TabPages.Add(landingP.Admin); // show admin tab when the admin log in
                            }
                            
                            landingP.Show(); //show landing page
                            landingP.lblWelcome.Text = txtUserNameEmail.Text;
                            myReader.Close();
                            this.Hide();

                        }
                        else
                        {
                            MessageBox.Show("Data not found", "Information");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Username or Password is empty", "Information");
                }
                con.Close();
                
                
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }
        }

        

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblSignIn_Click(object sender, EventArgs e)
        {
            Register signIn = new Register();
            signIn.Show();
            this.Hide();
        }
    }
}

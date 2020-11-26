using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public partial class Login_Form : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
    static String decryptedpwd;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private string Encrypt(string clearText)
    {
        string EncryptionKey = "MAKV2SPBNI99212";
        byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }
                clearText = Convert.ToBase64String(ms.ToArray());
            }
        }
        return clearText;
    }

    private string Decrypt(string cipherText)
    {
        string EncryptionKey = "MAKV2SPBNI99212";
        byte[] cipherBytes = Convert.FromBase64String(cipherText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                    cs.Close();
                }
                cipherText = Encoding.Unicode.GetString(ms.ToArray());
            }
        }
        return cipherText;
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        con.Open();
        string str = "select * from login_tbl where username='" + txtUsername.Text + "'";
        DataTable dt = new DataTable();
        SqlDataAdapter adpt = new SqlDataAdapter(str, con);
        adpt.Fill(dt);
        string uname, pass;
        if (dt.Rows.Count > 0)
        {
            uname = dt.Rows[0]["username"].ToString();
            pass = dt.Rows[0]["password"].ToString();
            decryptedpwd = Decrypt(pass);
            if (uname == txtUsername.Text && decryptedpwd == txtPassword.Text)
            {
                Response.Write("<script> alert('Login Successful') </script>");
            }
            else
            {
                Response.Write("<script> alert('Login Unsuccessful') </script>");
            }
        }
        else
        {
            Response.Write("<script> alert('Please enter username or password!!!') </script>");
        }
        con.Close();
    }
    protected void btnInsert_Click(object sender, EventArgs e)
    {
        con.Open();
        string str = "insert into login_tbl (username,password) values (@user,@pass)";
        SqlCommand cmd = new SqlCommand(str, con);
        cmd.Parameters.AddWithValue("@user", txtUsername.Text.Trim());
        cmd.Parameters.AddWithValue("@pass", Encrypt(txtPassword.Text.Trim()));
        cmd.ExecuteNonQuery();
        Response.Write("<script> alert('Inserted') </script>");
        con.Close();
    }
}
using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace BasicEncryption
{
    public partial class Form1 : Form
    {
        private enum Modes { EncryptNew = 1, EncryptExisting = 2, Decrypt = 3 }
        private Modes currentMode;
        public Form1()
        {
            InitializeComponent();
        }

        void EncryptNew()
        {
            string input;
            using (Aes myAes = Aes.Create())
            {
                FileInfo fileInfo = new FileInfo(srcFileBox.Text);
                if (!IsPlainText(fileInfo.Extension))
                    input = Convert.ToBase64String(File.ReadAllBytes(srcFileBox.Text));
                else
                    input = File.ReadAllText(srcFileBox.Text);
                // Encrypt the string to an array of bytes.
                byte[] encrypted = EncryptStringToBytes_Aes(input, myAes.Key, myAes.IV);

                //Display the original data and the decrypted data.
                File.WriteAllBytes(destFilePath.Text, encrypted);
                File.WriteAllBytes(keyPathBox.Text, myAes.Key);
                File.WriteAllBytes(ivPathBox.Text, myAes.IV);

            }
        }

        private void EncryptExisting()
        {
            string input;
            FileInfo fileInfo = new FileInfo(srcFileBox.Text);
            if (!IsPlainText(fileInfo.Extension))
                input = Convert.ToBase64String(File.ReadAllBytes(srcFileBox.Text));
            else
                input = File.ReadAllText(srcFileBox.Text);
            // Encrypt the string to an array of bytes.
            byte[] encrypted = EncryptStringToBytes_Aes(input, File.ReadAllBytes(keyPathBox.Text), File.ReadAllBytes(ivPathBox.Text));
            File.WriteAllBytes(destFilePath.Text, encrypted);
        }

        private void Decrypt()
        {
            string result;
            FileInfo fileInfo = new FileInfo(destFilePath.Text);
            result = DecryptStringFromBytes_Aes(File.ReadAllBytes(srcFileBox.Text), File.ReadAllBytes(keyPathBox.Text), File.ReadAllBytes(ivPathBox.Text));
            if (!IsPlainText(fileInfo.Extension))
                File.WriteAllBytes(destFilePath.Text, Convert.FromBase64String(result));
            else
                File.WriteAllText(destFilePath.Text, result);
        }

        static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }


            // Return the encrypted bytes from the memory stream.
            return encrypted;

        }

        static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;

        }

        private void ivBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = string.Empty;
            saveFileDialog1.FileName = string.Empty;
            if (currentMode == Modes.EncryptNew)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    ivPathBox.Text = saveFileDialog1.FileName;
            }
            else if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ivPathBox.Text = openFileDialog1.FileName;
            }
        }

        private void keyBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = string.Empty;
            saveFileDialog1.FileName = string.Empty;
            if (currentMode == Modes.EncryptNew)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    keyPathBox.Text = saveFileDialog1.FileName;
            }
            else if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                keyPathBox.Text = openFileDialog1.FileName;
            }
        }

        private void srcBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = string.Empty;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                srcFileBox.Text = openFileDialog1.FileName;
            }
        }

        private void destBrowse_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = string.Empty;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                destFilePath.Text = saveFileDialog1.FileName;
            }
        }

        private void encBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (encBtn.Checked)
                currentMode = Modes.EncryptNew;
            //label5.Text = currentMode.ToString();
        }

        private void encryptBtn2_CheckedChanged(object sender, EventArgs e)
        {
            if (encryptBtn2.Checked)
                currentMode = Modes.EncryptExisting;
            //label5.Text = currentMode.ToString();
        }

        private void decryptBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (decryptBtn.Checked)
                currentMode = Modes.Decrypt;
            //label5.Text = currentMode.ToString();
        }

        private bool CheckFields => !(ivPathBox.Text.Equals(string.Empty) || keyPathBox.Text.Equals(string.Empty) || srcFileBox.Text.Equals(string.Empty) || destFilePath.Text.Equals(string.Empty));

        private bool IsPlainText(string ext)
        {
            string[] extensions = {".TXT",".CSV",".JSON",".YAML",".YML",".XML","HTM","HTML" };
            foreach (string e in extensions)
            {
                if (ext.ToUpper().Equals(e))
                    return true;
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckFields)
            {
                switch (currentMode)
                {
                    case Modes.EncryptNew:
                        EncryptNew();
                        break;
                    case Modes.EncryptExisting:
                        EncryptExisting();
                        break;
                    case Modes.Decrypt:
                        Decrypt();
                        break;
                    default:
                        MessageBox.Show("Please select an action!", "Action is required!");
                        break;
                }
                if (currentMode > 0)
                   MessageBox.Show("Files processed successfully!", "Complete!");
            }
            else
            {
                MessageBox.Show("All file paths are required!", "Missing required fields.");
            }
        }
    }
}

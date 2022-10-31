namespace Windows_Forms_NED
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Net;
    using System.Diagnostics;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //Initialise Settings
        private void Form1_Load(object sender, EventArgs e)
        {
            keyValue.Text = Usersettings.Default.DefaultKey.ToString();
            key = Usersettings.Default.DefaultKey;
            recursionValue.Text = Usersettings.Default.DefaultRec.ToString();
            recursion = Usersettings.Default.DefaultRec;

            maxOutputWarning = Usersettings.Default.OutputWarning;

            this.Icon = new Icon("NED.ico");

            ToolTip tt = new ToolTip();
            tt.SetToolTip(pictureBox1, "Swap Input/Output");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            (richTextBox1.Text, richTextBox2.Text) = (richTextBox2.Text, richTextBox1.Text);
            
            
            if (radioButton1.Checked)
            {
                radioButton1.Checked = false;
                radioButton2.Checked = true;
            }
            else
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
        }

        //Open Settings Form
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show(Owner);
        }

        //Key Value
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        //Import Files
        private void importtxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Generic Text File|*.txt|NED Text File|*.ned";
            ofd.Title = "Import Text";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(ofd.FileName);
                string result = sr.ReadToEnd();
                sr.Close();

                switch (ofd.FilterIndex)
                {
                    case 1:
                        richTextBox1.Text = result;
                        break;

                    case 2:
                        try
                        {
                            string[] strings = result.Split('|');
                            keyValue.Text = strings[0];
                            recursionValue.Text = strings[1];
                            richTextBox1.Text = strings[2];
                            richTextBox2.Text = strings[3];
                            radioButton4.Checked = Convert.ToBoolean(strings[4]);
                            radioButton3.Checked = !Convert.ToBoolean(strings[4]);
                        }
                        catch
                        {
                            MessageBox.Show("Outdated File or Incorrect Format. Data may be lost. Re-exporting is recommended.", "File Load Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;

                }
            }
        }

        //Export Existing Files
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Usersettings.Default.ShowFileWarn == true)
            {
                MessageBox.Show("This will export the existing content. You can disable this alert in options.", "Export Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Generic Text File|*.txt|NED Text File|*.ned";
            sfd.Title = "Export Text";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                switch (sfd.FilterIndex)
                {
                    //Text Files
                    case 1:
                        StreamWriter sw = new StreamWriter(sfd.FileName);
                        sw.Write(richTextBox2.Text);
                        sw.Close();
                        break;

                    //Ned Files
                    case 2:
                        StreamWriter sw1 = new StreamWriter(sfd.FileName);
                        sw1.Write(keyValue.Text + "|" + recursionValue.Text + "|" + richTextBox1.Text + "|" + richTextBox2.Text + "|" + radioButton4.Checked);
                        sw1.Close();
                        break;
                }
            }
        }

        //Process & Export 
        bool isExporting = false;
        private void exportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Usersettings.Default.ShowFileWarn == true)
            {
                MessageBox.Show("This will process the input with the Key and Recursion and export it. You can disable this alert in options.", "Export Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            Decider();

            isExporting = true;
        }

        // Apply variables for processing
        private void inputText_Update(object sender, EventArgs e)
        {
            inputText = richTextBox1.Text;
            textCalc = richTextBox1.Text;


            preview = previewCheckbox.Checked;
            if (inputText != "" && preview)
                PreviewCalc();
        }

        private void key_Update(object sender, EventArgs e)
        {
            if (keyValue.Text == "")
                return;
            key = Convert.ToInt32(keyValue.Text);
        }

        private void recursion_Update(object sender, EventArgs e)
        {
            if (recursionValue.Text == "")
                return;
            recursion = Convert.ToInt32(recursionValue.Text);
            recursionCalc = recursion;
        }
        
        private void ProcessButton_Click(object sender, EventArgs e)
        {
            if (bgWorker.IsBusy)
            {
                if(MessageBox.Show("Are you sure you want to cancel the process?", "Cancel Process", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bgWorker.CancelAsync();
                    richTextBox2.Text = "Cancelling Operation. Please Wait";
                }
                else
                {
                    return;
                }
            }
            else
            {
                Decider();
            }
        }

        //Background Worker
        private void bgWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (bgWorker.CancellationPending)
            {
                e.Cancel = true;
            }
            if (radioButton1.Checked && radioButton4.Checked)
            {
                e.Result = Encrypt(inputText.ToUpper(), key, recursion);
            }
            else if(!radioButton1.Checked && radioButton4.Checked)
            {
                e.Result = Decrypt(inputText.ToUpper(), key, recursion);
            } 
            else if(radioButton1.Checked && !radioButton4.Checked)
            {
                e.Result = AsciiEncrypt(inputText, key, recursion);
            }
            else
            {
                e.Result = AsciiDecrypt(inputText, key, recursion);
            }
        }

        private void bgWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            ProcessButton.Text = "Process";
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message, "Error Detected");
            }
            else if (e.Cancelled)
            {
                richTextBox2.Text = "Operation Cancelled";
            }
            else if (isExporting)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Generic Text File|*.txt|NED Text File|*.ned";
                sfd.Title = "Export Text";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    switch (sfd.FilterIndex)
                    {
                        //Text Files
                        case 1:
                            StreamWriter sw = new StreamWriter(sfd.FileName);
                            sw.Write(e.Result);
                            sw.Close();
                            break;

                        //Ned Files
                        case 2:
                            StreamWriter sw1 = new StreamWriter(sfd.FileName);
                            sw1.Write(keyValue.Text + "|" + recursionValue.Text + "|" + richTextBox1.Text + "|" + e.Result + "|" + radioButton4.Checked);
                            sw1.Close();
                            break;
                    }
                }
            }
            else if(e.Result != null)
            {
                richTextBox2.Text = e.Result.ToString();
            }
            isExporting = false;
        }

        void PreviewCalc()
        {
            if (radioButton1.Checked && radioButton4.Checked)
            {
                richTextBox2.Text = Encrypt(inputText.ToUpper(), key, recursion);
            }
            else if (!radioButton1.Checked && radioButton4.Checked)
            {
                richTextBox2.Text = Decrypt(inputText.ToUpper(), key, recursion);
            }
            else if (radioButton1.Checked && !radioButton4.Checked)
            {
                richTextBox2.Text = AsciiEncrypt(inputText, key, recursion);
            }
            else
            {
                richTextBox2.Text = AsciiDecrypt(inputText, key, recursion);
            }
        }

        #region NED
        //NED Processes

        //Variable Declaration
        string inputText;
        int key;
        int recursion;
        int maxOutputWarning;
        bool preview;
        bool isCompleted;

        readonly string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";


        public static string textCalc;
        public static int recursionCalc;
        public static int lettersToProcess;

        //Process Info
        void Decider()
        {
            if(richTextBox1.Text.Length <= 0)
            {
                MessageBox.Show("Input Text Cannot Be Null.", "InputText Length Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Text Length Calculations
            if (radioButton1.Checked)
            {
                if (radioButton4.Checked)
                {
                    lettersToProcess = textCalc.Count(c => Char.IsLetter(c)) * (int)Math.Pow(2, recursionCalc);
                }
                else
                {
                    lettersToProcess = textCalc.Length * (int)Math.Pow(2, recursionCalc);
                }
            }
            else
            {
                if (radioButton4.Checked)
                {
                    lettersToProcess = textCalc.Count(c => Char.IsLetter(c));
                }
                else
                {
                    lettersToProcess = textCalc.Length / 2;
                }
                int tempLTP = lettersToProcess;
                while (recursionCalc != 1)
                {
                    lettersToProcess += tempLTP / 2;
                    tempLTP /= 2;
                    recursionCalc--;
                }
            }

            if(lettersToProcess <= 0)
            {
                MessageBox.Show("Letters to process exceeds integer bit length. Please shorten recursion", "Integer Bit Length Error");
                return;
            }

            //Key Verification
            if (key >= 75)
            {
                MessageBox.Show("Key must be below 75", "Key Length Error");
                return;
            }
            else if (key <= 0)
            {
                MessageBox.Show("Key must be above 0", "Key Length Error");
                return;
            }

            //Recursion Warning
            if (lettersToProcess >= maxOutputWarning)
            {
                if (MessageBox.Show("This will process " + lettersToProcess.ToString() + " characters. Do you want to continue?", "High Output Warning", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }

            //Process Text
            preview = false;
            isCompleted = false;
            
            bgWorker.RunWorkerAsync();
            ProcessButton.Text = "Cancel \nOperation";
        }

        string Encrypt(string encryptText, int additionKey, int recursion)
        {
            //Establish Form & Variables
            Form2 form2 = new Form2();

            if (preview != true)
                form2.Show();

            form2.Refresh();

            int letterIndex;
            
            List<int> numberOut = new List<int>();

            StringBuilder splitOut = new StringBuilder();
            StringBuilder punctuation = new StringBuilder();
            StringBuilder eText = new StringBuilder();

            try
            {
                for (int i = 0; i < recursion; i++)
                {
                    while (!bgWorker.CancellationPending && !isCompleted)
                    {
                        //Repeat Process Per Recursion
                        for (int j = 0; j < encryptText.Length; j++)
                        {
                            //Find the location of the letter in the alphabet
                            letterIndex = alphabet.IndexOf(encryptText[j]);

                            //Add location to list
                            numberOut.Add(letterIndex);

                            //Check if letter exists or punctuation
                            if (letterIndex == -1)
                            {
                                punctuation.Append(encryptText[j]);
                            }

                            //Display Letter Processed
                            form2.IncremProg();
                            
                            if(j % 1000 == 0)
                            {
                                form2.Update();
                            }
                        }

                        

                        for (int k = 0; k < numberOut.Count; k++)
                        {
                            //If Number is NOT punctuation
                            if (numberOut[k] != -1)
                            {
                                //Add Key
                                numberOut[k] += additionKey;
                                splitOut.Append(numberOut[k]);
                            }
                            else
                            {
                                //Add Punctuation ID
                                splitOut.Append('-');
                            }
                        }


                        //Clear Entered Text
                        encryptText = null;
                        eText.Clear();
                        int index = 0;

                        foreach (char c in splitOut.ToString())
                        {
                            //If character is NOT punctuation
                            if (c != '-')
                            {
                                //Write Text
                                eText.Append(alphabet[int.Parse(c.ToString())]);
                            }
                            else
                            {
                                //Write Punctuation
                                eText.Append(punctuation[index]);
                                index++;
                            }
                        }

                        //Clear Split for next recursion
                        splitOut = new StringBuilder();

                        encryptText = eText.ToString();

                        //Clear Number Output for next recursion
                        numberOut.Clear();
                        isCompleted = true;
                    }
                    isCompleted = false;
                }
            }
            catch (Exception ex)
            {
                //Error Messages
                if (preview)
                {
                    richTextBox2.Text = "An Error Occurred: " + ex;
                }
                else
                {
                    MessageBox.Show("An Error Occurred: " + ex, "Error");
                }
            }
            


            //form2.Refresh();

            //Close Progress Bar
            form2.Close();

            

            //Return Encrypted Text
            return encryptText;
        }

        string Decrypt(string decryptText, int subtractionKey, int recursion)
        {
            //Establish Form & Variables
            Form2 form2 = new Form2();
            if(preview != true)
                form2.Show();
            form2.Refresh();

            //string numberOut = "";
            //int[] joinOut = new int[0];
            int loopLength = 0;
            //string punctuation = "";

            StringBuilder numberOut = new StringBuilder();
            StringBuilder punctuation = new StringBuilder();

            List<int> joinOut = new List<int>();

            try
            {
                for (int i = 0; i < recursion; i++)
                {
                    while (!bgWorker.CancellationPending && !isCompleted)
                    {
                        //Repeat Process Per Recursion
                        for (int j = 0; j < decryptText.Length; j++)
                        {
                            //Convert input to numbers based on location
                            numberOut.Append(alphabet.IndexOf(decryptText[j]));

                            //Check if character is punctuation
                            if (alphabet.IndexOf(decryptText[j]) == -1)
                            {
                                punctuation.Append(decryptText[j]);
                            }

                            //Display Letter Processes
                            form2.IncremProg();
                            
                            if(j % 1000 == 0)
                            {
                                form2.Update();
                            }
                        }

                        //Clean output
                        decryptText = "";
                        loopLength = numberOut.Length;
                        int index = 0;

                        for (int j = 0; j < loopLength / 2; j++)
                        {
                            //If letter is NOT punctuation
                            if (numberOut[0] != '-')
                            {
                                //Expand Array 
                                //Array.Resize(ref joinOut, joinOut.Length + 1);

                                //Join 2 Numbers
                                //joinOut[j] = int.Parse(numberOut.ToString().Substring(0, 2));
                                joinOut.Add(Convert.ToInt32(numberOut.ToString().Substring(0, 2)));

                                //Subtract key
                                joinOut[j] -= subtractionKey;

                                //Remove Joined Num. from array
                                numberOut = numberOut.Remove(0, 2);

                                //Convert Joined Num. to text
                                decryptText += alphabet[joinOut[j]];
                            }
                            else
                            {
                                //Expand Array
                                //Array.Resize(ref joinOut, joinOut.Length + 1);

                                //Remove Punctuation ID
                                numberOut = numberOut.Remove(0, 2);

                                //Add Punctuation to output
                                decryptText += punctuation[index];

                                //Move punctuation index
                                index++;
                            }
                        }

                        //Clean Outputs
                        joinOut.Clear();
                        numberOut = new StringBuilder();

                        isCompleted = true;
                    }
                    isCompleted = false;
                }
            }
            catch (Exception ex)
            {
                //Error Messages
                if (preview)
                {
                    richTextBox2.Text = "An Error Occurred: " + ex;
                }
                else
                {
                    MessageBox.Show("An Error Occurred: " + ex, "Error");
                }
            }


            //Close Form
            form2.Close();

            //Return Decrypted Text
            return decryptText;
        }

        string AsciiEncrypt(string encryptText, int additionKey, int recursion)
        {
            List<int> decimalOut = new List<int>();
            StringBuilder eText = new StringBuilder();

            Form2 form2 = new Form2();
            if(preview != true)
                form2.Show();

            form2.Refresh();

            try
            {
                for (int i = 0; i < recursion; i++)
                {
                    while (!bgWorker.CancellationPending && !isCompleted)
                    {
                        /*foreach (char c in encryptText)
                        {
                            decimalOut.Add((int)c + additionKey);
                            form2.IncremProg();
                        }*/

                        for(int j = 0; j < encryptText.Length; j++)
                        {
                            decimalOut.Add((int)encryptText[j] + additionKey);
                            form2.IncremProg();
                            if (j % 1000 == 0)
                            {
                                form2.Update();
                            }
                        }

                        //decimalOut.RemoveAt(0);
                        encryptText = "";

                        foreach (int dec in decimalOut)
                        {
                            eText.Append(Convert.ToByte(dec).ToString("X"));
                        }

                        decimalOut.Clear();
                        encryptText = eText.ToString();
                        eText.Clear();
                        isCompleted = true;
                    }
                    isCompleted = false;
                }
            }
            catch (Exception ex)
            {
                //Error Messages
                if (preview)
                {
                    richTextBox2.Text = "An Error Occurred: " + ex;
                }
                else
                {
                    MessageBox.Show("An Error Occurred: " + ex, "Error");
                }
            }

            form2.Update();

            //Close Progress Bar
            form2.Close();

            return encryptText;
        }

        string AsciiDecrypt(string decryptText, int subtractionKey, int recursion)
        {
            List<string> joined = new List<string>();
            List<int> modified = new List<int>();

            Form2 form2 = new Form2();
            if (preview != true)
                form2.Show();
            form2.Refresh();

            try
            {
                for (int j = 0; j < recursion; j++)
                {
                    while (!bgWorker.CancellationPending && !isCompleted)
                    {
                        int outputLength = decryptText.Length / 2;
                        for (int i = 0; i < outputLength; i++)
                        {
                            joined.Add(decryptText.Substring(0, 2));
                            decryptText = decryptText.Remove(0, 2);

                            form2.IncremProg();
                            
                            if(i % 200 == 0)
                            {
                                form2.Update();
                            }
                        }

                        decryptText = "";

                        foreach (string i in joined)
                        {
                            modified.Add(Convert.ToInt32(i, 16) - subtractionKey);
                        }

                        byte[] bytes = new byte[modified.Count];

                        for (int i = 0; i < modified.Count; i++)
                        {
                            bytes[i] = Convert.ToByte(modified[i]);
                        }

                        decryptText = Encoding.ASCII.GetString(bytes);

                        modified.Clear();
                        joined.Clear();
                        bytes = new byte[0];

                        isCompleted = true;
                    }
                    isCompleted = false;
                }
            }
            catch (Exception ex)
            {
                //Error Messages
                if (preview)
                {
                    richTextBox2.Text = "An Error Occurred: " + ex;
                }
                else
                {
                    MessageBox.Show("An Error Occurred: " + ex, "Error");
                }
            }

            //Close Progress Bar
            form2.Close();

            return decryptText;
        }

    }
}
#endregion
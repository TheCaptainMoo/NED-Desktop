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
                        string[] strings = result.Split('|');
                        keyValue.Text = strings[0];
                        recursionValue.Text = strings[1];
                        richTextBox1.Text = strings[2];
                        richTextBox2.Text = strings[3];
                        break;

                }
            }
        }

        //Export Files
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
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
                        sw.Write(richTextBox2.Text);
                        sw.Close();
                        break;

                    //Ned Files
                    case 2:
                        StreamWriter sw1 = new StreamWriter(sfd.FileName);
                        sw1.Write(keyValue.Text + "|" + recursionValue.Text + "|" + richTextBox1.Text + "|" + richTextBox2.Text);
                        sw1.Close();
                        break;
                }
            }
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
            if (radioButton1.Checked)
            {
                e.Result = Encrypt(inputText.ToUpper(), key, recursion);
            }
            else
            {
                e.Result = Decrypt(inputText.ToUpper(), key, recursion);
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
            else if(e.Result != null)
            {
                richTextBox2.Text = e.Result.ToString();
            }
        }

        void PreviewCalc()
        {
            if (radioButton1.Checked)
            {
                richTextBox2.Text = Encrypt(inputText.ToUpper(), key, Math.Min(recursion, Usersettings.Default.PreviewRec));
            }
            else
            {
                richTextBox2.Text = Decrypt(inputText.ToUpper(), key, Math.Min(recursion, Usersettings.Default.PreviewRec));
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
            //Text Length Calculations
            if (radioButton1.Checked)
            {
                lettersToProcess = textCalc.Count(c => Char.IsLetter(c)) * (int)Math.Pow(2, recursionCalc);
            }
            else
            {
                lettersToProcess = textCalc.Count(c => Char.IsLetter(c));
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
            string splitOut = "";
            string punctuation = "";


            
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
                                punctuation += encryptText[j];
                            }

                            //Display Letter Processed
                            form2.IncremProg();
                            form2.Refresh();
                        }


                        for (int k = 0; k < numberOut.Count; k++)
                        {
                            //If Number is NOT punctuation
                            if (numberOut[k] != -1)
                            {
                                //Add Key
                                numberOut[k] += additionKey;
                                splitOut += numberOut[k].ToString();
                            }
                            else
                            {
                                //Add Punctuation ID
                                splitOut += "-";
                            }
                        }


                        //Clear Entered Text
                        encryptText = null;
                        int index = 0;

                        foreach (char c in splitOut)
                        {
                            //If character is NOT punctuation
                            if (c != '-')
                            {
                                //Write Text
                                encryptText += alphabet[int.Parse(c.ToString())];
                            }
                            else
                            {
                                //Write Punctuation
                                encryptText += punctuation[index];
                                index++;
                            }
                        }

                        //Clear Split for next recursion
                        splitOut = null;


                        //Clear Number Output for next recursion
                        numberOut.Clear();
                        isCompleted = true;
                    }
                    isCompleted = false;
                }
            }
            catch
            {
                //Error Messages
                if (preview)
                {
                    richTextBox2.Text = "Incorrect Recursion Length";
                }
                else
                    MessageBox.Show("Incorrect Recursion Length", "Recursion Length Error");
            }
            


            form2.Refresh();

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

            string numberOut = "";
            int[] joinOut = new int[0];
            int loopLength = 0;
            string punctuation = "";

            while (!bgWorker.CancellationPending && !isCompleted)
            {
                try
                {
                    for (int i = 0; i < recursion; i++)
                    {
                        while (!bgWorker.CancellationPending)
                        {
                            //Repeat Process Per Recursion
                            for (int j = 0; j < decryptText.Length; j++)
                            {
                                //Convert input to numbers based on location
                                numberOut += alphabet.IndexOf(decryptText[j]);

                                //Check if character is punctuation
                                if (alphabet.IndexOf(decryptText[j]) == -1)
                                {
                                    punctuation += decryptText[j];
                                }

                                //Display Letter Processes
                                form2.IncremProg();
                                form2.Refresh();
                            }

                            //Clean output
                            decryptText = "";
                            loopLength = numberOut.Length;
                            int index = 0;


                            try
                            {
                                for (int j = 0; j < loopLength / 2; j++)
                                {
                                    //If letter is NOT punctuation
                                    if (numberOut[0] != '-')
                                    {
                                        //Expand Array 
                                        Array.Resize(ref joinOut, joinOut.Length + 1);

                                        //Join 2 Numbers
                                        joinOut[j] = int.Parse(numberOut.Substring(0, 2));

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
                                        Array.Resize(ref joinOut, joinOut.Length + 1);

                                        //Remove Punctuation ID
                                        numberOut = numberOut.Remove(0, 2);

                                        //Add Punctuation to output
                                        decryptText += punctuation[index];

                                        //Move punctuation index
                                        index++;
                                    }
                                }
                            }
                            catch
                            {
                                //Error Message
                                MessageBox.Show("Incorrect Key/Recursion", "Length Error");
                            }

                            //Clean Outputs
                            joinOut = new int[0];
                            numberOut = "";
                            isCompleted = true;
                        }
                        isCompleted = false;
                    }
                }
                catch
                {
                    //Error Messages
                    if (preview)
                    {
                        richTextBox2.Text = "Incorrect Recursion Length";
                    }
                    else
                        MessageBox.Show("Incorrect Recursion Length", "Recursion Length Error");
                }
            }
            form2.Refresh();

            //Close Form
            form2.Close();

            //Return Decrypted Text
            return decryptText;
        }

    }
}
#endregion
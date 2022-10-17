namespace Windows_Forms_NED
{
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
            keyValue.Text = "";
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //Open Settings Form
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show(Owner);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

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





        #region NED
        //NED
        string inputText;
        int key;
        int recursion;
        bool safetyMeasure;

        string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";


        public static string textCalc;
        public static int recursionCalc;
        public static float totalTime;

        private void inputText_Update(object sender, EventArgs e)
        {
            inputText = richTextBox1.Text;
        }

        private void key_Update(object sender, EventArgs e)
        {
            if (keyValue.Text == "")
                return;
            key = Convert.ToInt32(keyValue.Text);
            safetyMeasure = (key < 75) ? true : false;
        }

        private void recursion_Update(object sender, EventArgs e)
        {
            if (recursionValue.Text == "")
                return;
            recursion = Convert.ToInt32(recursionValue.Text);
        }

        private void ProcessButton_Click(object sender, EventArgs e)
        {
            Decider();
        }

        void Decider()
        {
            //Key Verification
            if (key >= 75)
            {
                MessageBox.Show("Key must be below 75", "Key Length Error");
                return;
            } else if(key <= 0)
            {
                MessageBox.Show("Key must be above 0", "Key Length Error");
                return;
            }

            //Recursion Warning


            if (radioButton1.Checked == true)
            {
                Form2.encrypt = true;
                Encrypt(inputText.ToUpper(), key, recursion);
            }
            else
            {
                Form2.encrypt = false;
                Decrypt(inputText.ToUpper(), key, recursion);
            }

        }

        void Encrypt(string encryptText, int additionKey, int recursion)
        {
            //var watch = new System.Diagnostics.Stopwatch();
            var progress = new System.Diagnostics.Stopwatch();

            //watch.Start();

            //Console.WriteLine("Encrypting '" + encryptText + "' with a key of: " + additionKey + " and a recursion of: " + recursion);

            textCalc = encryptText;
            recursionCalc = recursion;

            Form2 form2 = new Form2();
            form2.Show();
            form2.Refresh();

            int letterIndex;
            int[] numberOut = { };
            string splitOut = "";
            string punctuation = "";



            for (int i = 0; i < recursion; i++)
            {
                for (int j = 0; j < encryptText.Length; j++)
                {
                    letterIndex = alphabet.IndexOf(encryptText[j]);
                    Console.WriteLine(letterIndex);
                    Array.Resize(ref numberOut, numberOut.Length + 1);
                    numberOut[j] = letterIndex;
                    // CONCATENATE INTEGERS NOT STRING TRY IT

                    if (letterIndex == -1)
                    {
                        punctuation += encryptText[j];
                    }
                }

                for (int k = 0; k < numberOut.Length; k++)
                {
                    if (numberOut[k] != -1)
                    {
                        numberOut[k] += additionKey;
                        Console.WriteLine("Number: " + numberOut[k]);
                        splitOut += numberOut[k].ToString();
                    }
                    else
                    {
                        Console.WriteLine("Punctuation Detected");
                        splitOut += "-";
                    }

                }

                encryptText = null;
                int index = 0;

                foreach (char c in splitOut)
                {
                    Console.WriteLine(c);
                    if (c != '-')
                    {
                        encryptText += alphabet[int.Parse(c.ToString())];
                    }
                    else
                    {
                        encryptText += punctuation[index];
                        index++;
                    }
                }

                //encryptText = encryptText.Remove(encryptText.Length - i, i);

                //Console.WriteLine("Recursion " + i + ": " + encryptText);

                //form2.UpdateText("Recursion " + i + ": " + encryptText);
                splitOut = null;

                //Console.WriteLine(numberOut);
                /*encryptText = "";
                Console.WriteLine(numberOut);
                foreach (int letter in numberOut)
                {
                    Console.WriteLine(letter);
                    if (letter != -1)
                    {
                        encryptText += alphabet[numberOut[letter]];
                    }
                    else
                    {
                        encryptText += " ";
                    }
                }*/
                numberOut = new int[0];
                //Console.WriteLine("array length: " + numberOut.Length);
            }

            //Console.WriteLine(encryptText);

            //Console.WriteLine("Noticed Punctuation: " + punctuation);
            //Start();
            form2.Refresh();

            richTextBox2.Text = encryptText;
            richTextBox2.Text = encryptText;

            form2.Close();

            //watch.Stop();
            progress.Reset();

            //var time = watch.ElapsedMilliseconds;
        }

        void Decrypt(string decryptText, int subtractionKey, int recursion)
        {
            textCalc = decryptText;
            recursionCalc = recursion;

            Form2 form2 = new Form2();
            form2.Show();
            form2.Refresh();

            //Console.WriteLine("Decrypting '" + decryptText + "' with a key of: " + subtractionKey + " and a recursion of: " + recursion);

            string numberOut = "";
            int[] joinOut = new int[0];
            int loopLength = 0;
            string punctuation = "";

            for (int i = 0; i < recursion; i++)
            {
                for (int j = 0; j < decryptText.Length; j++)
                {
                    numberOut += alphabet.IndexOf(decryptText[j]);
                    //Console.WriteLine(numberOut[j]);
                    if (alphabet.IndexOf(decryptText[j]) == -1)
                    {
                        punctuation += decryptText[j];
                    }

                    form2.IncremProg();
                    form2.Refresh();
                }

                //numberOut = numberOut.Replace("-1", "-");
                //Console.WriteLine("Replaced Output:" + numberOut);

                decryptText = "";
                loopLength = numberOut.Length;
                int index = 0;

                for (int j = 0; j < loopLength / 2; j++)
                {
                    //Console.WriteLine("Number: " + numberOut + " " + numberOut[0]);
                    if (numberOut[0] != '-'/* && numberOut[1] != '1' || int.Parse(numberOut.Substring(0, 2)) < 0*/)
                    {
                        Array.Resize(ref joinOut, joinOut.Length + 1);

                        //Console.WriteLine("Array Length: " + joinOut.Length);

                        joinOut[j] = int.Parse(numberOut.Substring(0, 2));
                        //Console.WriteLine("Parsed Results: " + joinOut[j]);
                        joinOut[j] -= subtractionKey;
                        numberOut = numberOut.Remove(0, 2);
                        //Console.WriteLine("Join Out: " + joinOut[j]);

                        decryptText += alphabet[joinOut[j]];
                    }
                    else
                    {
                        Array.Resize(ref joinOut, joinOut.Length + 1);
                        numberOut = numberOut.Remove(0, 2);
                        decryptText += punctuation[index];
                        index++;
                        //Console.WriteLine("Punctuation: " + decryptText);
                    }
                }

                //Repair Output
                int repairLength = punctuation.Length - index;
                /*
                for(int j = 0; j < repairLength; j++)
                {
                    decryptText += punctuation[index];
                    index++;
                }*/


                //Console.WriteLine("Recursion " + i + ": " + decryptText);

                joinOut = new int[0];
                numberOut = "";
            }
            form2.Refresh();

            richTextBox2.Text = decryptText;

            form2.Close();
        }


    }
}
#endregion
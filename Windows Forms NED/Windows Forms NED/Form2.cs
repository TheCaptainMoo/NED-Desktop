namespace Windows_Forms_NED
{
    public partial class Form2 : Form
    {
        public double ttCompletion;
        int lettersToProcess;
        public static bool encrypt = true;

        public Form2()
        {
            InitializeComponent();

            if (encrypt)
            {
                lettersToProcess = Form1.textCalc.Count(c => Char.IsLetter(c)) * (int)Math.Pow(2, Form1.recursionCalc);
            }
            else
            {
                DecryptLTP();
            }

            progressBar1.Maximum = lettersToProcess;
        }

        public void DecryptLTP()
        {
            lettersToProcess = Form1.textCalc.Count(c => Char.IsLetter(c));
            int tempLTP = lettersToProcess;
            while (Form1.recursionCalc != 1)
            {
                lettersToProcess += tempLTP / 2;
                tempLTP /= 2;
                Form1.recursionCalc--;
            }
        }

        public void IncremProg()
        {
            progressBar1.PerformStep();
            label2.Text = progressBar1.Value.ToString() + "/" + progressBar1.Maximum.ToString();

            if (progressBar1.Value == progressBar1.Maximum)
            {
                label1.Text = "Copying Output...";
            }
        }

        /*public void TimeLeft()
        {
            Thread.Sleep(1000);

            ttCompletion = ((lettersToProcess * Form1.totalTime) * 0.0000001);

            Console.WriteLine("-");
        }*/



    }
}

//Total Time - 1 TICK is 1 * 10^-7 secondsle

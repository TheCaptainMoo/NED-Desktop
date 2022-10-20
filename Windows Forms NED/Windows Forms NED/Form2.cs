namespace Windows_Forms_NED
{
    public partial class Form2 : Form
    {
        public double ttCompletion;
        

        //Setup Progress Bar
        public Form2()
        {
            InitializeComponent();

            progressBar1.Maximum = Form1.lettersToProcess;
        }
        

        //Increment Progress Bar
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

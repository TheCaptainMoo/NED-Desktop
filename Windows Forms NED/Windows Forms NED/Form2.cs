using System.Diagnostics;
using System.Windows.Forms;

namespace Windows_Forms_NED
{
    public partial class Form2 : Form
    {
        public int ttCompletion;

        int tempTime;
        int difference;

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

            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();

            label3.Text = ttCompletion.ToString() + " Seconds Remaining";
        }        
        


        public int TimeLeft()
        {
            tempTime = progressBar1.Value;

            Thread.Sleep(1000);
            
            //Make it work
            difference = progressBar1.Value - tempTime;
            int temp = difference;

            ttCompletion = 0;
            while (difference < progressBar1.Maximum - progressBar1.Value)
            {
                difference += temp;
                ttCompletion++;
            }

            
            TimeLeft();
            return ttCompletion;
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = TimeLeft();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            //backgroundWorker1.RunWorkerAsync();


            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message, "Error Detected");
            }
            else if (e.Result != null)
            {
                label3.Text = ttCompletion.ToString() + " Seconds Remaining";
            }
        }
    }
}

//Total Time - 1 TICK is 1 * 10^-7 secondsle

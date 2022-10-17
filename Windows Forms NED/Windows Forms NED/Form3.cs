namespace Windows_Forms_NED
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void NumberOnly_KeyPress(object sender, KeyPressEventArgs e)
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

        private void SaveSettings(object sender, EventArgs e)
        {

            if (int.Parse(keyValue.Text) <= 0)
            {

            }
        }
    }
}

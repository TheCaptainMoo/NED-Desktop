namespace Windows_Forms_NED
{
    public partial class Form3 : Form
    {
        //Load Existing Settings (Read Settings)
        public Form3()
        {
            InitializeComponent();

            keyValue.Text = Usersettings.Default.DefaultKey.ToString();
            recValue.Text = Usersettings.Default.DefaultRec.ToString();

            cpwBox.Text = Usersettings.Default.OutputWarning.ToString();

            prlBox.Text = Usersettings.Default.PreviewRec.ToString();
        }

        //Loop through all existing elements
        public static IEnumerable<Control> GetAllControls(Control control)
        {
            Stack<Control> stack = new Stack<Control>();
            stack.Push(control);

            while (stack.Any())
            {
                var next = stack.Pop();
                yield return next;
                foreach (Control child in next.Controls)
                {
                    stack.Push(child);
                }
            }
        }

        //Ensure the only value entered is a number
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

        //Write Settings
        private void SaveSettings(object sender, EventArgs e)
        {
            Usersettings.Default.DefaultKey = int.Parse(keyValue.Text);
            Usersettings.Default.DefaultRec = int.Parse(recValue.Text);

            Usersettings.Default.OutputWarning = int.Parse(cpwBox.Text);

            Usersettings.Default.PreviewRec = int.Parse(prlBox.Text);

            Usersettings.Default.Save();

            if(MessageBox.Show("The program must close and reopen to apply changes. Restart now?", "Restart?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Restart();
                Environment.Exit(0);
            }
        }

        //Select Table
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            foreach (var tbl in GetAllControls(this).OfType<TableLayoutPanel>())
            {
                tbl.Visible = false;
                if (treeView1.SelectedNode.ToString().Contains(tbl.Name))
                {
                    tbl.Visible = true;
                }
            }
        }
    }
}

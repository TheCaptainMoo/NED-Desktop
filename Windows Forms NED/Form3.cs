using System.Configuration;

namespace Windows_Forms_NED
{
    public partial class Form3 : Form
    {
        //Load Existing Settings (Read Settings)
        public Form3()
        {
            InitializeComponent();

            foreach(SettingsProperty currentSetting in Usersettings.Default.Properties)
            {
                foreach(var rtb in GetAllControls(this).OfType<RichTextBox>())
                {
                    if(rtb.Name == currentSetting.Name)
                    {
                        rtb.Text = Usersettings.Default[currentSetting.Name].ToString();
                    }
                }
                    
            }
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
            foreach(SettingsProperty currentSetting in Usersettings.Default.Properties)
            {
                foreach(RichTextBox rtb in GetAllControls(this).OfType<RichTextBox>())
                {
                    if (rtb.Name == currentSetting.Name)
                    {
                        if (currentSetting.PropertyType == typeof(int))
                        {
                            Usersettings.Default[currentSetting.Name] = int.Parse(rtb.Text);
                        }
                    }
                }
            }

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

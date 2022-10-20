namespace Windows_Forms_NED
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Defaults");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Warnings");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Preview");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Generic", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7,
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Experimental");
            this.panel1 = new System.Windows.Forms.Panel();
            this.Save = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.Defaults = new System.Windows.Forms.TableLayoutPanel();
            this.recValue = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Key = new System.Windows.Forms.Label();
            this.keyValue = new System.Windows.Forms.RichTextBox();
            this.Warnings = new System.Windows.Forms.TableLayoutPanel();
            this.cpw = new System.Windows.Forms.Label();
            this.cpwBox = new System.Windows.Forms.RichTextBox();
            this.Preview = new System.Windows.Forms.TableLayoutPanel();
            this.prl = new System.Windows.Forms.Label();
            this.prlBox = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.Defaults.SuspendLayout();
            this.Warnings.SuspendLayout();
            this.Preview.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.Save);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(804, 44);
            this.panel1.TabIndex = 0;
            // 
            // Save
            // 
            this.Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Save.AutoSize = true;
            this.Save.BackColor = System.Drawing.Color.White;
            this.Save.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Save.FlatAppearance.BorderSize = 0;
            this.Save.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.Save.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.Save.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.Save.Location = new System.Drawing.Point(724, 5);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 36);
            this.Save.TabIndex = 2;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = false;
            this.Save.Click += new System.EventHandler(this.SaveSettings);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(12, 62);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.Preview);
            this.splitContainer1.Panel2.Controls.Add(this.Warnings);
            this.splitContainer1.Panel2.Controls.Add(this.Defaults);
            this.splitContainer1.Size = new System.Drawing.Size(804, 382);
            this.splitContainer1.SplitterDistance = 268;
            this.splitContainer1.TabIndex = 1;
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.ForeColor = System.Drawing.SystemColors.Window;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            treeNode6.ForeColor = System.Drawing.SystemColors.Window;
            treeNode6.Name = "Defaults";
            treeNode6.Text = "Defaults";
            treeNode6.ToolTipText = "Defaults saved by the System";
            treeNode7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            treeNode7.Name = "Warnings";
            treeNode7.Text = "Warnings";
            treeNode8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            treeNode8.Name = "Preview";
            treeNode8.Text = "Preview";
            treeNode9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            treeNode9.ForeColor = System.Drawing.SystemColors.Window;
            treeNode9.Name = "Generic";
            treeNode9.Text = "Generic";
            treeNode10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            treeNode10.Name = "Experimental";
            treeNode10.Text = "Experimental";
            treeNode10.ToolTipText = "Experiemental Settings :O";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode10});
            this.treeView1.Size = new System.Drawing.Size(268, 382);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // Defaults
            // 
            this.Defaults.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.Defaults.ColumnCount = 2;
            this.Defaults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Defaults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Defaults.Controls.Add(this.recValue, 1, 1);
            this.Defaults.Controls.Add(this.label1, 0, 1);
            this.Defaults.Controls.Add(this.Key, 0, 0);
            this.Defaults.Controls.Add(this.keyValue, 1, 0);
            this.Defaults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Defaults.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.Defaults.Location = new System.Drawing.Point(0, 0);
            this.Defaults.Name = "Defaults";
            this.Defaults.RowCount = 3;
            this.Defaults.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.Defaults.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.Defaults.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.Defaults.Size = new System.Drawing.Size(532, 382);
            this.Defaults.TabIndex = 0;
            // 
            // recValue
            // 
            this.recValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.recValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.recValue.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.recValue.ForeColor = System.Drawing.SystemColors.Window;
            this.recValue.Location = new System.Drawing.Point(270, 32);
            this.recValue.MaxLength = 2;
            this.recValue.Multiline = false;
            this.recValue.Name = "recValue";
            this.recValue.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.recValue.Size = new System.Drawing.Size(257, 19);
            this.recValue.TabIndex = 3;
            this.recValue.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.label1.Location = new System.Drawing.Point(5, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Default Recursion:";
            // 
            // Key
            // 
            this.Key.AutoSize = true;
            this.Key.ForeColor = System.Drawing.SystemColors.Window;
            this.Key.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.Key.Location = new System.Drawing.Point(5, 2);
            this.Key.Name = "Key";
            this.Key.Size = new System.Drawing.Size(70, 15);
            this.Key.TabIndex = 0;
            this.Key.Text = "Default Key:";
            // 
            // keyValue
            // 
            this.keyValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.keyValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.keyValue.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.keyValue.ForeColor = System.Drawing.SystemColors.Window;
            this.keyValue.Location = new System.Drawing.Point(270, 5);
            this.keyValue.MaxLength = 2;
            this.keyValue.Multiline = false;
            this.keyValue.Name = "keyValue";
            this.keyValue.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.keyValue.Size = new System.Drawing.Size(257, 19);
            this.keyValue.TabIndex = 2;
            this.keyValue.Text = "1";
            this.keyValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberOnly_KeyPress);
            // 
            // Warnings
            // 
            this.Warnings.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.Warnings.ColumnCount = 2;
            this.Warnings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Warnings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Warnings.Controls.Add(this.cpw, 0, 0);
            this.Warnings.Controls.Add(this.cpwBox, 1, 0);
            this.Warnings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Warnings.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.Warnings.Location = new System.Drawing.Point(0, 0);
            this.Warnings.Name = "Warnings";
            this.Warnings.RowCount = 3;
            this.Warnings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.Warnings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.Warnings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.Warnings.Size = new System.Drawing.Size(532, 382);
            this.Warnings.TabIndex = 3;
            // 
            // cpw
            // 
            this.cpw.AutoSize = true;
            this.cpw.ForeColor = System.Drawing.SystemColors.Window;
            this.cpw.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.cpw.Location = new System.Drawing.Point(5, 2);
            this.cpw.Name = "cpw";
            this.cpw.Size = new System.Drawing.Size(149, 15);
            this.cpw.TabIndex = 0;
            this.cpw.Text = "Character Process Warning";
            // 
            // cpwBox
            // 
            this.cpwBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.cpwBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cpwBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cpwBox.ForeColor = System.Drawing.SystemColors.Window;
            this.cpwBox.Location = new System.Drawing.Point(270, 5);
            this.cpwBox.MaxLength = 12;
            this.cpwBox.Multiline = false;
            this.cpwBox.Name = "cpwBox";
            this.cpwBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.cpwBox.Size = new System.Drawing.Size(257, 19);
            this.cpwBox.TabIndex = 2;
            this.cpwBox.Text = "1";
            // 
            // Preview
            // 
            this.Preview.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.Preview.ColumnCount = 2;
            this.Preview.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Preview.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Preview.Controls.Add(this.prl, 0, 0);
            this.Preview.Controls.Add(this.prlBox, 1, 0);
            this.Preview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Preview.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.Preview.Location = new System.Drawing.Point(0, 0);
            this.Preview.Name = "Preview";
            this.Preview.RowCount = 3;
            this.Preview.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.Preview.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.Preview.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.Preview.Size = new System.Drawing.Size(532, 382);
            this.Preview.TabIndex = 4;
            // 
            // prl
            // 
            this.prl.AutoSize = true;
            this.prl.ForeColor = System.Drawing.SystemColors.Window;
            this.prl.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.prl.Location = new System.Drawing.Point(5, 2);
            this.prl.Name = "prl";
            this.prl.Size = new System.Drawing.Size(133, 15);
            this.prl.TabIndex = 0;
            this.prl.Text = "Preview Recursion Limit";
            // 
            // prlBox
            // 
            this.prlBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.prlBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.prlBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.prlBox.ForeColor = System.Drawing.SystemColors.Window;
            this.prlBox.Location = new System.Drawing.Point(270, 5);
            this.prlBox.MaxLength = 2;
            this.prlBox.Multiline = false;
            this.prlBox.Name = "prlBox";
            this.prlBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.prlBox.Size = new System.Drawing.Size(257, 19);
            this.prlBox.TabIndex = 2;
            this.prlBox.Text = "1";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(828, 456);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "Form3";
            this.Text = "Settings";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.Defaults.ResumeLayout(false);
            this.Defaults.PerformLayout();
            this.Warnings.ResumeLayout(false);
            this.Warnings.PerformLayout();
            this.Preview.ResumeLayout(false);
            this.Preview.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panel1;
        private SplitContainer splitContainer1;
        private TreeView treeView1;
        private TableLayoutPanel Defaults;
        private Label Key;
        private Label label1;
        private RichTextBox keyValue;
        private Button Save;
        private RichTextBox recValue;
        private TableLayoutPanel Warnings;
        private Label cpw;
        private RichTextBox cpwBox;
        private TableLayoutPanel Preview;
        private Label prl;
        private RichTextBox prlBox;
    }
}
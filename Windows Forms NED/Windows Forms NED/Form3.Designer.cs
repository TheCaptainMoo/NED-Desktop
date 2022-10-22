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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Defaults");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Warnings");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Preview");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Generic", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Experimental");
            this.panel1 = new System.Windows.Forms.Panel();
            this.Save = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.Preview = new System.Windows.Forms.TableLayoutPanel();
            this.prl = new System.Windows.Forms.Label();
            this.PreviewRec = new System.Windows.Forms.RichTextBox();
            this.Warnings = new System.Windows.Forms.TableLayoutPanel();
            this.cpw = new System.Windows.Forms.Label();
            this.OutputWarning = new System.Windows.Forms.RichTextBox();
            this.Defaults = new System.Windows.Forms.TableLayoutPanel();
            this.DefaultRec = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Key = new System.Windows.Forms.Label();
            this.DefaultKey = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.Preview.SuspendLayout();
            this.Warnings.SuspendLayout();
            this.Defaults.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(718, 44);
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
            this.Save.Location = new System.Drawing.Point(741, 12);
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
            treeNode1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            treeNode1.ForeColor = System.Drawing.SystemColors.Window;
            treeNode1.Name = "Defaults";
            treeNode1.Text = "Defaults";
            treeNode1.ToolTipText = "Defaults saved by the System";
            treeNode2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            treeNode2.Name = "Warnings";
            treeNode2.Text = "Warnings";
            treeNode3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            treeNode3.Name = "Preview";
            treeNode3.Text = "Preview";
            treeNode4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            treeNode4.ForeColor = System.Drawing.SystemColors.Window;
            treeNode4.Name = "Generic";
            treeNode4.Text = "Generic";
            treeNode5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            treeNode5.Name = "Experimental";
            treeNode5.Text = "Experimental";
            treeNode5.ToolTipText = "Experiemental Settings :O";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            this.treeView1.Size = new System.Drawing.Size(268, 382);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // Preview
            // 
            this.Preview.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.Preview.ColumnCount = 2;
            this.Preview.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Preview.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Preview.Controls.Add(this.prl, 0, 0);
            this.Preview.Controls.Add(this.PreviewRec, 1, 0);
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
            // PreviewRec
            // 
            this.PreviewRec.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.PreviewRec.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PreviewRec.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PreviewRec.ForeColor = System.Drawing.SystemColors.Window;
            this.PreviewRec.Location = new System.Drawing.Point(270, 5);
            this.PreviewRec.MaxLength = 2;
            this.PreviewRec.Multiline = false;
            this.PreviewRec.Name = "PreviewRec";
            this.PreviewRec.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.PreviewRec.Size = new System.Drawing.Size(257, 19);
            this.PreviewRec.TabIndex = 2;
            this.PreviewRec.Text = "1";
            // 
            // Warnings
            // 
            this.Warnings.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.Warnings.ColumnCount = 2;
            this.Warnings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Warnings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Warnings.Controls.Add(this.cpw, 0, 0);
            this.Warnings.Controls.Add(this.OutputWarning, 1, 0);
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
            // OutputWarning
            // 
            this.OutputWarning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.OutputWarning.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OutputWarning.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.OutputWarning.ForeColor = System.Drawing.SystemColors.Window;
            this.OutputWarning.Location = new System.Drawing.Point(270, 5);
            this.OutputWarning.MaxLength = 12;
            this.OutputWarning.Multiline = false;
            this.OutputWarning.Name = "OutputWarning";
            this.OutputWarning.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.OutputWarning.Size = new System.Drawing.Size(257, 19);
            this.OutputWarning.TabIndex = 2;
            this.OutputWarning.Text = "1";
            // 
            // Defaults
            // 
            this.Defaults.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.Defaults.ColumnCount = 2;
            this.Defaults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Defaults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Defaults.Controls.Add(this.DefaultRec, 1, 1);
            this.Defaults.Controls.Add(this.label1, 0, 1);
            this.Defaults.Controls.Add(this.Key, 0, 0);
            this.Defaults.Controls.Add(this.DefaultKey, 1, 0);
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
            // DefaultRec
            // 
            this.DefaultRec.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.DefaultRec.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DefaultRec.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DefaultRec.ForeColor = System.Drawing.SystemColors.Window;
            this.DefaultRec.Location = new System.Drawing.Point(270, 32);
            this.DefaultRec.MaxLength = 2;
            this.DefaultRec.Multiline = false;
            this.DefaultRec.Name = "DefaultRec";
            this.DefaultRec.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.DefaultRec.Size = new System.Drawing.Size(257, 19);
            this.DefaultRec.TabIndex = 3;
            this.DefaultRec.Text = "1";
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
            // DefaultKey
            // 
            this.DefaultKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.DefaultKey.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DefaultKey.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DefaultKey.ForeColor = System.Drawing.SystemColors.Window;
            this.DefaultKey.Location = new System.Drawing.Point(270, 5);
            this.DefaultKey.MaxLength = 2;
            this.DefaultKey.Multiline = false;
            this.DefaultKey.Name = "DefaultKey";
            this.DefaultKey.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.DefaultKey.Size = new System.Drawing.Size(257, 19);
            this.DefaultKey.TabIndex = 2;
            this.DefaultKey.Text = "1";
            this.DefaultKey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberOnly_KeyPress);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(828, 456);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(844, 495);
            this.Name = "Form3";
            this.Text = "Settings";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.Preview.ResumeLayout(false);
            this.Preview.PerformLayout();
            this.Warnings.ResumeLayout(false);
            this.Warnings.PerformLayout();
            this.Defaults.ResumeLayout(false);
            this.Defaults.PerformLayout();
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
        private RichTextBox DefaultKey;
        private Button Save;
        private RichTextBox DefaultRec;
        private TableLayoutPanel Warnings;
        private Label cpw;
        private RichTextBox OutputWarning;
        private TableLayoutPanel Preview;
        private Label prl;
        private RichTextBox PreviewRec;
    }
}

namespace CheatEngineDataStructParser
{
    partial class NightFyreFrameworks
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
            this.DataTable_RichTextBox = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ClassNameEntry_MenuStrip = new System.Windows.Forms.ToolStripTextBox();
            this.ParseInput_MenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearDataTable_MEnuStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataTable_RichTextBox
            // 
            this.DataTable_RichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataTable_RichTextBox.Location = new System.Drawing.Point(0, 27);
            this.DataTable_RichTextBox.Name = "DataTable_RichTextBox";
            this.DataTable_RichTextBox.Size = new System.Drawing.Size(398, 332);
            this.DataTable_RichTextBox.TabIndex = 0;
            this.DataTable_RichTextBox.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClassNameEntry_MenuStrip,
            this.ParseInput_MenuStripItem,
            this.ClearDataTable_MEnuStripItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(398, 27);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "MenuStrip";
            // 
            // ClassNameEntry_MenuStrip
            // 
            this.ClassNameEntry_MenuStrip.BackColor = System.Drawing.SystemColors.Window;
            this.ClassNameEntry_MenuStrip.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ClassNameEntry_MenuStrip.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClassNameEntry_MenuStrip.Name = "ClassNameEntry_MenuStrip";
            this.ClassNameEntry_MenuStrip.Size = new System.Drawing.Size(100, 23);
            this.ClassNameEntry_MenuStrip.Text = "<ClassName>";
            this.ClassNameEntry_MenuStrip.Enter += new System.EventHandler(this.ClassNameEntry_MenuStrip_Enter);
            this.ClassNameEntry_MenuStrip.Leave += new System.EventHandler(this.ClassNameEntry_MenuStrip_Leave);
            // 
            // ParseInput_MenuStripItem
            // 
            this.ParseInput_MenuStripItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ParseInput_MenuStripItem.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ParseInput_MenuStripItem.Name = "ParseInput_MenuStripItem";
            this.ParseInput_MenuStripItem.Size = new System.Drawing.Size(156, 23);
            this.ParseInput_MenuStripItem.Text = "Parse XML to C++ Class";
            this.ParseInput_MenuStripItem.Click += new System.EventHandler(this.ParseInput_MenuStripItem_Click);
            // 
            // ClearDataTable_MEnuStripItem
            // 
            this.ClearDataTable_MEnuStripItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClearDataTable_MEnuStripItem.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ClearDataTable_MEnuStripItem.Name = "ClearDataTable_MEnuStripItem";
            this.ClearDataTable_MEnuStripItem.Size = new System.Drawing.Size(134, 23);
            this.ClearDataTable_MEnuStripItem.Text = "CLEAR DATA TABLE";
            this.ClearDataTable_MEnuStripItem.Click += new System.EventHandler(this.ClearDataTable_MEnuStripItem_Click);
            // 
            // NightFyreFrameworks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 359);
            this.Controls.Add(this.DataTable_RichTextBox);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "NightFyreFrameworks";
            this.ShowIcon = false;
            this.Text = "CheatEngine DataStruct Parser";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox DataTable_RichTextBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ParseInput_MenuStripItem;
        private System.Windows.Forms.ToolStripMenuItem ClearDataTable_MEnuStripItem;
        private System.Windows.Forms.ToolStripTextBox ClassNameEntry_MenuStrip;
    }
}


namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.bkpbtn = new System.Windows.Forms.Button();
            this.outputlabel = new System.Windows.Forms.Label();
            this.choosefolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.choosedirbtn = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // bkpbtn
            // 
            this.bkpbtn.Location = new System.Drawing.Point(254, 115);
            this.bkpbtn.Name = "bkpbtn";
            this.bkpbtn.Size = new System.Drawing.Size(75, 69);
            this.bkpbtn.TabIndex = 1;
            this.bkpbtn.TabStop = false;
            this.bkpbtn.Text = "Backup";
            this.bkpbtn.UseVisualStyleBackColor = true;
            this.bkpbtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // outputlabel
            // 
            this.outputlabel.BackColor = System.Drawing.Color.White;
            this.outputlabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.outputlabel.Location = new System.Drawing.Point(12, 9);
            this.outputlabel.Name = "outputlabel";
            this.outputlabel.Size = new System.Drawing.Size(236, 198);
            this.outputlabel.TabIndex = 2;
            // 
            // choosefolderDialog
            // 
            this.choosefolderDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.choosefolderDialog.ShowNewFolderButton = false;
            // 
            // choosedirbtn
            // 
            this.choosedirbtn.Location = new System.Drawing.Point(254, 40);
            this.choosedirbtn.Name = "choosedirbtn";
            this.choosedirbtn.Size = new System.Drawing.Size(75, 69);
            this.choosedirbtn.TabIndex = 3;
            this.choosedirbtn.Text = "Choose folder";
            this.toolTip.SetToolTip(this.choosedirbtn, "choose folder to backup");
            this.choosedirbtn.UseVisualStyleBackColor = true;
            this.choosedirbtn.Click += new System.EventHandler(this.choosedirbtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(341, 216);
            this.Controls.Add(this.choosedirbtn);
            this.Controls.Add(this.outputlabel);
            this.Controls.Add(this.bkpbtn);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "dropbox backup";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bkpbtn;
        private System.Windows.Forms.Label outputlabel;
        private System.Windows.Forms.FolderBrowserDialog choosefolderDialog;
        private System.Windows.Forms.Button choosedirbtn;
        private System.Windows.Forms.ToolTip toolTip;
    }
}


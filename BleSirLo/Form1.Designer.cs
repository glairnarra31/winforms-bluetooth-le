namespace BleSirLo
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
            this.ScanBtn = new System.Windows.Forms.Button();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.WriteBtn = new System.Windows.Forms.Button();
            this.ReadBtn = new System.Windows.Forms.Button();
            this.DevicesComboBox = new System.Windows.Forms.ComboBox();
            this.Response = new System.Windows.Forms.RichTextBox();
            this.InputTxtBox = new System.Windows.Forms.TextBox();
            this.ServiceTxtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CharacteristicsTxtBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ScanBtn
            // 
            this.ScanBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.ScanBtn.Location = new System.Drawing.Point(0, 0);
            this.ScanBtn.Name = "ScanBtn";
            this.ScanBtn.Size = new System.Drawing.Size(321, 23);
            this.ScanBtn.TabIndex = 0;
            this.ScanBtn.Text = "Scan";
            this.ScanBtn.UseVisualStyleBackColor = true;
            this.ScanBtn.Click += new System.EventHandler(this.ScanBtn_Click);
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Location = new System.Drawing.Point(254, 79);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(63, 23);
            this.ConnectBtn.TabIndex = 1;
            this.ConnectBtn.Text = "Connect";
            this.ConnectBtn.UseVisualStyleBackColor = true;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // WriteBtn
            // 
            this.WriteBtn.Location = new System.Drawing.Point(205, 327);
            this.WriteBtn.Name = "WriteBtn";
            this.WriteBtn.Size = new System.Drawing.Size(47, 23);
            this.WriteBtn.TabIndex = 2;
            this.WriteBtn.Text = "Write";
            this.WriteBtn.UseVisualStyleBackColor = true;
            this.WriteBtn.Click += new System.EventHandler(this.WriteBtn_Click);
            // 
            // ReadBtn
            // 
            this.ReadBtn.Location = new System.Drawing.Point(259, 327);
            this.ReadBtn.Name = "ReadBtn";
            this.ReadBtn.Size = new System.Drawing.Size(50, 23);
            this.ReadBtn.TabIndex = 3;
            this.ReadBtn.Text = "Read";
            this.ReadBtn.UseVisualStyleBackColor = true;
            this.ReadBtn.Click += new System.EventHandler(this.ReadBtn_Click);
            // 
            // DevicesComboBox
            // 
            this.DevicesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DevicesComboBox.FormattingEnabled = true;
            this.DevicesComboBox.Location = new System.Drawing.Point(114, 29);
            this.DevicesComboBox.Name = "DevicesComboBox";
            this.DevicesComboBox.Size = new System.Drawing.Size(135, 21);
            this.DevicesComboBox.TabIndex = 4;
            this.DevicesComboBox.SelectedIndexChanged += new System.EventHandler(this.DevicesComboBox_SelectedIndexChanged);
            // 
            // Response
            // 
            this.Response.Location = new System.Drawing.Point(13, 112);
            this.Response.Name = "Response";
            this.Response.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.Response.Size = new System.Drawing.Size(296, 204);
            this.Response.TabIndex = 5;
            this.Response.Text = "";
            // 
            // InputTxtBox
            // 
            this.InputTxtBox.Location = new System.Drawing.Point(12, 329);
            this.InputTxtBox.Name = "InputTxtBox";
            this.InputTxtBox.Size = new System.Drawing.Size(187, 20);
            this.InputTxtBox.TabIndex = 6;
            // 
            // ServiceTxtBox
            // 
            this.ServiceTxtBox.Location = new System.Drawing.Point(113, 55);
            this.ServiceTxtBox.Name = "ServiceTxtBox";
            this.ServiceTxtBox.Size = new System.Drawing.Size(135, 20);
            this.ServiceTxtBox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Devices";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Service Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Characteristics Name";
            // 
            // CharacteristicsTxtBox
            // 
            this.CharacteristicsTxtBox.Location = new System.Drawing.Point(113, 80);
            this.CharacteristicsTxtBox.Name = "CharacteristicsTxtBox";
            this.CharacteristicsTxtBox.Size = new System.Drawing.Size(135, 20);
            this.CharacteristicsTxtBox.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 359);
            this.Controls.Add(this.CharacteristicsTxtBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ServiceTxtBox);
            this.Controls.Add(this.InputTxtBox);
            this.Controls.Add(this.Response);
            this.Controls.Add(this.DevicesComboBox);
            this.Controls.Add(this.ReadBtn);
            this.Controls.Add(this.WriteBtn);
            this.Controls.Add(this.ConnectBtn);
            this.Controls.Add(this.ScanBtn);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ScanBtn;
        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.Button WriteBtn;
        private System.Windows.Forms.Button ReadBtn;
        private System.Windows.Forms.ComboBox DevicesComboBox;
        private System.Windows.Forms.RichTextBox Response;
        private System.Windows.Forms.TextBox InputTxtBox;
        private System.Windows.Forms.TextBox ServiceTxtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox CharacteristicsTxtBox;
    }
}


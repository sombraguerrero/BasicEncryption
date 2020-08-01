namespace BasicEncryption
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
            this.encBtn = new System.Windows.Forms.RadioButton();
            this.decryptBtn = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.ivPathBox = new System.Windows.Forms.TextBox();
            this.ivBrowse = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.keyPathBox = new System.Windows.Forms.TextBox();
            this.keyBrowse = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.srcFileBox = new System.Windows.Forms.TextBox();
            this.srcBrowse = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.destFilePath = new System.Windows.Forms.TextBox();
            this.destBrowse = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.encryptBtn2 = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // encBtn
            // 
            this.encBtn.AutoSize = true;
            this.encBtn.Location = new System.Drawing.Point(12, 12);
            this.encBtn.Name = "encBtn";
            this.encBtn.Size = new System.Drawing.Size(61, 17);
            this.encBtn.TabIndex = 0;
            this.encBtn.TabStop = true;
            this.encBtn.Text = "Encrypt";
            this.encBtn.UseVisualStyleBackColor = true;
            this.encBtn.CheckedChanged += new System.EventHandler(this.encBtn_CheckedChanged);
            // 
            // decryptBtn
            // 
            this.decryptBtn.AutoSize = true;
            this.decryptBtn.Location = new System.Drawing.Point(185, 12);
            this.decryptBtn.Name = "decryptBtn";
            this.decryptBtn.Size = new System.Drawing.Size(62, 17);
            this.decryptBtn.TabIndex = 1;
            this.decryptBtn.TabStop = true;
            this.decryptBtn.Text = "Decrypt";
            this.decryptBtn.UseVisualStyleBackColor = true;
            this.decryptBtn.CheckedChanged += new System.EventHandler(this.decryptBtn_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Initialization Vector";
            // 
            // ivPathBox
            // 
            this.ivPathBox.Location = new System.Drawing.Point(12, 58);
            this.ivPathBox.Name = "ivPathBox";
            this.ivPathBox.Size = new System.Drawing.Size(183, 20);
            this.ivPathBox.TabIndex = 3;
            // 
            // ivBrowse
            // 
            this.ivBrowse.Location = new System.Drawing.Point(201, 56);
            this.ivBrowse.Name = "ivBrowse";
            this.ivBrowse.Size = new System.Drawing.Size(75, 23);
            this.ivBrowse.TabIndex = 4;
            this.ivBrowse.Text = "Browse";
            this.ivBrowse.UseVisualStyleBackColor = true;
            this.ivBrowse.Click += new System.EventHandler(this.ivBrowse_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Key File";
            // 
            // keyPathBox
            // 
            this.keyPathBox.Location = new System.Drawing.Point(12, 97);
            this.keyPathBox.Name = "keyPathBox";
            this.keyPathBox.Size = new System.Drawing.Size(183, 20);
            this.keyPathBox.TabIndex = 6;
            // 
            // keyBrowse
            // 
            this.keyBrowse.Location = new System.Drawing.Point(201, 95);
            this.keyBrowse.Name = "keyBrowse";
            this.keyBrowse.Size = new System.Drawing.Size(75, 23);
            this.keyBrowse.TabIndex = 7;
            this.keyBrowse.Text = "Browse";
            this.keyBrowse.UseVisualStyleBackColor = true;
            this.keyBrowse.Click += new System.EventHandler(this.keyBrowse_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Source File";
            // 
            // srcFileBox
            // 
            this.srcFileBox.Location = new System.Drawing.Point(12, 136);
            this.srcFileBox.Name = "srcFileBox";
            this.srcFileBox.Size = new System.Drawing.Size(183, 20);
            this.srcFileBox.TabIndex = 9;
            // 
            // srcBrowse
            // 
            this.srcBrowse.Location = new System.Drawing.Point(201, 134);
            this.srcBrowse.Name = "srcBrowse";
            this.srcBrowse.Size = new System.Drawing.Size(75, 23);
            this.srcBrowse.TabIndex = 10;
            this.srcBrowse.Text = "Browse";
            this.srcBrowse.UseVisualStyleBackColor = true;
            this.srcBrowse.Click += new System.EventHandler(this.srcBrowse_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Destination File";
            // 
            // destFilePath
            // 
            this.destFilePath.Location = new System.Drawing.Point(12, 175);
            this.destFilePath.Name = "destFilePath";
            this.destFilePath.Size = new System.Drawing.Size(183, 20);
            this.destFilePath.TabIndex = 12;
            // 
            // destBrowse
            // 
            this.destBrowse.Location = new System.Drawing.Point(201, 173);
            this.destBrowse.Name = "destBrowse";
            this.destBrowse.Size = new System.Drawing.Size(75, 23);
            this.destBrowse.TabIndex = 13;
            this.destBrowse.Text = "Browse";
            this.destBrowse.UseVisualStyleBackColor = true;
            this.destBrowse.Click += new System.EventHandler(this.destBrowse_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 201);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // encryptBtn2
            // 
            this.encryptBtn2.AutoSize = true;
            this.encryptBtn2.Location = new System.Drawing.Point(79, 12);
            this.encryptBtn2.Name = "encryptBtn2";
            this.encryptBtn2.Size = new System.Drawing.Size(100, 17);
            this.encryptBtn2.TabIndex = 15;
            this.encryptBtn2.TabStop = true;
            this.encryptBtn2.Text = "Encrypt Existing";
            this.encryptBtn2.UseVisualStyleBackColor = true;
            this.encryptBtn2.CheckedChanged += new System.EventHandler(this.encryptBtn2_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(93, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "Test";
            this.label5.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 236);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.encryptBtn2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.destBrowse);
            this.Controls.Add(this.destFilePath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.srcBrowse);
            this.Controls.Add(this.srcFileBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.keyBrowse);
            this.Controls.Add(this.keyPathBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ivBrowse);
            this.Controls.Add(this.ivPathBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.decryptBtn);
            this.Controls.Add(this.encBtn);
            this.Name = "Form1";
            this.Text = "Basic Encryption";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton encBtn;
        private System.Windows.Forms.RadioButton decryptBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ivPathBox;
        private System.Windows.Forms.Button ivBrowse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox keyPathBox;
        private System.Windows.Forms.Button keyBrowse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox srcFileBox;
        private System.Windows.Forms.Button srcBrowse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox destFilePath;
        private System.Windows.Forms.Button destBrowse;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.RadioButton encryptBtn2;
        private System.Windows.Forms.Label label5;
    }
}


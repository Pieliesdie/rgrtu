namespace digital_signature_RSA
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.N_maskedTextBox4 = new System.Windows.Forms.MaskedTextBox();
            this.E_maskedTextBox3 = new System.Windows.Forms.MaskedTextBox();
            this.EncryptButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Q_maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
            this.P_maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.Hash_richTextBox = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Message_richTextBox = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.N_maskedTextBox5 = new System.Windows.Forms.MaskedTextBox();
            this.E_maskedTextBox6 = new System.Windows.Forms.MaskedTextBox();
            this.CheckButton = new System.Windows.Forms.Button();
            this.Hash_richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.Message_richTextBox4 = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(587, 375);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.N_maskedTextBox4);
            this.tabPage1.Controls.Add(this.E_maskedTextBox3);
            this.tabPage1.Controls.Add(this.EncryptButton);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.Q_maskedTextBox2);
            this.tabPage1.Controls.Add(this.P_maskedTextBox1);
            this.tabPage1.Controls.Add(this.Hash_richTextBox);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.Message_richTextBox);
            this.tabPage1.Location = new System.Drawing.Point(23, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(560, 367);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Encrypt";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label6.Location = new System.Drawing.Point(382, 261);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "N";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label5.Location = new System.Drawing.Point(298, 261);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "E";
            // 
            // N_maskedTextBox4
            // 
            this.N_maskedTextBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.N_maskedTextBox4.Location = new System.Drawing.Point(348, 284);
            this.N_maskedTextBox4.Name = "N_maskedTextBox4";
            this.N_maskedTextBox4.Size = new System.Drawing.Size(97, 26);
            this.N_maskedTextBox4.TabIndex = 10;
            this.N_maskedTextBox4.ValidatingType = typeof(int);
            // 
            // E_maskedTextBox3
            // 
            this.E_maskedTextBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.E_maskedTextBox3.Location = new System.Drawing.Point(260, 284);
            this.E_maskedTextBox3.Name = "E_maskedTextBox3";
            this.E_maskedTextBox3.Size = new System.Drawing.Size(88, 26);
            this.E_maskedTextBox3.TabIndex = 9;
            this.E_maskedTextBox3.ValidatingType = typeof(int);
            // 
            // EncryptButton
            // 
            this.EncryptButton.Location = new System.Drawing.Point(24, 325);
            this.EncryptButton.Name = "EncryptButton";
            this.EncryptButton.Size = new System.Drawing.Size(126, 23);
            this.EncryptButton.TabIndex = 8;
            this.EncryptButton.Text = "Encrypt";
            this.EncryptButton.UseVisualStyleBackColor = true;
            this.EncryptButton.Click += new System.EventHandler(this.EncryptButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label4.Location = new System.Drawing.Point(128, 261);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Q";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label3.Location = new System.Drawing.Point(33, 261);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "P";
            // 
            // Q_maskedTextBox2
            // 
            this.Q_maskedTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.Q_maskedTextBox2.Location = new System.Drawing.Point(116, 284);
            this.Q_maskedTextBox2.Name = "Q_maskedTextBox2";
            this.Q_maskedTextBox2.Size = new System.Drawing.Size(96, 26);
            this.Q_maskedTextBox2.TabIndex = 5;
            this.Q_maskedTextBox2.Text = "2579";
            this.Q_maskedTextBox2.ValidatingType = typeof(int);
            // 
            // P_maskedTextBox1
            // 
            this.P_maskedTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.P_maskedTextBox1.Location = new System.Drawing.Point(24, 284);
            this.P_maskedTextBox1.Name = "P_maskedTextBox1";
            this.P_maskedTextBox1.Size = new System.Drawing.Size(86, 26);
            this.P_maskedTextBox1.TabIndex = 4;
            this.P_maskedTextBox1.Text = "3557";
            this.P_maskedTextBox1.ValidatingType = typeof(int);
            // 
            // Hash_richTextBox
            // 
            this.Hash_richTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Hash_richTextBox.Location = new System.Drawing.Point(3, 139);
            this.Hash_richTextBox.Name = "Hash_richTextBox";
            this.Hash_richTextBox.Size = new System.Drawing.Size(554, 85);
            this.Hash_richTextBox.TabIndex = 3;
            this.Hash_richTextBox.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label2.Location = new System.Drawing.Point(33, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Digital Signature";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.Location = new System.Drawing.Point(33, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Message";
            // 
            // Message_richTextBox
            // 
            this.Message_richTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Message_richTextBox.Location = new System.Drawing.Point(3, 28);
            this.Message_richTextBox.Name = "Message_richTextBox";
            this.Message_richTextBox.Size = new System.Drawing.Size(554, 85);
            this.Message_richTextBox.TabIndex = 0;
            this.Message_richTextBox.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.N_maskedTextBox5);
            this.tabPage2.Controls.Add(this.E_maskedTextBox6);
            this.tabPage2.Controls.Add(this.CheckButton);
            this.tabPage2.Controls.Add(this.Hash_richTextBox3);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.Message_richTextBox4);
            this.tabPage2.Location = new System.Drawing.Point(23, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(560, 367);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Decrypt";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label7.Location = new System.Drawing.Point(145, 229);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 20);
            this.label7.TabIndex = 25;
            this.label7.Text = "N";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label8.Location = new System.Drawing.Point(53, 232);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 20);
            this.label8.TabIndex = 24;
            this.label8.Text = "E";
            // 
            // N_maskedTextBox5
            // 
            this.N_maskedTextBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.N_maskedTextBox5.Location = new System.Drawing.Point(108, 255);
            this.N_maskedTextBox5.Name = "N_maskedTextBox5";
            this.N_maskedTextBox5.Size = new System.Drawing.Size(105, 26);
            this.N_maskedTextBox5.TabIndex = 23;
            this.N_maskedTextBox5.ValidatingType = typeof(int);
            // 
            // E_maskedTextBox6
            // 
            this.E_maskedTextBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.E_maskedTextBox6.Location = new System.Drawing.Point(18, 255);
            this.E_maskedTextBox6.Name = "E_maskedTextBox6";
            this.E_maskedTextBox6.Size = new System.Drawing.Size(92, 26);
            this.E_maskedTextBox6.TabIndex = 22;
            this.E_maskedTextBox6.ValidatingType = typeof(int);
            // 
            // CheckButton
            // 
            this.CheckButton.Location = new System.Drawing.Point(40, 300);
            this.CheckButton.Name = "CheckButton";
            this.CheckButton.Size = new System.Drawing.Size(126, 23);
            this.CheckButton.TabIndex = 21;
            this.CheckButton.Text = "Check";
            this.CheckButton.UseVisualStyleBackColor = true;
            this.CheckButton.Click += new System.EventHandler(this.CheckButton_Click);
            // 
            // Hash_richTextBox3
            // 
            this.Hash_richTextBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Hash_richTextBox3.Location = new System.Drawing.Point(3, 141);
            this.Hash_richTextBox3.Name = "Hash_richTextBox3";
            this.Hash_richTextBox3.Size = new System.Drawing.Size(554, 85);
            this.Hash_richTextBox3.TabIndex = 16;
            this.Hash_richTextBox3.Text = "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label11.Location = new System.Drawing.Point(33, 118);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(133, 20);
            this.label11.TabIndex = 15;
            this.label11.Text = "Digital Signature";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label12.Location = new System.Drawing.Point(33, 6);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 20);
            this.label12.TabIndex = 14;
            this.label12.Text = "Message";
            // 
            // Message_richTextBox4
            // 
            this.Message_richTextBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Message_richTextBox4.Location = new System.Drawing.Point(3, 30);
            this.Message_richTextBox4.Name = "Message_richTextBox4";
            this.Message_richTextBox4.Size = new System.Drawing.Size(554, 85);
            this.Message_richTextBox4.TabIndex = 13;
            this.Message_richTextBox4.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label9.Location = new System.Drawing.Point(47, 230);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 20);
            this.label9.TabIndex = 13;
            this.label9.Text = "Private key";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label10.Location = new System.Drawing.Point(309, 230);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 20);
            this.label10.TabIndex = 14;
            this.label10.Text = "Public keys";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 375);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "digital signature";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox N_maskedTextBox4;
        private System.Windows.Forms.MaskedTextBox E_maskedTextBox3;
        private System.Windows.Forms.Button EncryptButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox Q_maskedTextBox2;
        private System.Windows.Forms.MaskedTextBox P_maskedTextBox1;
        private System.Windows.Forms.RichTextBox Hash_richTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox Message_richTextBox;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox N_maskedTextBox5;
        private System.Windows.Forms.MaskedTextBox E_maskedTextBox6;
        private System.Windows.Forms.Button CheckButton;
        private System.Windows.Forms.RichTextBox Hash_richTextBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RichTextBox Message_richTextBox4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
    }
}


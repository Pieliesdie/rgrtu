namespace RSA
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageKeys = new System.Windows.Forms.TabPage();
            this.labelN = new System.Windows.Forms.Label();
            this.Mod_textBox = new System.Windows.Forms.TextBox();
            this.labelpblickey = new System.Windows.Forms.Label();
            this.labelPrvtkey = new System.Windows.Forms.Label();
            this.Private_key_textBox = new System.Windows.Forms.TextBox();
            this.PublicKey_textBox = new System.Windows.Forms.TextBox();
            this.GenerateKeys_button = new System.Windows.Forms.Button();
            this.labelp = new System.Windows.Forms.Label();
            this.labelq = new System.Windows.Forms.Label();
            this.p_maskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.q_maskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.tabPageEncrypt = new System.Windows.Forms.TabPage();
            this.Encrypt_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ModToEncr_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PublicKeyToEncr_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.message_richTextBox = new System.Windows.Forms.RichTextBox();
            this.tabPageDecrypt = new System.Windows.Forms.TabPage();
            this.Decrypt_button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.ModToDecr_textBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.PrivateKeyToDecr_textBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Encrmsg_richTextBox = new System.Windows.Forms.RichTextBox();
            this.tabControl.SuspendLayout();
            this.tabPageKeys.SuspendLayout();
            this.tabPageEncrypt.SuspendLayout();
            this.tabPageDecrypt.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPageKeys);
            this.tabControl.Controls.Add(this.tabPageEncrypt);
            this.tabControl.Controls.Add(this.tabPageDecrypt);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(323, 368);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageKeys
            // 
            this.tabPageKeys.Controls.Add(this.labelN);
            this.tabPageKeys.Controls.Add(this.Mod_textBox);
            this.tabPageKeys.Controls.Add(this.labelpblickey);
            this.tabPageKeys.Controls.Add(this.labelPrvtkey);
            this.tabPageKeys.Controls.Add(this.Private_key_textBox);
            this.tabPageKeys.Controls.Add(this.PublicKey_textBox);
            this.tabPageKeys.Controls.Add(this.GenerateKeys_button);
            this.tabPageKeys.Controls.Add(this.labelp);
            this.tabPageKeys.Controls.Add(this.labelq);
            this.tabPageKeys.Controls.Add(this.p_maskedTextBox);
            this.tabPageKeys.Controls.Add(this.q_maskedTextBox);
            this.tabPageKeys.Location = new System.Drawing.Point(4, 22);
            this.tabPageKeys.Name = "tabPageKeys";
            this.tabPageKeys.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageKeys.Size = new System.Drawing.Size(315, 342);
            this.tabPageKeys.TabIndex = 0;
            this.tabPageKeys.Text = "Keys";
            this.tabPageKeys.UseVisualStyleBackColor = true;
            // 
            // labelN
            // 
            this.labelN.AutoSize = true;
            this.labelN.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelN.Location = new System.Drawing.Point(14, 245);
            this.labelN.Name = "labelN";
            this.labelN.Size = new System.Drawing.Size(54, 25);
            this.labelN.TabIndex = 10;
            this.labelN.Text = "Mod";
            // 
            // Mod_textBox
            // 
            this.Mod_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Mod_textBox.Location = new System.Drawing.Point(19, 273);
            this.Mod_textBox.Name = "Mod_textBox";
            this.Mod_textBox.Size = new System.Drawing.Size(274, 26);
            this.Mod_textBox.TabIndex = 9;
            // 
            // labelpblickey
            // 
            this.labelpblickey.AutoSize = true;
            this.labelpblickey.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelpblickey.Location = new System.Drawing.Point(14, 131);
            this.labelpblickey.Name = "labelpblickey";
            this.labelpblickey.Size = new System.Drawing.Size(108, 25);
            this.labelpblickey.TabIndex = 8;
            this.labelpblickey.Text = "PublicKey";
            // 
            // labelPrvtkey
            // 
            this.labelPrvtkey.AutoSize = true;
            this.labelPrvtkey.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPrvtkey.Location = new System.Drawing.Point(14, 188);
            this.labelPrvtkey.Name = "labelPrvtkey";
            this.labelPrvtkey.Size = new System.Drawing.Size(116, 25);
            this.labelPrvtkey.TabIndex = 7;
            this.labelPrvtkey.Text = "PrivateKey";
            // 
            // Private_key_textBox
            // 
            this.Private_key_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Private_key_textBox.Location = new System.Drawing.Point(19, 216);
            this.Private_key_textBox.Name = "Private_key_textBox";
            this.Private_key_textBox.Size = new System.Drawing.Size(274, 26);
            this.Private_key_textBox.TabIndex = 6;
            // 
            // PublicKey_textBox
            // 
            this.PublicKey_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PublicKey_textBox.Location = new System.Drawing.Point(19, 159);
            this.PublicKey_textBox.Name = "PublicKey_textBox";
            this.PublicKey_textBox.Size = new System.Drawing.Size(274, 26);
            this.PublicKey_textBox.TabIndex = 5;
            // 
            // GenerateKeys_button
            // 
            this.GenerateKeys_button.Location = new System.Drawing.Point(19, 105);
            this.GenerateKeys_button.Name = "GenerateKeys_button";
            this.GenerateKeys_button.Size = new System.Drawing.Size(75, 23);
            this.GenerateKeys_button.TabIndex = 4;
            this.GenerateKeys_button.Text = "Generate";
            this.GenerateKeys_button.UseVisualStyleBackColor = true;
            this.GenerateKeys_button.Click += new System.EventHandler(this.GenerateKeys_button_Click);
            // 
            // labelp
            // 
            this.labelp.AutoSize = true;
            this.labelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelp.Location = new System.Drawing.Point(210, 33);
            this.labelp.Name = "labelp";
            this.labelp.Size = new System.Drawing.Size(26, 25);
            this.labelp.TabIndex = 3;
            this.labelp.Text = "P";
            // 
            // labelq
            // 
            this.labelq.AutoSize = true;
            this.labelq.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelq.Location = new System.Drawing.Point(66, 33);
            this.labelq.Name = "labelq";
            this.labelq.Size = new System.Drawing.Size(28, 25);
            this.labelq.TabIndex = 2;
            this.labelq.Text = "Q";
            // 
            // p_maskedTextBox
            // 
            this.p_maskedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.p_maskedTextBox.Location = new System.Drawing.Point(155, 61);
            this.p_maskedTextBox.Name = "p_maskedTextBox";
            this.p_maskedTextBox.Size = new System.Drawing.Size(138, 26);
            this.p_maskedTextBox.TabIndex = 1;
            // 
            // q_maskedTextBox
            // 
            this.q_maskedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.q_maskedTextBox.Location = new System.Drawing.Point(19, 61);
            this.q_maskedTextBox.Name = "q_maskedTextBox";
            this.q_maskedTextBox.Size = new System.Drawing.Size(130, 26);
            this.q_maskedTextBox.TabIndex = 0;
            this.q_maskedTextBox.ValidatingType = typeof(int);
            // 
            // tabPageEncrypt
            // 
            this.tabPageEncrypt.Controls.Add(this.Encrypt_button);
            this.tabPageEncrypt.Controls.Add(this.label2);
            this.tabPageEncrypt.Controls.Add(this.ModToEncr_textBox);
            this.tabPageEncrypt.Controls.Add(this.label3);
            this.tabPageEncrypt.Controls.Add(this.PublicKeyToEncr_textBox);
            this.tabPageEncrypt.Controls.Add(this.label1);
            this.tabPageEncrypt.Controls.Add(this.message_richTextBox);
            this.tabPageEncrypt.Location = new System.Drawing.Point(4, 22);
            this.tabPageEncrypt.Name = "tabPageEncrypt";
            this.tabPageEncrypt.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEncrypt.Size = new System.Drawing.Size(315, 342);
            this.tabPageEncrypt.TabIndex = 1;
            this.tabPageEncrypt.Text = "Encrypt";
            this.tabPageEncrypt.UseVisualStyleBackColor = true;
            // 
            // Encrypt_button
            // 
            this.Encrypt_button.Location = new System.Drawing.Point(17, 304);
            this.Encrypt_button.Name = "Encrypt_button";
            this.Encrypt_button.Size = new System.Drawing.Size(75, 23);
            this.Encrypt_button.TabIndex = 15;
            this.Encrypt_button.Text = "Encrypt";
            this.Encrypt_button.UseVisualStyleBackColor = true;
            this.Encrypt_button.Click += new System.EventHandler(this.Encrypt_button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 25);
            this.label2.TabIndex = 14;
            this.label2.Text = "Mod";
            // 
            // ModToEncr_textBox
            // 
            this.ModToEncr_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ModToEncr_textBox.Location = new System.Drawing.Point(17, 272);
            this.ModToEncr_textBox.Name = "ModToEncr_textBox";
            this.ModToEncr_textBox.Size = new System.Drawing.Size(268, 26);
            this.ModToEncr_textBox.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "PublicKey";
            // 
            // PublicKeyToEncr_textBox
            // 
            this.PublicKeyToEncr_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PublicKeyToEncr_textBox.Location = new System.Drawing.Point(17, 211);
            this.PublicKeyToEncr_textBox.Name = "PublicKeyToEncr_textBox";
            this.PublicKeyToEncr_textBox.Size = new System.Drawing.Size(268, 26);
            this.PublicKeyToEncr_textBox.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Message";
            // 
            // message_richTextBox
            // 
            this.message_richTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.message_richTextBox.Location = new System.Drawing.Point(17, 32);
            this.message_richTextBox.Name = "message_richTextBox";
            this.message_richTextBox.Size = new System.Drawing.Size(268, 148);
            this.message_richTextBox.TabIndex = 0;
            this.message_richTextBox.Text = "";
            // 
            // tabPageDecrypt
            // 
            this.tabPageDecrypt.Controls.Add(this.Decrypt_button);
            this.tabPageDecrypt.Controls.Add(this.label4);
            this.tabPageDecrypt.Controls.Add(this.ModToDecr_textBox);
            this.tabPageDecrypt.Controls.Add(this.label5);
            this.tabPageDecrypt.Controls.Add(this.PrivateKeyToDecr_textBox);
            this.tabPageDecrypt.Controls.Add(this.label6);
            this.tabPageDecrypt.Controls.Add(this.Encrmsg_richTextBox);
            this.tabPageDecrypt.Location = new System.Drawing.Point(4, 22);
            this.tabPageDecrypt.Name = "tabPageDecrypt";
            this.tabPageDecrypt.Size = new System.Drawing.Size(315, 342);
            this.tabPageDecrypt.TabIndex = 2;
            this.tabPageDecrypt.Text = "Decrypt";
            this.tabPageDecrypt.UseVisualStyleBackColor = true;
            // 
            // Decrypt_button
            // 
            this.Decrypt_button.Location = new System.Drawing.Point(17, 307);
            this.Decrypt_button.Name = "Decrypt_button";
            this.Decrypt_button.Size = new System.Drawing.Size(75, 23);
            this.Decrypt_button.TabIndex = 22;
            this.Decrypt_button.Text = "Decrypt";
            this.Decrypt_button.UseVisualStyleBackColor = true;
            this.Decrypt_button.Click += new System.EventHandler(this.Decrypt_button_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 247);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 25);
            this.label4.TabIndex = 21;
            this.label4.Text = "Mod";
            // 
            // ModToDecr_textBox
            // 
            this.ModToDecr_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ModToDecr_textBox.Location = new System.Drawing.Point(17, 275);
            this.ModToDecr_textBox.Name = "ModToDecr_textBox";
            this.ModToDecr_textBox.Size = new System.Drawing.Size(268, 26);
            this.ModToDecr_textBox.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(12, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 25);
            this.label5.TabIndex = 19;
            this.label5.Text = "PrivateKey";
            // 
            // PrivateKeyToDecr_textBox
            // 
            this.PrivateKeyToDecr_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PrivateKeyToDecr_textBox.Location = new System.Drawing.Point(17, 214);
            this.PrivateKeyToDecr_textBox.Name = "PrivateKeyToDecr_textBox";
            this.PrivateKeyToDecr_textBox.Size = new System.Drawing.Size(268, 26);
            this.PrivateKeyToDecr_textBox.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(12, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 25);
            this.label6.TabIndex = 17;
            this.label6.Text = "Message";
            // 
            // Encrmsg_richTextBox
            // 
            this.Encrmsg_richTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Encrmsg_richTextBox.Location = new System.Drawing.Point(17, 35);
            this.Encrmsg_richTextBox.Name = "Encrmsg_richTextBox";
            this.Encrmsg_richTextBox.Size = new System.Drawing.Size(268, 148);
            this.Encrmsg_richTextBox.TabIndex = 16;
            this.Encrmsg_richTextBox.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(323, 368);
            this.Controls.Add(this.tabControl);
            this.Name = "MainForm";
            this.Text = "RSA";
            this.tabControl.ResumeLayout(false);
            this.tabPageKeys.ResumeLayout(false);
            this.tabPageKeys.PerformLayout();
            this.tabPageEncrypt.ResumeLayout(false);
            this.tabPageEncrypt.PerformLayout();
            this.tabPageDecrypt.ResumeLayout(false);
            this.tabPageDecrypt.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageKeys;
        private System.Windows.Forms.Label labelN;
        private System.Windows.Forms.TextBox Mod_textBox;
        private System.Windows.Forms.Label labelpblickey;
        private System.Windows.Forms.Label labelPrvtkey;
        private System.Windows.Forms.TextBox Private_key_textBox;
        private System.Windows.Forms.TextBox PublicKey_textBox;
        private System.Windows.Forms.Button GenerateKeys_button;
        private System.Windows.Forms.Label labelp;
        private System.Windows.Forms.Label labelq;
        private System.Windows.Forms.MaskedTextBox p_maskedTextBox;
        private System.Windows.Forms.MaskedTextBox q_maskedTextBox;
        private System.Windows.Forms.TabPage tabPageEncrypt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox message_richTextBox;
        private System.Windows.Forms.TabPage tabPageDecrypt;
        private System.Windows.Forms.Button Encrypt_button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ModToEncr_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PublicKeyToEncr_textBox;
        private System.Windows.Forms.Button Decrypt_button;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ModToDecr_textBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox PrivateKeyToDecr_textBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox Encrmsg_richTextBox;
    }
}


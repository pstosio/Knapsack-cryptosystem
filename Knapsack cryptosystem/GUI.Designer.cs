﻿namespace Knapsack_cryptosystem
{
    partial class GUI
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
            this.textBox_plainText = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox_cipher = new System.Windows.Forms.TextBox();
            this.textBox_privateKey = new System.Windows.Forms.TextBox();
            this.textBox_publicKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_plainText
            // 
            this.textBox_plainText.Location = new System.Drawing.Point(12, 68);
            this.textBox_plainText.Multiline = true;
            this.textBox_plainText.Name = "textBox_plainText";
            this.textBox_plainText.Size = new System.Drawing.Size(634, 86);
            this.textBox_plainText.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 160);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(228, 48);
            this.button1.TabIndex = 1;
            this.button1.Text = "Szyfruj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(418, 160);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(228, 48);
            this.button2.TabIndex = 2;
            this.button2.Text = "Odszyfruj";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox_cipher
            // 
            this.textBox_cipher.Location = new System.Drawing.Point(12, 214);
            this.textBox_cipher.Multiline = true;
            this.textBox_cipher.Name = "textBox_cipher";
            this.textBox_cipher.Size = new System.Drawing.Size(634, 282);
            this.textBox_cipher.TabIndex = 3;
            // 
            // textBox_privateKey
            // 
            this.textBox_privateKey.Location = new System.Drawing.Point(194, 12);
            this.textBox_privateKey.Name = "textBox_privateKey";
            this.textBox_privateKey.ReadOnly = true;
            this.textBox_privateKey.Size = new System.Drawing.Size(452, 22);
            this.textBox_privateKey.TabIndex = 4;
            // 
            // textBox_publicKey
            // 
            this.textBox_publicKey.Location = new System.Drawing.Point(194, 40);
            this.textBox_publicKey.Name = "textBox_publicKey";
            this.textBox_publicKey.ReadOnly = true;
            this.textBox_publicKey.Size = new System.Drawing.Size(452, 22);
            this.textBox_publicKey.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Klucz prywatny";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Klucz publiczny";
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 508);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_publicKey);
            this.Controls.Add(this.textBox_privateKey);
            this.Controls.Add(this.textBox_cipher);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_plainText);
            this.Name = "GUI";
            this.Text = "Kryptografia, Knapsack. Piotr Stosio & Piotr Kocemba";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_plainText;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox_cipher;
        private System.Windows.Forms.TextBox textBox_privateKey;
        private System.Windows.Forms.TextBox textBox_publicKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
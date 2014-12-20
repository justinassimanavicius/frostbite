namespace Frostbite.GameTestHarness
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
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.curentPlayerIdLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.player1IdLabel = new System.Windows.Forms.Label();
            this.player2IdLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Player1HandListBox = new System.Windows.Forms.ListBox();
            this.Player1UnitsListBox = new System.Windows.Forms.ListBox();
            this.Player2HandListBox = new System.Windows.Forms.ListBox();
            this.Player2UnitsListBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.player1ManaLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.player2ManaLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start game";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 42);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(395, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 69);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Play card";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(93, 69);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "End turn";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Player Id:";
            // 
            // curentPlayerIdLabel
            // 
            this.curentPlayerIdLabel.AutoSize = true;
            this.curentPlayerIdLabel.Location = new System.Drawing.Point(70, 99);
            this.curentPlayerIdLabel.Name = "curentPlayerIdLabel";
            this.curentPlayerIdLabel.Size = new System.Drawing.Size(0, 13);
            this.curentPlayerIdLabel.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Player 1";
            // 
            // player1IdLabel
            // 
            this.player1IdLabel.AutoSize = true;
            this.player1IdLabel.Location = new System.Drawing.Point(58, 171);
            this.player1IdLabel.Name = "player1IdLabel";
            this.player1IdLabel.Size = new System.Drawing.Size(0, 13);
            this.player1IdLabel.TabIndex = 8;
            // 
            // player2IdLabel
            // 
            this.player2IdLabel.AutoSize = true;
            this.player2IdLabel.Location = new System.Drawing.Point(508, 171);
            this.player2IdLabel.Name = "player2IdLabel";
            this.player2IdLabel.Size = new System.Drawing.Size(0, 13);
            this.player2IdLabel.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(463, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Player 2";
            // 
            // Player1HandListBox
            // 
            this.Player1HandListBox.FormattingEnabled = true;
            this.Player1HandListBox.Location = new System.Drawing.Point(12, 230);
            this.Player1HandListBox.Name = "Player1HandListBox";
            this.Player1HandListBox.Size = new System.Drawing.Size(312, 95);
            this.Player1HandListBox.TabIndex = 13;
            // 
            // Player1UnitsListBox
            // 
            this.Player1UnitsListBox.FormattingEnabled = true;
            this.Player1UnitsListBox.Location = new System.Drawing.Point(12, 331);
            this.Player1UnitsListBox.Name = "Player1UnitsListBox";
            this.Player1UnitsListBox.Size = new System.Drawing.Size(312, 95);
            this.Player1UnitsListBox.TabIndex = 13;
            // 
            // Player2HandListBox
            // 
            this.Player2HandListBox.FormattingEnabled = true;
            this.Player2HandListBox.Location = new System.Drawing.Point(466, 230);
            this.Player2HandListBox.Name = "Player2HandListBox";
            this.Player2HandListBox.Size = new System.Drawing.Size(312, 95);
            this.Player2HandListBox.TabIndex = 13;
            // 
            // Player2UnitsListBox
            // 
            this.Player2UnitsListBox.FormattingEnabled = true;
            this.Player2UnitsListBox.Location = new System.Drawing.Point(466, 331);
            this.Player2UnitsListBox.Name = "Player2UnitsListBox";
            this.Player2UnitsListBox.Size = new System.Drawing.Size(312, 95);
            this.Player2UnitsListBox.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Mana";
            // 
            // player1ManaLabel
            // 
            this.player1ManaLabel.AutoSize = true;
            this.player1ManaLabel.Location = new System.Drawing.Point(58, 184);
            this.player1ManaLabel.Name = "player1ManaLabel";
            this.player1ManaLabel.Size = new System.Drawing.Size(0, 13);
            this.player1ManaLabel.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(463, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Mana";
            // 
            // player2ManaLabel
            // 
            this.player2ManaLabel.AutoSize = true;
            this.player2ManaLabel.Location = new System.Drawing.Point(508, 184);
            this.player2ManaLabel.Name = "player2ManaLabel";
            this.player2ManaLabel.Size = new System.Drawing.Size(0, 13);
            this.player2ManaLabel.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 569);
            this.Controls.Add(this.Player2UnitsListBox);
            this.Controls.Add(this.Player2HandListBox);
            this.Controls.Add(this.Player1UnitsListBox);
            this.Controls.Add(this.Player1HandListBox);
            this.Controls.Add(this.player2ManaLabel);
            this.Controls.Add(this.player2IdLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.player1ManaLabel);
            this.Controls.Add(this.player1IdLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.curentPlayerIdLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label curentPlayerIdLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label player1IdLabel;
        private System.Windows.Forms.Label player2IdLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox Player1HandListBox;
        private System.Windows.Forms.ListBox Player1UnitsListBox;
        private System.Windows.Forms.ListBox Player2HandListBox;
        private System.Windows.Forms.ListBox Player2UnitsListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label player1ManaLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label player2ManaLabel;
    }
}


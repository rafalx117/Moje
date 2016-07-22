namespace pieniężne_rozrachunki
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
            this.ReceiptTextBox = new System.Windows.Forms.TextBox();
            this.NumberOfPeopleTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CalculateButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ReceiptTextBox
            // 
            this.ReceiptTextBox.Location = new System.Drawing.Point(124, 12);
            this.ReceiptTextBox.Name = "ReceiptTextBox";
            this.ReceiptTextBox.Size = new System.Drawing.Size(100, 20);
            this.ReceiptTextBox.TabIndex = 0;
            this.ReceiptTextBox.Text = "15";
            // 
            // NumberOfPeopleTextBox
            // 
            this.NumberOfPeopleTextBox.Location = new System.Drawing.Point(124, 50);
            this.NumberOfPeopleTextBox.Name = "NumberOfPeopleTextBox";
            this.NumberOfPeopleTextBox.Size = new System.Drawing.Size(100, 20);
            this.NumberOfPeopleTextBox.TabIndex = 1;
            this.NumberOfPeopleTextBox.Text = "4";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Rachunek";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Liczba osób";
            // 
            // CalculateButton
            // 
            this.CalculateButton.Location = new System.Drawing.Point(47, 102);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(144, 41);
            this.CalculateButton.TabIndex = 4;
            this.CalculateButton.Text = "Start";
            this.CalculateButton.UseVisualStyleBackColor = true;
            this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 155);
            this.Controls.Add(this.CalculateButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NumberOfPeopleTextBox);
            this.Controls.Add(this.ReceiptTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ReceiptTextBox;
        private System.Windows.Forms.TextBox NumberOfPeopleTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CalculateButton;
    }
}


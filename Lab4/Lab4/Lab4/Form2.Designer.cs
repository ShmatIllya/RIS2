namespace Lab4
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.bookIdBox = new System.Windows.Forms.TextBox();
            this.authorBox = new System.Windows.Forms.TextBox();
            this.bookNameBox = new System.Windows.Forms.TextBox();
            this.takenCheckBox = new System.Windows.Forms.CheckBox();
            this.fioBox = new System.Windows.Forms.TextBox();
            this.daysBox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Код книги";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Название книги";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Авто книги";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Одолжена ли книга";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(238, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(209, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "ФИО последнего одолжившего";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(238, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(221, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Количество дней на сдачу книги";
            // 
            // bookIdBox
            // 
            this.bookIdBox.Location = new System.Drawing.Point(12, 28);
            this.bookIdBox.Name = "bookIdBox";
            this.bookIdBox.Size = new System.Drawing.Size(135, 22);
            this.bookIdBox.TabIndex = 6;
            // 
            // authorBox
            // 
            this.authorBox.Location = new System.Drawing.Point(15, 139);
            this.authorBox.Name = "authorBox";
            this.authorBox.Size = new System.Drawing.Size(135, 22);
            this.authorBox.TabIndex = 7;
            // 
            // bookNameBox
            // 
            this.bookNameBox.Location = new System.Drawing.Point(12, 86);
            this.bookNameBox.Name = "bookNameBox";
            this.bookNameBox.Size = new System.Drawing.Size(135, 22);
            this.bookNameBox.TabIndex = 8;
            // 
            // takenCheckBox
            // 
            this.takenCheckBox.AutoSize = true;
            this.takenCheckBox.Location = new System.Drawing.Point(15, 199);
            this.takenCheckBox.Name = "takenCheckBox";
            this.takenCheckBox.Size = new System.Drawing.Size(46, 20);
            this.takenCheckBox.TabIndex = 9;
            this.takenCheckBox.Text = "Да";
            this.takenCheckBox.UseVisualStyleBackColor = true;
            // 
            // fioBox
            // 
            this.fioBox.Location = new System.Drawing.Point(241, 28);
            this.fioBox.Name = "fioBox";
            this.fioBox.Size = new System.Drawing.Size(135, 22);
            this.fioBox.TabIndex = 10;
            // 
            // daysBox
            // 
            this.daysBox.Location = new System.Drawing.Point(241, 86);
            this.daysBox.Name = "daysBox";
            this.daysBox.Size = new System.Drawing.Size(135, 22);
            this.daysBox.TabIndex = 11;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(241, 171);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(206, 65);
            this.addButton.TabIndex = 12;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(464, 171);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(198, 65);
            this.cancelButton.TabIndex = 13;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 260);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.daysBox);
            this.Controls.Add(this.fioBox);
            this.Controls.Add(this.takenCheckBox);
            this.Controls.Add(this.bookNameBox);
            this.Controls.Add(this.authorBox);
            this.Controls.Add(this.bookIdBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Добавить книгу";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox bookIdBox;
        private System.Windows.Forms.TextBox authorBox;
        private System.Windows.Forms.TextBox bookNameBox;
        private System.Windows.Forms.CheckBox takenCheckBox;
        private System.Windows.Forms.TextBox fioBox;
        private System.Windows.Forms.TextBox daysBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button cancelButton;
    }
}
namespace PasswordGenerator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            generateButton = new Button();
            simvolsCheak = new CheckBox();
            numbersCheak = new CheckBox();
            bigRegCheak = new CheckBox();
            smallRegCheak = new CheckBox();
            strangeSimvolsCheak = new CheckBox();
            clonsCheak = new CheckBox();
            passwordLength = new TextBox();
            label1 = new Label();
            passwordSpace = new TextBox();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // generateButton
            // 
            generateButton.Location = new Point(21, 175);
            generateButton.Name = "generateButton";
            generateButton.Size = new Size(148, 29);
            generateButton.TabIndex = 0;
            generateButton.Text = "Сгенерировать";
            generateButton.UseVisualStyleBackColor = true;
            generateButton.Click += generateButton_Click;
            // 
            // simvolsCheak
            // 
            simvolsCheak.AutoSize = true;
            simvolsCheak.Location = new Point(9, 27);
            simvolsCheak.Name = "simvolsCheak";
            simvolsCheak.Size = new Size(60, 19);
            simvolsCheak.TabIndex = 1;
            simvolsCheak.Text = "@#$%";
            simvolsCheak.UseVisualStyleBackColor = true;
            simvolsCheak.CheckedChanged += simvolsCheak_CheckedChanged;
            // 
            // numbersCheak
            // 
            numbersCheak.AutoSize = true;
            numbersCheak.Location = new Point(78, 27);
            numbersCheak.Name = "numbersCheak";
            numbersCheak.Size = new Size(62, 19);
            numbersCheak.TabIndex = 2;
            numbersCheak.Text = "123456";
            numbersCheak.UseVisualStyleBackColor = true;
            numbersCheak.CheckedChanged += numbersCheak_CheckedChanged;
            // 
            // bigRegCheak
            // 
            bigRegCheak.AutoSize = true;
            bigRegCheak.Location = new Point(9, 52);
            bigRegCheak.Name = "bigRegCheak";
            bigRegCheak.Size = new Size(63, 19);
            bigRegCheak.TabIndex = 3;
            bigRegCheak.Text = "ABCDE";
            bigRegCheak.UseVisualStyleBackColor = true;
            bigRegCheak.CheckedChanged += bigRegCheak_CheckedChanged;
            // 
            // smallRegCheak
            // 
            smallRegCheak.AutoSize = true;
            smallRegCheak.Location = new Point(78, 52);
            smallRegCheak.Name = "smallRegCheak";
            smallRegCheak.Size = new Size(58, 19);
            smallRegCheak.TabIndex = 4;
            smallRegCheak.Text = "abcde";
            smallRegCheak.UseVisualStyleBackColor = true;
            smallRegCheak.CheckedChanged += smallRegCheak_CheckedChanged;
            // 
            // strangeSimvolsCheak
            // 
            strangeSimvolsCheak.AutoSize = true;
            strangeSimvolsCheak.Location = new Point(78, 93);
            strangeSimvolsCheak.Name = "strangeSimvolsCheak";
            strangeSimvolsCheak.Size = new Size(107, 19);
            strangeSimvolsCheak.TabIndex = 5;
            strangeSimvolsCheak.Text = "{}[]()/\\'\"`~,;:.<>";
            strangeSimvolsCheak.UseVisualStyleBackColor = true;
            strangeSimvolsCheak.CheckedChanged += strangeSimvolsCheak_CheckedChanged;
            // 
            // clonsCheak
            // 
            clonsCheak.AutoSize = true;
            clonsCheak.Location = new Point(9, 93);
            clonsCheak.Name = "clonsCheak";
            clonsCheak.Size = new Size(69, 19);
            clonsCheak.TabIndex = 6;
            clonsCheak.Text = "il|1Lo0O";
            clonsCheak.UseVisualStyleBackColor = true;
            clonsCheak.CheckedChanged += clonsCheak_CheckedChanged;
            // 
            // passwordLength
            // 
            passwordLength.Location = new Point(57, 115);
            passwordLength.MaxLength = 8;
            passwordLength.Name = "passwordLength";
            passwordLength.Size = new Size(69, 23);
            passwordLength.TabIndex = 7;
            passwordLength.TextChanged += passwordLength_Changed;
            passwordLength.KeyPress += passwordLength_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 121);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 8;
            label1.Text = "Длина:";
            // 
            // passwordSpace
            // 
            passwordSpace.Location = new Point(9, 144);
            passwordSpace.MaxLength = 128;
            passwordSpace.Name = "passwordSpace";
            passwordSpace.Size = new Size(176, 23);
            passwordSpace.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 9);
            label2.Name = "label2";
            label2.Size = new Size(87, 15);
            label2.TabIndex = 10;
            label2.Text = "Использовать:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(7, 75);
            label3.Name = "label3";
            label3.Size = new Size(73, 15);
            label3.TabIndex = 11;
            label3.Text = "Исключить:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(194, 211);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(passwordSpace);
            Controls.Add(label1);
            Controls.Add(passwordLength);
            Controls.Add(clonsCheak);
            Controls.Add(strangeSimvolsCheak);
            Controls.Add(smallRegCheak);
            Controls.Add(bigRegCheak);
            Controls.Add(numbersCheak);
            Controls.Add(simvolsCheak);
            Controls.Add(generateButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button generateButton;
        private CheckBox simvolsCheak;
        private CheckBox numbersCheak;
        private CheckBox bigRegCheak;
        private CheckBox smallRegCheak;
        private CheckBox strangeSimvolsCheak;
        private CheckBox clonsCheak;
        private TextBox passwordLength;
        private Label label1;
        private TextBox passwordSpace;
        private Label label2;
        private Label label3;
    }
}

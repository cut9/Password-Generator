namespace PasswordGenerator
{
    partial class PasswordGeneratorForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasswordGeneratorForm));
            generateButton = new Button();
            symbolsCheckBox = new CheckBox();
            numbersCheckBox = new CheckBox();
            uppercaseCheckBox = new CheckBox();
            lowercaseCheckBox = new CheckBox();
            strangeSymbolsCheckBox = new CheckBox();
            similarElementsCheckBox = new CheckBox();
            lengthLabel = new Label();
            passwordTextBox = new TextBox();
            useLabel = new Label();
            excludeLabel = new Label();
            guaranteeCheckBox = new CheckBox();
            copyButton = new Button();
            passwordStrengthLabel = new Label();
            passwordStrengthBar = new ColoredProgressBar();
            autoCopyCheckBox = new CheckBox();
            passwordLengthUpDown = new NumericUpDown();
            toolTips = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)passwordLengthUpDown).BeginInit();
            SuspendLayout();
            // 
            // generateButton
            // 
            generateButton.Location = new Point(9, 173);
            generateButton.Name = "generateButton";
            generateButton.Size = new Size(148, 29);
            generateButton.TabIndex = 0;
            generateButton.Text = "Сгенерировать";
            generateButton.UseVisualStyleBackColor = true;
            generateButton.Click += generateButton_Click;
            // 
            // symbolsCheckBox
            // 
            symbolsCheckBox.AutoSize = true;
            symbolsCheckBox.Location = new Point(7, 52);
            symbolsCheckBox.Name = "symbolsCheckBox";
            symbolsCheckBox.Size = new Size(60, 19);
            symbolsCheckBox.TabIndex = 1;
            symbolsCheckBox.Text = "@#$%";
            symbolsCheckBox.UseVisualStyleBackColor = true;
            symbolsCheckBox.CheckedChanged += symbolsCheckBox_CheckedChanged;
            // 
            // numbersCheckBox
            // 
            numbersCheckBox.AutoSize = true;
            numbersCheckBox.Location = new Point(7, 27);
            numbersCheckBox.Name = "numbersCheckBox";
            numbersCheckBox.Size = new Size(62, 19);
            numbersCheckBox.TabIndex = 2;
            numbersCheckBox.Text = "123456";
            numbersCheckBox.UseVisualStyleBackColor = true;
            numbersCheckBox.CheckedChanged += numbersCheckBox_CheckedChanged;
            // 
            // uppercaseCheckBox
            // 
            uppercaseCheckBox.AutoSize = true;
            uppercaseCheckBox.Location = new Point(157, 27);
            uppercaseCheckBox.Name = "uppercaseCheckBox";
            uppercaseCheckBox.Size = new Size(63, 19);
            uppercaseCheckBox.TabIndex = 3;
            uppercaseCheckBox.Text = "ABCDE";
            uppercaseCheckBox.UseVisualStyleBackColor = true;
            uppercaseCheckBox.CheckedChanged += uppercaseCheckBox_CheckedChanged;
            // 
            // lowercaseCheckBox
            // 
            lowercaseCheckBox.AutoSize = true;
            lowercaseCheckBox.Location = new Point(82, 27);
            lowercaseCheckBox.Name = "lowercaseCheckBox";
            lowercaseCheckBox.Size = new Size(58, 19);
            lowercaseCheckBox.TabIndex = 4;
            lowercaseCheckBox.Text = "abcde";
            lowercaseCheckBox.UseVisualStyleBackColor = true;
            lowercaseCheckBox.CheckedChanged += lowercaseCheckBox_CheckedChanged;
            // 
            // strangeSymbolsCheckBox
            // 
            strangeSymbolsCheckBox.AutoSize = true;
            strangeSymbolsCheckBox.Location = new Point(82, 93);
            strangeSymbolsCheckBox.Name = "strangeSymbolsCheckBox";
            strangeSymbolsCheckBox.Size = new Size(107, 19);
            strangeSymbolsCheckBox.TabIndex = 5;
            strangeSymbolsCheckBox.Text = "{}[]()/\\'\"`~,;:.<>";
            strangeSymbolsCheckBox.UseVisualStyleBackColor = true;
            strangeSymbolsCheckBox.CheckedChanged += strangeSymbolsCheckBox_CheckedChanged;
            // 
            // similarElementsCheckBox
            // 
            similarElementsCheckBox.AutoSize = true;
            similarElementsCheckBox.Location = new Point(7, 93);
            similarElementsCheckBox.Name = "similarElementsCheckBox";
            similarElementsCheckBox.Size = new Size(69, 19);
            similarElementsCheckBox.TabIndex = 6;
            similarElementsCheckBox.Text = "il|1Lo0O";
            similarElementsCheckBox.UseVisualStyleBackColor = true;
            similarElementsCheckBox.CheckedChanged += similarElementsCheckBox_CheckedChanged;
            // 
            // lengthLabel
            // 
            lengthLabel.AutoSize = true;
            lengthLabel.Location = new Point(7, 121);
            lengthLabel.Name = "lengthLabel";
            lengthLabel.Size = new Size(45, 15);
            lengthLabel.TabIndex = 8;
            lengthLabel.Text = "Длина:";
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(9, 144);
            passwordTextBox.MaxLength = 128;
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(246, 23);
            passwordTextBox.TabIndex = 9;
            // 
            // useLabel
            // 
            useLabel.AutoSize = true;
            useLabel.Location = new Point(7, 9);
            useLabel.Name = "useLabel";
            useLabel.Size = new Size(87, 15);
            useLabel.TabIndex = 10;
            useLabel.Text = "Использовать:";
            // 
            // excludeLabel
            // 
            excludeLabel.AutoSize = true;
            excludeLabel.Location = new Point(7, 75);
            excludeLabel.Name = "excludeLabel";
            excludeLabel.Size = new Size(73, 15);
            excludeLabel.TabIndex = 11;
            excludeLabel.Text = "Исключить:";
            // 
            // guaranteeCheckBox
            // 
            guaranteeCheckBox.AccessibleDescription = "";
            guaranteeCheckBox.AutoSize = true;
            guaranteeCheckBox.Location = new Point(82, 52);
            guaranteeCheckBox.Name = "guaranteeCheckBox";
            guaranteeCheckBox.Size = new Size(136, 19);
            guaranteeCheckBox.TabIndex = 12;
            guaranteeCheckBox.Text = "Гарантия 1 символа";
            toolTips.SetToolTip(guaranteeCheckBox, "Гарантия что как минимум 1 элемент из каждой выбранной категории будет присутствовать в пароле.");
            guaranteeCheckBox.UseVisualStyleBackColor = true;
            guaranteeCheckBox.CheckedChanged += guaranteeCheckBox_CheckedChanged;
            // 
            // copyButton
            // 
            copyButton.Location = new Point(163, 176);
            copyButton.Name = "copyButton";
            copyButton.Size = new Size(90, 23);
            copyButton.TabIndex = 13;
            copyButton.Text = "Копировать";
            copyButton.UseVisualStyleBackColor = true;
            copyButton.Click += copyButton_Click;
            // 
            // passwordStrengthLabel
            // 
            passwordStrengthLabel.AutoSize = true;
            passwordStrengthLabel.Location = new Point(9, 205);
            passwordStrengthLabel.Name = "passwordStrengthLabel";
            passwordStrengthLabel.Size = new Size(89, 15);
            passwordStrengthLabel.TabIndex = 14;
            passwordStrengthLabel.Text = "Сила пароля: -";
            // 
            // passwordStrengthBar
            // 
            passwordStrengthBar.Location = new Point(9, 223);
            passwordStrengthBar.Name = "passwordStrengthBar";
            passwordStrengthBar.ProgressColor = Color.Green;
            passwordStrengthBar.Size = new Size(246, 10);
            passwordStrengthBar.TabIndex = 15;
            // 
            // autoCopyCheckBox
            // 
            autoCopyCheckBox.AutoSize = true;
            autoCopyCheckBox.Location = new Point(157, 119);
            autoCopyCheckBox.Name = "autoCopyCheckBox";
            autoCopyCheckBox.Size = new Size(85, 19);
            autoCopyCheckBox.TabIndex = 16;
            autoCopyCheckBox.Text = "Автокопия";
            autoCopyCheckBox.UseVisualStyleBackColor = true;
            autoCopyCheckBox.CheckedChanged += autoCopyCheckBox_CheckedChanged;
            toolTips.SetToolTip(autoCopyCheckBox, "Автоматически копировать сгенерированный пароль в буфер обмена.");
            // 
            // passwordLengthUpDown
            // 
            passwordLengthUpDown.Location = new Point(58, 118);
            passwordLengthUpDown.Maximum = new decimal(new int[] { 128, 0, 0, 0 });
            passwordLengthUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            passwordLengthUpDown.Name = "passwordLengthUpDown";
            passwordLengthUpDown.Size = new Size(93, 23);
            passwordLengthUpDown.TabIndex = 17;
            passwordLengthUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            toolTips.SetToolTip(passwordLengthUpDown, "Диапазон длины пароля 1-128.");
            // 
            // toolTips
            // 
            // 
            // PasswordGeneratorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(265, 241);
            Controls.Add(passwordLengthUpDown);
            Controls.Add(autoCopyCheckBox);
            Controls.Add(passwordStrengthBar);
            Controls.Add(passwordStrengthLabel);
            Controls.Add(copyButton);
            Controls.Add(guaranteeCheckBox);
            Controls.Add(excludeLabel);
            Controls.Add(useLabel);
            Controls.Add(passwordTextBox);
            Controls.Add(lengthLabel);
            Controls.Add(similarElementsCheckBox);
            Controls.Add(strangeSymbolsCheckBox);
            Controls.Add(lowercaseCheckBox);
            Controls.Add(uppercaseCheckBox);
            Controls.Add(numbersCheckBox);
            Controls.Add(symbolsCheckBox);
            Controls.Add(generateButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "PasswordGeneratorForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Password Generator";
            ((System.ComponentModel.ISupportInitialize)passwordLengthUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button generateButton;
        private CheckBox symbolsCheckBox;
        private CheckBox numbersCheckBox;
        private CheckBox uppercaseCheckBox;
        private CheckBox lowercaseCheckBox;
        private CheckBox strangeSymbolsCheckBox;
        private CheckBox similarElementsCheckBox;
        private Label lengthLabel;
        private TextBox passwordTextBox;
        private Label useLabel;
        private Label excludeLabel;
        private CheckBox guaranteeCheckBox;
        private Button copyButton;
        private Label passwordStrengthLabel;
        private ColoredProgressBar passwordStrengthBar;
        private CheckBox autoCopyCheckBox;
        private NumericUpDown passwordLengthUpDown;
        private ToolTip toolTips;
    }
}

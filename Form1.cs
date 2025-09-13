using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using System.Drawing;

namespace PasswordGenerator
{
    public partial class PasswordGeneratorForm : Form
    {
        readonly char[] numbersChar = "0123456789".ToCharArray();
        readonly char[] lowercaseChar = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        readonly char[] uppercaseChar = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        readonly char[] symbolsChar = "!\"#$%&'()*+,-./:;<=>?@[]\\^_`{|}~".ToCharArray();

        readonly char[] similarElementsChar = "01IOilo|".ToCharArray();
        readonly char[] strangeSymbolsChar = "{}[]()/\\'\"`~,;:.<>".ToCharArray();

        bool useNumbers = false, useLowercase = false, useUppercase = false, useSymbols = false, excludeSimilarElements = false, excludeStrangeSymbols = false, guarantee = false, autoCopy = false;

        readonly string _settingsFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "PasswordGenerator", "settings.json");
        bool _isLoading = false;

        public PasswordGeneratorForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            var password = new StringBuilder();

            if (!(useSymbols || useNumbers || useUppercase || useLowercase))
            {
                MessageBox.Show("Выберите хотя бы одну группу символов.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<char> passwordElementsChars = new List<char>();

            if (useNumbers) passwordElementsChars.AddRange(numbersChar);
            if (useLowercase) passwordElementsChars.AddRange(lowercaseChar);
            if (useUppercase) passwordElementsChars.AddRange(uppercaseChar);
            if (useSymbols) passwordElementsChars.AddRange(symbolsChar);

            if (excludeSimilarElements) passwordElementsChars = passwordElementsChars.Where(x => !similarElementsChar.Contains(x)).ToList();
            if (excludeStrangeSymbols) passwordElementsChars = passwordElementsChars.Where(x => !strangeSymbolsChar.Contains(x)).ToList();

            if (guarantee)
            {
                List<char> guaranteedChars = new List<char>();
                List<char> passwordWithGuaranteedChars = new List<char>();
                char PickRandom(IEnumerable<char> source)
                {
                    var list = source.Where(c => (!excludeSimilarElements || !similarElementsChar.Contains(c)) && (!excludeStrangeSymbols || !strangeSymbolsChar.Contains(c))).ToList();
                    return list[RandomNumberGenerator.GetInt32(0, list.Count)];
                }
                if (useNumbers) guaranteedChars.Add(PickRandom(numbersChar));
                if (useLowercase) guaranteedChars.Add(PickRandom(lowercaseChar));
                if (useUppercase) guaranteedChars.Add(PickRandom(uppercaseChar));
                if (useSymbols) guaranteedChars.Add(PickRandom(symbolsChar));
                Shuffle(guaranteedChars);
                for (int i = 0; i < passwordLengthUpDown.Value; i++)
                    if (i < guaranteedChars.Count)
                        passwordWithGuaranteedChars.Add(guaranteedChars[i]);
                    else
                        passwordWithGuaranteedChars.Add(passwordElementsChars[RandomNumberGenerator.GetInt32(0, passwordElementsChars.Count)]);
                Shuffle(passwordWithGuaranteedChars);
                password.Append(string.Join("", passwordWithGuaranteedChars));
            }

            for (int i = 0; i < passwordLengthUpDown.Value - password.Length;)
                password.Append(passwordElementsChars[RandomNumberGenerator.GetInt32(0, passwordElementsChars.Count)]);

            passwordTextBox.Text = password.ToString();
            password = null;
            try { if (autoCopy) Clipboard.SetText(passwordTextBox.Text); } catch { }
            PasswordStrengthAnalyzer(passwordTextBox.Text);
        }

        private void numbersCheckBox_CheckedChanged(object sender, EventArgs e) { useNumbers = numbersCheckBox.Checked; if (!_isLoading) SaveData(); }
        private void lowercaseCheckBox_CheckedChanged(object sender, EventArgs e) { useLowercase = lowercaseCheckBox.Checked; if (!_isLoading) SaveData(); }
        private void uppercaseCheckBox_CheckedChanged(object sender, EventArgs e) { useUppercase = uppercaseCheckBox.Checked; if (!_isLoading) SaveData(); }
        private void symbolsCheckBox_CheckedChanged(object sender, EventArgs e) { useSymbols = symbolsCheckBox.Checked; if (!_isLoading) SaveData(); }
        private void guaranteeCheckBox_CheckedChanged(object sender, EventArgs e) { guarantee = guaranteeCheckBox.Checked; if (!_isLoading) SaveData(); }
        private void similarElementsCheckBox_CheckedChanged(object sender, EventArgs e) { excludeSimilarElements = similarElementsCheckBox.Checked; if (!_isLoading) SaveData(); }
        private void strangeSymbolsCheckBox_CheckedChanged(object sender, EventArgs e) { excludeStrangeSymbols = strangeSymbolsCheckBox.Checked; if (!_isLoading) SaveData(); }
        private void autoCopyCheckBox_CheckedChanged(object sender, EventArgs e) { autoCopy = autoCopyCheckBox.Checked; if (!_isLoading) SaveData(); }

        private void passwordLengthUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (_isLoading) return;
            SaveData();
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            try { Clipboard.SetText(passwordTextBox.Text); } catch { }
        }
        private static void Shuffle<T>(IList<T> list)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = RandomNumberGenerator.GetInt32(0, i + 1);
                (list[i], list[j]) = (list[j], list[i]);
            }
        }
        private void PasswordStrengthAnalyzer(string password)
        {
            bool hasLower = password.Any(x => lowercaseChar.Contains(x));
            bool hasUpper = password.Any(x => uppercaseChar.Contains(x));
            bool hasDigit = password.Any(x => numbersChar.Contains(x));
            bool hasSymbol = password.Any(x => symbolsChar.Contains(x));

            int charsetSize = 0;
            if (hasLower) charsetSize += lowercaseChar.Length;
            if (hasUpper) charsetSize += uppercaseChar.Length;
            if (hasDigit) charsetSize += numbersChar.Length;
            if (hasSymbol) charsetSize += symbolsChar.Length;

            double entropy = password.Length * Math.Log(charsetSize, 2);

            int uniqueChars = password.Distinct().Count();
            double repeatRatio = 1.0 - (uniqueChars / (double)password.Length);
            entropy -= repeatRatio * 12.0;

            int seqCount = 0;
            for (int i = 0; i < password.Length - 2; i++)
            {
                int asc = 1;
                for (int j = i; j < password.Length - 1; j++)
                {
                    if (password[j + 1] == password[j] + 1) asc++; else break;
                }
                if (asc >= 3) { seqCount++; i += asc - 1; continue; }

                int desc = 1;
                for (int j = i; j < password.Length - 1; j++)
                {
                    if (password[j + 1] == password[j] - 1) desc++; else break;
                }
                if (desc >= 3) { seqCount++; i += desc - 1; }
            }
            entropy -= seqCount * 3.2;

            if (entropy < 0) entropy = 0;

            const double maxEntropy = 80.0;
            int percent = (int)Math.Round(Math.Min(100.0, (entropy / maxEntropy) * 100.0));
            if (percent < 0) percent = 0;

            string category =
                percent < 5 ? "Ничто" :
                percent < 10 ? "Невероятно слабый" :
                percent < 15 ? "Очень слабый" :
                percent < 25 ? "Слабый" :
                percent < 35 ? "Умеренный" :
                percent < 45 ? "Средний" :
                percent < 55 ? "Достойный" :
                percent < 65 ? "Хороший" :
                percent < 75 ? "Очень хороший" :
                percent < 99 ? "Отличный" : "Невозможный";
            passwordStrengthBar.ProgressColor =
                percent < 5 ? ColorTranslator.FromHtml("#c7dcd0") :
                percent < 10 ? ColorTranslator.FromHtml("#ae2334") :
                percent < 15 ? ColorTranslator.FromHtml("#e83b3b") :
                percent < 25 ? ColorTranslator.FromHtml("#ea4f36") :
                percent < 35 ? ColorTranslator.FromHtml("#f57d4a") :
                percent < 45 ? ColorTranslator.FromHtml("#f79617") :
                percent < 55 ? ColorTranslator.FromHtml("#f9c22b") :
                percent < 65 ? ColorTranslator.FromHtml("#cddf6c") :
                percent < 75 ? ColorTranslator.FromHtml("#91db69") :
                percent < 99 ? ColorTranslator.FromHtml("#1ebc73") : ColorTranslator.FromHtml("#831c5d");
            passwordStrengthLabel.Text = $"Сила пароля: {category}";
            try
            {
                passwordStrengthBar.Value = percent;
            }
            catch
            {
                passwordStrengthBar.Value = Math.Max(0, Math.Min(100, percent));
            }
        }

        private void SaveData()
        {
            try
            {
                var prefs = new Preferences
                {
                    UseNumbers = useNumbers,
                    UseLowercase = useLowercase,
                    UseUppercase = useUppercase,
                    UseSymbols = useSymbols,
                    ExcludeSimilarElements = excludeSimilarElements,
                    ExcludeStrangeSymbols = excludeStrangeSymbols,
                    Guarantee = guarantee,
                    AutoCopy = autoCopy,
                    Length = (int)passwordLengthUpDown.Value
                };

                var dir = Path.GetDirectoryName(_settingsFile);
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

                var json = JsonSerializer.Serialize(prefs, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_settingsFile, json);
            }
            catch
            {
            }
        }

        private void LoadData()
        {
            _isLoading = true;
            try
            {
                if (File.Exists(_settingsFile))
                {
                    var json = File.ReadAllText(_settingsFile);
                    var prefs = JsonSerializer.Deserialize<Preferences>(json);
                    if (prefs != null)
                    {
                        numbersCheckBox.Checked = prefs.UseNumbers;
                        lowercaseCheckBox.Checked = prefs.UseLowercase;
                        uppercaseCheckBox.Checked = prefs.UseUppercase;
                        symbolsCheckBox.Checked = prefs.UseSymbols;
                        similarElementsCheckBox.Checked = prefs.ExcludeSimilarElements;
                        strangeSymbolsCheckBox.Checked = prefs.ExcludeStrangeSymbols;
                        guaranteeCheckBox.Checked = prefs.Guarantee;
                        autoCopyCheckBox.Checked = prefs.AutoCopy;

                        if (prefs.Length >= passwordLengthUpDown.Minimum && prefs.Length <= passwordLengthUpDown.Maximum)
                            passwordLengthUpDown.Value = prefs.Length;
                    }
                }
            }
            catch
            {
            }
            finally
            {
                try
                {
                    passwordLengthUpDown.ValueChanged -= passwordLengthUpDown_ValueChanged;
                }
                catch { }
                passwordLengthUpDown.ValueChanged += passwordLengthUpDown_ValueChanged;

                _isLoading = false;
            }
        }
    }

    internal class Preferences
    {
        public bool UseNumbers { get; set; }
        public bool UseLowercase { get; set; }
        public bool UseUppercase { get; set; }
        public bool UseSymbols { get; set; }
        public bool ExcludeSimilarElements { get; set; }
        public bool ExcludeStrangeSymbols { get; set; }
        public bool Guarantee { get; set; }
        public bool AutoCopy { get; set; }
        public int Length { get; set; }
    }

    public class ColoredProgressBar : ProgressBar
    {
        private Color _progressColor = Color.Green;
        public Color ProgressColor
        {
            get => _progressColor;
            set { _progressColor = value; Invalidate(); }
        }

        public ColoredProgressBar()
        {
            SetStyle(ControlStyles.UserPaint, true);
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (ProgressBarRenderer.IsSupported)
            {
                ProgressBarRenderer.DrawHorizontalBar(e.Graphics, ClientRectangle);
                Rectangle clip = ClientRectangle;

                int width = (int)(clip.Width * ((double)(Value - Minimum) / (Maximum - Minimum)));
                if (width == 0) return;

                Rectangle fillRect = new Rectangle(clip.X + 2, clip.Y + 2, width - 4, clip.Height - 4);

                using (SolidBrush brush = new SolidBrush(ProgressColor))
                {
                    e.Graphics.FillRectangle(brush, fillRect);
                }
            }
            else
            {
                base.OnPaint(e);
            }
        }
    }
}
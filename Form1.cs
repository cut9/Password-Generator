using System.Configuration;

namespace PasswordGenerator
{
    public partial class Form1 : Form
    {
        string password;
        int passLength;
        bool simvols, numbers, bigReg, smallReg, clons, strangeSimvols;
        public Form1()
        {
            InitializeComponent();
            LoadData();
        }
        private void passwordLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }
        private void passwordLength_Changed(object sender, EventArgs e)
        {
            if (passwordLength.Text != "")
            {
                passLength = Convert.ToInt32(passwordLength.Text);
                SaveData();
            }
        }
        private void simvolsCheak_CheckedChanged(object sender, EventArgs e)
        {
            simvols = (simvolsCheak.Checked);
            SaveData();
        }
        private void numbersCheak_CheckedChanged(object sender, EventArgs e)
        {
            numbers = (numbersCheak.Checked);
            SaveData();
        }
        private void bigRegCheak_CheckedChanged(object sender, EventArgs e)
        {
            bigReg = (bigRegCheak.Checked);
            SaveData();
        }
        private void smallRegCheak_CheckedChanged(object sender, EventArgs e)
        {
            smallReg = (smallRegCheak.Checked);
            SaveData();
        }
        private void clonsCheak_CheckedChanged(object sender, EventArgs e)
        {
            clons = (clonsCheak.Checked);
            SaveData();
        }
        private void strangeSimvolsCheak_CheckedChanged(object sender, EventArgs e)
        {
            strangeSimvols = (strangeSimvolsCheak.Checked);
            SaveData();
        }
        private void generateButton_Click(object sender, EventArgs e)
        {
            if ((simvols || numbers || bigReg || smallReg) && passLength > 0)
            {
                Random random = new Random();
                char element;
                password = null;
                char[] sim = "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~".ToCharArray();
                char[] num = "0123456789".ToCharArray();
                char[] Dwreg = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
                char[] Upreg = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
                List<char> allChars = new List<char>();
                if (simvols)
                    allChars.AddRange(sim);
                if (numbers)
                    allChars.AddRange(num);
                if (bigReg)
                    allChars.AddRange(Upreg);
                if (smallReg)
                    allChars.AddRange(Dwreg);
                if (strangeSimvols)
                    allChars.RemoveAll(c => c == '"' || c == '\'' || c == '(' || c == ')' || c == ',' || c == '.'
                    || c == '/' || c == ':' || c == ';' || c == '<' || c == '>' || c == '[' || c == '\\' || c == ']'
                    || c == '`' || c == '{' || c == '}' || c == '~');
                if (clons)
                    allChars.RemoveAll(c => c == '0' || c == '1' || c == 'I' || c == 'O' || c == 'i' || c == 'l'
                    || c == 'o' || c == '|');
                for (int i = 0; i < passLength; i++)
                {
                    element = allChars[random.Next(0, allChars.Count)];
                    password += element;
                }
                passwordSpace.Text = password;
                Clipboard.SetText(password);
            }
        }
        void SaveData()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove("length");
            config.AppSettings.Settings.Remove("simvols");
            config.AppSettings.Settings.Remove("numbers");
            config.AppSettings.Settings.Remove("bigReg");
            config.AppSettings.Settings.Remove("smallReg");
            config.AppSettings.Settings.Remove("clons");
            config.AppSettings.Settings.Remove("strangeSimvols");

            config.AppSettings.Settings.Add("length", passLength.ToString());
            config.AppSettings.Settings.Add("simvols", simvols.ToString());
            config.AppSettings.Settings.Add("numbers", numbers.ToString());
            config.AppSettings.Settings.Add("bigReg", bigReg.ToString());
            config.AppSettings.Settings.Add("smallReg", smallReg.ToString());
            config.AppSettings.Settings.Add("clons", clons.ToString());
            config.AppSettings.Settings.Add("strangeSimvols", strangeSimvols.ToString());
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
        void LoadData()
        {
            passLength = int.Parse(ConfigurationManager.AppSettings["length"] ?? "8");
            simvols = bool.Parse(ConfigurationManager.AppSettings["simvols"] ?? "false");
            numbers = bool.Parse(ConfigurationManager.AppSettings["numbers"] ?? "false");
            bigReg = bool.Parse(ConfigurationManager.AppSettings["bigReg"] ?? "false");
            smallReg = bool.Parse(ConfigurationManager.AppSettings["smallReg"] ?? "false");
            clons = bool.Parse(ConfigurationManager.AppSettings["clons"] ?? "false");
            strangeSimvols = bool.Parse(ConfigurationManager.AppSettings["strangeSimvols"] ?? "false");

            passwordLength.Text = passLength.ToString();
            simvolsCheak.Checked = simvols;
            numbersCheak.Checked = numbers;
            bigRegCheak.Checked = bigReg;
            smallRegCheak.Checked = smallReg;
            clonsCheak.Checked = clons;
            strangeSimvolsCheak.Checked = strangeSimvols;
        }
    }
}
using PlayerTransfers.Controller;
using PlayerTransfers.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerTransfers
{
    public partial class LoginForm : Form
    {
        static Dictionary<string, string> Styles = new Dictionary<string, string>();
        public static string selectedStyle = "style1";
        public static string role;
        public LoginForm()
        {
            ReadAllStyles();
            Console.WriteLine(this.Size);
            InitializeComponent();
            Console.WriteLine(this.Size);
            //this.Size = new Size(659, 435);
        }

        private void label4_MouseHover(object sender, EventArgs e)
        {
            label4.ForeColor = System.Drawing.Color.SaddleBrown;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = System.Drawing.Color.Black;
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture =
             System.Globalization.CultureInfo.GetCultureInfo("en");

            System.Threading.Thread.CurrentThread.CurrentUICulture =
                System.Globalization.CultureInfo.GetCultureInfo("en");
            this.Controls.Clear();
            this.InitializeComponent();
            Console.WriteLine(this.Size);
            if (selectedStyle.Equals("style1"))
            {
                style1ToolStripMenuItem_Click(sender, e);
            }
            else if (selectedStyle.Equals("style2"))
            {
                style2ToolStripMenuItem_Click(sender, e);
            }
            else
                style3ToolStripMenuItem_Click(sender, e);
        }

        private void serbianToolStripMenuItem_Click(object sender, EventArgs e)
        {

            System.Threading.Thread.CurrentThread.CurrentCulture =
             System.Globalization.CultureInfo.GetCultureInfo("sr-Latn-RS");

            System.Threading.Thread.CurrentThread.CurrentUICulture =
                System.Globalization.CultureInfo.GetCultureInfo("sr-Latn-RS");
            this.Controls.Clear();
            this.InitializeComponent();
            Console.WriteLine(this.Size);
            if (selectedStyle.Equals("style1"))
            {
                style1ToolStripMenuItem_Click(sender, e);
            }
            else if (selectedStyle.Equals("style2"))
            {
                style2ToolStripMenuItem_Click(sender, e);
            }
            else
                style3ToolStripMenuItem_Click(sender, e);
        }


        public void ReadAllStyles()
        {
            var line = "";
            using (var reader = new StreamReader(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Style\\Styles.txt", Encoding.UTF8))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    var split = line.Split('#');
                    Styles.Add(split[0], split[1] + "#" + split[2]);
                }
            }
        }

        public static List<Control> GetAllControls(Control container, List<Control> list)
        {
            foreach (Control c in container.Controls)
            {

                if (c.Controls.Count > 0)
                    list = GetAllControls(c, list);
                else
                    list.Add(c);
            }
            return list;
        }
        public static List<Control> GetAllControls2(Control container)
        {
            return GetAllControls(container, new List<Control>());
        }

        private void style1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.DarkGray;
            style1Changer(this);
            //this.Size = Size.Width;
            selectedStyle = "";
            selectedStyle = "style1";
        }

        public static void style1Changer(Control control)
        {
            List<Control> allControls = GetAllControls2(control);
            var style = Styles.ElementAt(0).Value;
            var split = style.Split('#');
            allControls.ForEach(k => k.Font = new System.Drawing.Font(split[0], 11, FontStyle.Italic));
        }

        private void style2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            style2Changer(this);
            this.BackColor = Color.Khaki;
            selectedStyle = "";
            selectedStyle = "style2";
        }

        public static void style2Changer(Control control)
        {
            List<Control> allControls = GetAllControls2(control);
            var style = Styles.ElementAt(1).Value;
            var split = style.Split('#');
            allControls.ForEach(k => k.Font = new System.Drawing.Font(split[0], 11, FontStyle.Regular));
        }
        private void style3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            style3Changer(this);
            this.BackColor = Color.SkyBlue;
            selectedStyle = "";
            selectedStyle = "style3";
        }

        public static void style3Changer(Control control)
        {
            List<Control> allControls = GetAllControls2(control);
            var style = Styles.ElementAt(2).Value;
            var split = style.Split('#');
            allControls.ForEach(k => k.Font = new System.Drawing.Font(split[0], 11, FontStyle.Bold));
        }

        private void label4_Click(object sender, EventArgs e)
        {
            new RegisterForm().Show();
        }

        public static void MessageBoxOK(string title, string message)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void MessageBoxError(string title, string message)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static string ComputeSha256Hash(string data)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(data));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            while (true)
            {
                if (textBox1.Text.Length == 0)
                {
                    var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                    if (language.Equals("srp"))
                    {
                        MessageBoxError("Greška", "Polje sa korisničkim imenom mora biti uneseno!");
                    }
                    else
                        MessageBoxError("Error", "Field with username must be entered!");
                    break;
                }
                if (textBox2.Text.Length == 0)
                {
                    var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                    if (language.Equals("srp"))
                    {
                        MessageBoxError("Greška", "Polje sa prezimenom mora biti uneseno!");
                    }
                    else
                        MessageBoxError("Error", "Field with surname must be entered!");
                    break;
                }
                var allUsers = new UserController().AllUsers();
                var user = allUsers.Where(u => u.Username.Equals(textBox1.Text)).FirstOrDefault();
                if (user == null)
                {
                    var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                    if (language.Equals("srp"))
                    {
                        MessageBoxError("Greška", "Ne postoji korisnik sa unesenim korisničkim imenom!");
                    }
                    else
                        MessageBoxError("Error", "There is no user with the entered username!");
                    break;
                }
                var labelMessage = "";
                var password = ComputeSha256Hash(textBox2.Text);
                if (!password.Equals(user.Password))
                {
                    var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                    if (language.Equals("srp"))
                    {
                        MessageBoxError("Greška", "Unesena lozinka je pogrešna!");
                    }
                    else
                        MessageBoxError("Error", "Entered password is incorrect!");
                    break;
                }
                else
                {
                    var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                    if (language.Equals("srp"))
                    {
                        labelMessage = "Ulogovan je " + user.Username + "(" + user.Role + ")";
                    }
                    else
                        labelMessage = "Logged in " + user.Username + "(" + user.Role + ")";
                    role = user.Role;
                    //LoginForm.ActiveForm.Close();
                    this.Hide();
                    new MenuForm(labelMessage).ShowDialog();
                    //sistema.ShowDialog();
                    this.Close();

                }
                break;
            }

        }
    }
}

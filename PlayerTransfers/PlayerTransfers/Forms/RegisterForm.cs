using PlayerTransfers.Controller;
using PlayerTransfers.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerTransfers.Forms
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            if (LoginForm.selectedStyle.Equals("style1"))
            {
                LoginForm.style1Changer(this);
                this.BackColor = Color.DarkGray;
            }
            else if (LoginForm.selectedStyle.Equals("style2"))
            {
                LoginForm.style2Changer(this);
                this.BackColor = Color.Khaki;
            }
            else
            {
                this.BackColor = Color.SkyBlue;
                LoginForm.style3Changer(this);
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
                        LoginForm.MessageBoxError("Greška", "Polje sa imenom mora biti uneseno!");
                    }
                    else
                        LoginForm.MessageBoxError("Error", "Field with name must be entered!");
                    break;
                }
                else
                    textBox1_TextChanged(sender, e);

                if (textBox2.Text.Length == 0)
                {
                    var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                    if (language.Equals("srp"))
                    {
                        LoginForm.MessageBoxError("Greška", "Polje sa prezimenom mora biti uneseno!");
                    }
                    else
                        LoginForm.MessageBoxError("Error", "Field with surname must be entered!");
                    break;
                }
                else
                    textBox2_TextChanged(sender, e);

                if (textBox3.Text.Length == 0)
                {
                    var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                    if (language.Equals("srp"))
                    {
                        LoginForm.MessageBoxError("Greška", "Polje sa korisnickim imenom mora biti uneseno!");
                    }
                    else
                        LoginForm.MessageBoxError("Error", "Field with username must be entered!");
                    break;
                }
                if (textBox4.Text.Length == 0)
                {
                    var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                    if (language.Equals("srp"))
                    {
                        LoginForm.MessageBoxError("Greška", "Polje sa lozinkom mora biti uneseno!");
                    }
                    else
                        LoginForm.MessageBoxError("Error", "Field with password must be entered!");
                    break;
                }

                var password = LoginForm.ComputeSha256Hash(textBox4.Text);
                Console.WriteLine(password);

                var user = new User()
                {
                    ID = 0,
                    Name = textBox1.Text,
                    Surname = textBox2.Text,
                    Username = textBox3.Text,
                    Password = password,
                    Role = comboBox1.Text
                };
                if (new UserController().AddUser(user))
                {
                    var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                    if (language.Equals("srp"))
                    {
                        LoginForm.MessageBoxOK("Registracija", "Uspješno ste se registrovali!");
                    }
                    else
                        LoginForm.MessageBoxOK("Registration", "Your registration is successfull!");
                }
                else
                {
                    var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                    if (language.Equals("srp"))
                    {
                        LoginForm.MessageBoxError("Registracija", "Bezuspješna registracija. Pokušajte ponovo!");
                    }
                    else
                        LoginForm.MessageBoxError("Registration", "Unsuccessfull registration. Try again!");
                }
                this.Close();
                break;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "^[a-zA-Z ]*$"))
            {
                var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                if (language.Equals("srp"))
                {
                    LoginForm.MessageBoxError("Greška", "Za ime je moguće unijeti samo slova!");
                }
                else
                    LoginForm.MessageBoxError("Error", "Only letters can be entered for the name!");
                textBox1.Text = String.Empty;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "^[a-zA-Z ]*$"))
            {
                var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                if (language.Equals("srp"))
                {
                    LoginForm.MessageBoxError("Greška", "Za prezime je moguće unijeti samo slova!");
                }
                else
                    LoginForm.MessageBoxError("Error", "Only letters can be entered for the surname!");
                textBox2.Text = String.Empty;

            }
        }
    }
}

using PlayerTransfers.Controller;
using PlayerTransfers.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerTransfers.Forms
{
    partial class ClubForm : Form
    { 
        public Club Club { get; set; }
        public ClubForm()
        {
            InitializeComponent();
        }

        public ClubForm(Club club)
        {
            InitializeComponent();
            textBox1.Text = club.ClubName;
            textBox2.Text = club.League;
            dateTimePicker1.Value = club.FoundationDate;
            textBox3.Text = club.Address;
            textBox4.Text = club.Phone;
            textBox5.Text = club.Stadium;

            var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
            if (language.Equals("srp"))
            {
                button1.Text = "Ažuriraj";
            }
            else
                button1.Text = "Change";

            Club = club;
        }

        private void ClubForm_Load(object sender, EventArgs e)
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
                        LoginForm.MessageBoxError("Greška", "Polje sa imenom kluba mora biti uneseno!");
                    }
                    else
                        LoginForm.MessageBoxError("Error", "Field with club name must be entered!");
                    break;
                }
                else
                    textBox1_TextChanged(sender, e);

                if (textBox2.Text.Length == 0)
                {
                    var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                    if (language.Equals("srp"))
                    {
                        LoginForm.MessageBoxError("Greška", "Polje sa ligom mora biti uneseno!");
                    }
                    else
                        LoginForm.MessageBoxError("Error", "Field with league must be entered!");
                    break;
                }
                else
                    textBox2_TextChanged(sender, e);

                if (textBox3.Text.Length == 0)
                {
                    var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                    if (language.Equals("srp"))
                    {
                        LoginForm.MessageBoxError("Greška", "Polje sa adresom mora biti uneseno!");
                    }
                    else
                        LoginForm.MessageBoxError("Error", "Field with address must be entered!");
                    break;
                }
                else
                    textBox3_TextChanged(sender, e);

                if (textBox4.Text.Length == 0)
                {
                    var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                    if (language.Equals("srp"))
                    {
                        LoginForm.MessageBoxError("Greška", "Polje sa telefonom mora biti uneseno!");
                    }
                    else
                        LoginForm.MessageBoxError("Error", "Field with phone must be entered!");
                    break;
                }
                /*else
                    textBox4_TextChanged(sender, e);*/

                if (textBox5.Text.Length == 0)
                {
                    var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                    if (language.Equals("srp"))
                    {
                        LoginForm.MessageBoxError("Greška", "Polje sa stadionom mora biti uneseno!");
                    }
                    else
                        LoginForm.MessageBoxError("Error", "Field with stadium must be entered!");
                    break;
                }
                else
                    textBox5_TextChanged(sender, e);

                if (button1.Text.Equals("Create") || button1.Text.Equals("Kreiraj"))
                {
                    Club = new Club()
                    {
                        ClubName = textBox1.Text,
                        League = textBox2.Text,
                        FoundationDate = dateTimePicker1.Value,
                        Address = textBox3.Text,
                        Phone = textBox4.Text,
                        Stadium = textBox5.Text,
                    };
                    if (new ClubController().AddClub(Club))
                    {
                        var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                        if (language.Equals("srp"))
                        {
                            LoginForm.MessageBoxOK("Kreiranje", "Uspješno ste se kreirali klkub!");
                        }
                        else
                            LoginForm.MessageBoxOK("Creation", "Your club creation is successfull!");
                    }
                    else
                    {
                        var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                        if (language.Equals("srp"))
                        {
                            LoginForm.MessageBoxError("Kreiranje", "Bezuspješno kreiranje. Pokušajte ponovo!");
                        }
                        else
                            LoginForm.MessageBoxError("Creation", "Unsuccessfull creations. Try again!");
                    }
                }
                else
                {
                    Club.ClubName = textBox1.Text;
                    Club.League = textBox2.Text;
                    Club.FoundationDate = dateTimePicker1.Value;
                    Club.Address = textBox3.Text;
                    Club.Phone = textBox4.Text;
                    Club.Stadium = textBox5.Text;
                    if (new ClubController().UpdateClub(Club))
                    {
                        var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                        if (language.Equals("srp"))
                        {
                            LoginForm.MessageBoxOK("Ažuriranje", "Uspješno ste se ažurirali klub!");
                        }
                        else
                            LoginForm.MessageBoxOK("Changing", "Your club changing is successfull!");
                    }
                    else
                    {
                        var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                        if (language.Equals("srp"))
                        {
                            LoginForm.MessageBoxError("Ažuriranje", "Bezuspješno ažuriranje. Pokušajte ponovo!");
                        }
                        else
                            LoginForm.MessageBoxError("Changing", "Unsuccessfull changing. Try again!");
                    }
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
                    LoginForm.MessageBoxError("Greška", "Za ime kluba je moguće unijeti samo slova!");
                }
                else
                    LoginForm.MessageBoxError("Error", "Only letters can be entered for the club name!");
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
                    LoginForm.MessageBoxError("Greška", "Za ligu je moguće unijeti samo slova!");
                }
                else
                    LoginForm.MessageBoxError("Error", "Only letters can be entered for the league!");
                textBox2.Text = String.Empty;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, "^[a-zA-Z ]*$"))
            {
                var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                if (language.Equals("srp"))
                {
                    LoginForm.MessageBoxError("Greška", "Za adresu je moguće unijeti samo slova!");
                }
                else
                    LoginForm.MessageBoxError("Error", "Only letters can be entered for the address!");
                textBox3.Text = String.Empty;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox5.Text, "^[a-zA-Z ]*$"))
            {
                var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                if (language.Equals("srp"))
                {
                    LoginForm.MessageBoxError("Greška", "Za stadion je moguće unijeti samo slova!");
                }
                else
                    LoginForm.MessageBoxError("Error", "Only letters can be entered for the stadium!");
                textBox5.Text = String.Empty;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '-' && textBox4.Text.Contains("-"))
            {
                // Stop more than one dot Char
                e.Handled = true;
            }
            else if (e.KeyChar == '-' && textBox4.Text.Length == 0)
            {
                // Stop first char as a dot input
                e.Handled = true;
            }
            else if (e.KeyChar == '/' && textBox4.Text.Contains("/"))
            {
                // Stop more than one dot Char
                e.Handled = true;
            }
            else if (e.KeyChar == '/' && textBox4.Text.Length == 0)
            {
                // Stop first char as a dot input
                e.Handled = true;
            }
            else if (e.KeyChar != '/' && textBox4.Text.Length == 3)
            {
                // Stop first char as a dot input
                e.Handled = true;
            }
            else if (e.KeyChar != '-' && textBox4.Text.Length == 7)
            {
                // Stop first char as a dot input
                e.Handled = true;
            }
            else if (char.IsDigit(e.KeyChar) && textBox4.Text.Length > 10)
            {
                // Stop first char as a dot input
                e.Handled = true;
            }
            else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '/' && e.KeyChar != '-')
            {
                // Stop allow other than digit and control
                var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                if (language.Equals("srp"))
                {
                    LoginForm.MessageBoxError("Greška", "Za telefon je moguće unijeti samo brojeve, / i - u formatu (xxx/xxx-xxx)!");
                }
                else
                {
                    LoginForm.MessageBoxError("Error", "Only numbers, / and - in format (xxx/xxx-xxx) can be entered for the price!");
                }
                e.Handled = true;
            }
        }
    }
}

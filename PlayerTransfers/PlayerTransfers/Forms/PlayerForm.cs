using PlayerTransfers.Controller;
using PlayerTransfers.Model;
using PlayerTransfers.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerTransfers.Forms
{

    partial class PlayerForm : Form
    {
        public Player Player { get; set; }
        public PlayerForm()
        {
            InitializeComponent();
        }

        public PlayerForm(Player player)
        {
            InitializeComponent();
            textBox1.Text = player.Name;
            textBox2.Text = player.Surname;
            textBox3.Text = player.PlaceOfBirth;
            textBox4.Text = player.Citizenship;
            textBox5.Text = player.Position;
            textBox6.Text = player.Height.ToString();
            textBox7.Text = player.Weight.ToString();
            textBox8.Text = player.Price.ToString();
            dateTimePicker1.Value = player.DateOfBirth;
            comboBox1.Text = player.Foot;

            var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
            if (language.Equals("srp"))
            {
                button1.Text = "Ažuriraj";
            }
            else
                button1.Text = "Change";
            Player = player;
        }

        private void CreatePlayer_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "Right";
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
                        LoginForm.MessageBoxError("Greška", "Polje sa mjestom rođenja  mora biti uneseno!");
                    }
                    else
                        LoginForm.MessageBoxError("Error", "Field with birthplace must be entered!");
                    break;
                }
                else
                    textBox3_TextChanged(sender, e);

                if (textBox4.Text.Length == 0)
                {
                    var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                    if (language.Equals("srp"))
                    {
                        LoginForm.MessageBoxError("Greška", "Polje sa državljanstvom mora biti uneseno!");
                    }
                    else
                        LoginForm.MessageBoxError("Error", "Field with citizenship must be entered!");
                    break;
                }
                else
                    textBox4_TextChanged(sender, e);

                if (textBox5.Text.Length == 0)
                {
                    var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                    if (language.Equals("srp"))
                    {
                        LoginForm.MessageBoxError("Greška", "Polje sa pozicijom mora biti uneseno!");
                    }
                    else
                        LoginForm.MessageBoxError("Error", "Field with position must be entered!");
                    break;
                }
                else
                    textBox5_TextChanged(sender, e);

                if (textBox6.Text.Length == 0)
                {
                    var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                    if (language.Equals("srp"))
                    {
                        LoginForm.MessageBoxError("Greška", "Polje sa visinom mora biti uneseno!");
                    }
                    else
                        LoginForm.MessageBoxError("Error", "Field with height must be entered!");
                    break;
                }
                else
                    textBox6_TextChanged(sender, e);

                if (textBox7.Text.Length == 0)
                {
                    var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                    if (language.Equals("srp"))
                    {
                        LoginForm.MessageBoxError("Greška", "Polje sa težinom mora biti uneseno!");
                    }
                    else
                        LoginForm.MessageBoxError("Error", "Field with weight must be entered!");
                    break;
                }
                else
                    textBox7_TextChanged(sender, e);

                if (textBox8.Text.Length == 0)
                {
                    var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                    if (language.Equals("srp"))
                    {
                        LoginForm.MessageBoxError("Greška", "Polje sa cijenom mora biti uneseno!");
                    }
                    else
                        LoginForm.MessageBoxError("Error", "Field with price must be entered!");
                    break;
                }
                /* else
                     textBox8_TextChanged(sender, e);
 */

                if (button1.Text.Equals("Create") || button1.Text.Equals("Kreiraj"))
                {
                    Player = new Player()
                    {
                        Name = textBox1.Text,
                        Surname = textBox2.Text,
                        DateOfBirth = dateTimePicker1.Value,
                        PlaceOfBirth = textBox3.Text,
                        Citizenship = textBox4.Text,
                        Position = textBox5.Text,
                        Height = Int32.Parse(textBox6.Text),
                        Weight = Int32.Parse(textBox7.Text),
                        Price = Double.Parse(textBox8.Text),
                        Foot = comboBox1.Text
                    };
                    if (new PlayerController().AddPlayer(Player))
                    {
                        var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                        if (language.Equals("srp"))
                        {
                            LoginForm.MessageBoxOK("Kreiranje", "Uspješno ste se kreirali igrača!");
                        }
                        else
                            LoginForm.MessageBoxOK("Creation", "Your player creation is successfull!");
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
                    Player.Name = textBox1.Text;
                    Player.Surname = textBox2.Text;
                    Player.DateOfBirth = dateTimePicker1.Value;
                    Player.PlaceOfBirth = textBox3.Text;
                    Player.Citizenship = textBox4.Text;
                    Player.Position = textBox5.Text;
                    Player.Height = Int32.Parse(textBox6.Text);
                    Player.Weight = Int32.Parse(textBox7.Text);
                    Player.Price = Double.Parse(textBox8.Text);
                    Player.Foot = comboBox1.Text;
                    if (new PlayerController().UpdatePlayer(Player))
                    {
                        var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                        if (language.Equals("srp"))
                        {
                            LoginForm.MessageBoxOK("Ažuriranje", "Uspješno ste se ažurirali igrača!");
                        }
                        else
                            LoginForm.MessageBoxOK("Changing", "Your player changing is successfull!");
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, "^[a-zA-Z ]*$"))
            {
                var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                if (language.Equals("srp"))
                {
                    LoginForm.MessageBoxError("Greška", "Za mjesto rođenja je moguće unijeti samo slova!");
                }
                else
                    LoginForm.MessageBoxError("Error", "Only letters can be entered for the birthplace!");
                textBox3.Text = String.Empty;

            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text, "^[a-zA-Z ]*$"))
            {
                var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                if (language.Equals("srp"))
                {
                    LoginForm.MessageBoxError("Greška", "Za državljlnastvo je moguće unijeti samo slova!");
                }
                else
                    LoginForm.MessageBoxError("Error", "Only letters can be entered for the citizenship!");
                textBox4.Text = String.Empty;

            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox5.Text, "^[a-zA-Z ]*$"))
            {
                var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                if (language.Equals("srp"))
                {
                    LoginForm.MessageBoxError("Greška", "Za poziciju je moguće unijeti samo slova!");
                }
                else
                    LoginForm.MessageBoxError("Error", "Only letters can be entered for the position!");
                textBox5.Text = String.Empty;

            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox6.Text, "^[0-9]*$"))
            {
                var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                if (language.Equals("srp"))
                {
                    LoginForm.MessageBoxError("Greška", "Za visinu je moguće unijeti samo brojeve!");
                }
                else
                    LoginForm.MessageBoxError("Error", "Only numbers can be entered for the height!");
                textBox6.Text = String.Empty;
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox7.Text, "^[0-9]*$"))
            {
                var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                if (language.Equals("srp"))
                {
                    LoginForm.MessageBoxError("Greška", "Za težinu je moguće unijeti samo brojeve!");
                }
                else
                    LoginForm.MessageBoxError("Error", "Only numbers can be entered for the weight!");
                textBox7.Text = String.Empty;
            }
        }

        /*private void textBox8_TextChanged(object sender, EventArgs e)
        {
            //^-{0,1}\\d+\\.{0,1}\\d*$
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox8.Text, "^[0-9]*$"))
            {
                var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                if (language.Equals("srp"))
                {
                    LoginForm.MessageBoxError("Greška", "Za cijenu je moguće unijeti samo brojeve!");
                }
                else
                {
                    LoginForm.MessageBoxError("Error", "Only numbers can be entered for the price!"); 
                }
                textBox8.Text = string.Empty;
            }

        }*/

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' && textBox8.Text.Contains("."))
            {
                // Stop more than one dot Char
                e.Handled = true;
            }
            else if (e.KeyChar == '.' && textBox8.Text.Length == 0)
            {
                // Stop first char as a dot input
                e.Handled = true;
            }
            else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                // Stop allow other than digit and control
                var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                if (language.Equals("srp"))
                {
                    LoginForm.MessageBoxError("Greška", "Za cijenu je moguće unijeti samo brojeve!");
                }
                else
                {
                    LoginForm.MessageBoxError("Error", "Only numbers can be entered for the price!");
                }
                e.Handled = true;
            }
        }

    }
}

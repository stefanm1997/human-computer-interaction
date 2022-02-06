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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerTransfers.Forms
{
    partial class ContractForm : Form
    {
        public Contract Contract { get; set; }
       
        public ContractForm()
        {
            InitializeComponent();
        }

        private void ContractForm_Load(object sender, EventArgs e)
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

            //new PlayersControl();
            var allPlayers = new PlayerController().AllPlayers();
           
            foreach (var player in allPlayers)
             {
                 comboBox1.Items.Add(player);
             }
            if (comboBox1.Items != null)
            {
                comboBox1.Text = comboBox1.Items[0].ToString();
            }
       

            //new ClubControl()
            var allClubs = new ClubController().AllClubs();
            //int j = 1;
            foreach (var club in allClubs)
            {
                comboBox2.Items.Add(club);

            }
            comboBox2.Text = comboBox2.Items[0].ToString();
            /*if (Contract != null)
            {
                var clubName = new ClubController().GetNameFromID(Contract.idClub);
                comboBox2.Text = clubName;
                var playerName = new PlayerController().GetNameFromID(Contract.idPlayer);
                var playerSurname = new PlayerController().GetSurnameFromID(Contract.idPlayer);
                comboBox1.Text = playerName + " " + playerSurname;
            }*/
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' && textBox1.Text.Contains("."))
            {
                // Stop more than one dot Char
                e.Handled = true;
            }
            else if (e.KeyChar == '.' && textBox1.Text.Length == 0)
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
                    LoginForm.MessageBoxError("Greška", "Za platu je moguće unijeti samo brojeve!");
                }
                else
                {
                    LoginForm.MessageBoxError("Error", "Only numbers can be entered for the salary!");
                }
                e.Handled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "^[0-9]*$"))
            {
                var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                if (language.Equals("srp"))
                {
                    LoginForm.MessageBoxError("Greška", "Za broj je moguće unijeti samo brojeve!");
                }
                else
                    LoginForm.MessageBoxError("Error", "Only numbers can be entered for the number!");
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
                    LoginForm.MessageBoxError("Greška", "Za natpis rođenja je moguće unijeti samo slova!");
                }
                else
                    LoginForm.MessageBoxError("Error", "Only letters can be entered for the jersey!");
                textBox3.Text = String.Empty;

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
                        LoginForm.MessageBoxError("Greška", "Polje sa platom mora biti uneseno!");
                    }
                    else
                        LoginForm.MessageBoxError("Error", "Field with salary must be entered!");
                    break;
                }

                if (textBox2.Text.Length == 0)
                {
                    var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                    if (language.Equals("srp"))
                    {
                        LoginForm.MessageBoxError("Greška", "Polje sa brojem mora biti uneseno!");
                    }
                    else
                        LoginForm.MessageBoxError("Error", "Field with number must be entered!");
                    break;
                }
                else
                    textBox2_TextChanged(sender, e);

                if (textBox3.Text.Length == 0)
                {
                    var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                    if (language.Equals("srp"))
                    {
                        LoginForm.MessageBoxError("Greška", "Polje sa natpis  mora biti uneseno!");
                    }
                    else
                        LoginForm.MessageBoxError("Error", "Field with jersey must be entered!");
                    break;
                }
                else
                    textBox3_TextChanged(sender, e);

                if (button1.Text.Equals("Create") || button1.Text.Equals("Kreiraj"))
                {
                    var player = comboBox1.SelectedItem as Player;
                    var club = comboBox2.SelectedItem as Club;
                    Contract = new Contract()
                    {
                        DateFrom = dateTimePicker1.Value,
                        DateTo = dateTimePicker2.Value,
                        idPlayer = player.ID,
                        idClub = club.ID,
                        Salary = Double.Parse(textBox1.Text),
                        Number = Int32.Parse(textBox2.Text),
                        Jersey = textBox3.Text
                    };
                    try
                    {
                        if (new ContractController().AddContract(Contract))
                        {
                            TransferControl.isCorrectContract = true;
                            var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                            if (language.Equals("srp"))
                            {
                                LoginForm.MessageBoxOK("Kreiranje", "Uspješno ste se kreirali ugovor!");
                            }
                            else
                                LoginForm.MessageBoxOK("Creation", "Your contract creation is successfull!");
                        }
                        else
                        {
                            TransferControl.isCorrectContract = false;
                            var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                            if (language.Equals("srp"))
                            {
                                LoginForm.MessageBoxError("Kreiranje", "Bezuspješno kreiranje. Pokušajte ponovo!");
                            }
                            else
                                LoginForm.MessageBoxError("Creation", "Unsuccessfull creations. Try again!");
                        }
                    }
                    catch (Exception e1)
                    {
                        TransferControl.isCorrectContract = false;
                        var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                        if (language.Equals("srp"))
                        {
                            LoginForm.MessageBoxError("Kreiranje", "Bezuspješno kreiranje. Unijeli ste igrača sa istim brojem dresa. Pokušajte ponovo!");
                        }
                        else
                            LoginForm.MessageBoxError("Creation", "Unsuccessfull creations. You are inserted player with number which already have. Try again!");
                    }
                }
               

                this.Close();
                break;

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}



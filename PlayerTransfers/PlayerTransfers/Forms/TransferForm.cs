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
    partial class TransferForm : Form
    {
        public Contract Contract { get; set; }
        public Transfer Transfer { get; set; }
        public TransferForm()
        {
            InitializeComponent();
        }

        public TransferForm(Contract contract)
        {
            InitializeComponent();
            textBox1.Text = contract.Salary.ToString();
            textBox2.Text = contract.Number.ToString();
            textBox3.Text = contract.Jersey;
            dateTimePicker1.Value = contract.DateFrom;
            dateTimePicker2.Value = contract.DateTo;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;

            Contract = contract;
        }

        private void TransferForm_Load(object sender, EventArgs e)
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

            var allPlayers = new PlayerController().AllPlayers();
            //int i = 1;
            foreach (var player in allPlayers)
            {
                comboBox1.Items.Add(player);

            }
            comboBox1.Text = comboBox1.Items[0].ToString();

            var allClubs = new ClubController().AllClubs();
            //int j = 1;
            foreach (var club in allClubs)
            {
                comboBox2.Items.Add(club);
                comboBox3.Items.Add(club);

            }
            comboBox2.Text = comboBox2.Items[0].ToString();
            comboBox3.Text = comboBox3.Items[0].ToString();

            if (Contract != null)
            {
                var clubName = new ClubController().GetNameFromID(Contract.idClub);
                comboBox2.Text = clubName;
                var playerName = new PlayerController().GetNameFromID(Contract.idPlayer);
                var playerSurname = new PlayerController().GetSurnameFromID(Contract.idPlayer);
                comboBox1.Text = playerName + " " + playerSurname;
            }

            var club1 = comboBox2.SelectedItem as Club;
            foreach (var item in comboBox3.Items)
            {
                var club2 = item as Club;
                if (club1.ClubName.Equals(club2.ClubName))
                {
                    comboBox3.Items.Remove(club2);
                    break;
                }
            }
            if (comboBox3.Items[0] != null)
            {
                comboBox3.Text = comboBox3.Items[0].ToString();
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

                if (textBox4.Text.Length == 0)
                {
                    var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                    if (language.Equals("srp"))
                    {
                        LoginForm.MessageBoxError("Greška", "Polje sa cijenom  mora biti uneseno!");
                    }
                    else
                        LoginForm.MessageBoxError("Error", "Field with price must be entered!");
                    break;
                }

                if (button1.Text.Equals("Create") || button1.Text.Equals("Kreiraj"))
                {
                    var player = comboBox1.SelectedItem as Player;
                    var club1 = comboBox2.SelectedItem as Club;
                    var club2 = comboBox3.SelectedItem as Club;
                    Transfer = new Transfer()
                    {
                        Date = dateTimePicker3.Value,
                        Price = Int32.Parse(textBox4.Text),
                        idPlayer = player.ID,
                        idClub1 = club1.ID,
                        idClub2 = club2 != null ? club2.ID : 0
                    };
                    Contract = new Contract()
                    {
                        DateFrom = dateTimePicker1.Value,
                        DateTo = dateTimePicker2.Value,
                        idPlayer = player.ID,
                        idClub = club2 != null ? club2.ID : 0,
                        Salary = Double.Parse(textBox1.Text),
                        Number = Int32.Parse(textBox2.Text),
                        Jersey = textBox3.Text
                    };

                    try
                    {
                        if (new TransferController().AddTransfer(Transfer))
                        {
                            new ContractController().UpdateContract(Contract);
                            TransferControl.isCorrectTransfer = true;
                            var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                            if (language.Equals("srp"))
                            {
                                LoginForm.MessageBoxOK("Kreiranje", "Uspješno ste se kreirali transfer!");
                            }
                            else
                                LoginForm.MessageBoxOK("Creation", "Your transfer creation is successfull!");
                        }
                        else
                        {
                            TransferControl.isCorrectTransfer = false;
                            var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                            if (language.Equals("srp"))
                            {
                                LoginForm.MessageBoxError("Kreiranje", "Bezuspješno kreiranje. Pokušajte ponovo!");
                            }
                            else
                                LoginForm.MessageBoxError("Creation", "Unsuccessfull creations. Try again!");
                        }
                    }
                    catch (Exception)
                    {
                        TransferControl.isCorrectTransfer = false;
                        var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                        if (language.Equals("srp"))
                        {
                            LoginForm.MessageBoxError("Kreiranje", "Bezuspješno kreiranje. Pokušajte ponovo!");
                        }
                        else
                            LoginForm.MessageBoxError("Creation", "Unsuccessfull creations. Try again!");
                    }
                }

                this.Close();
                break;

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

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
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

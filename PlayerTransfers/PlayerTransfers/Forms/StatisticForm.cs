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
    partial class StatisticForm : Form
    {
        public PlayerStatistic Statistic { get; set; }
        public StatisticForm()
        {
            InitializeComponent();
        }

        public StatisticForm(PlayerStatistic statistic)
        {
            InitializeComponent();
            textBox1.Text = statistic.Sezona;
            textBox2.Text = statistic.PlayedGames.ToString();
            textBox3.Text = statistic.Goals.ToString();
            textBox4.Text = statistic.Assists.ToString();
            textBox5.Text = statistic.Cards.ToString();
            textBox1.Enabled = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;

            var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
            if (language.Equals("srp"))
            {
                button1.Text = "Ažuriraj";
            }
            else
                button1.Text = "Change";

            Statistic = statistic;
        }


        private void StatisticForm_Load(object sender, EventArgs e)
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
            comboBox1.Text = comboBox1.Items[0].ToString();

            var allClubs = new ClubController().AllClubs();
            /*foreach (var club in allClubs)
            {
                comboBox2.Items.Add(club);

            }
            comboBox2.Text = comboBox2.Items[0].ToString();*/
            /*var player2 = comboBox1.SelectedItem as Player;
            var clubId = new ContractController().GetClubIdFromPlayerId(player2.ID);
                var clubName2 = new ClubController().GetNameFromID(clubId);
                if (!clubName2.Equals(""))
                {
                    comboBox2.Items.Add(clubName2);
                    comboBox2.Text = comboBox2.Items[0].ToString();
                    foreach (var club in allClubs)
                    {
                        if(!club.ClubName.Equals(clubName2))
                            comboBox2.Items.Add(club);

                    }
                    //comboBox2.Text = comboBox2.Items.W
                    //comboBox2.Enabled = false;
                }
            */
            /*else
            {
                foreach (var club in allClubs)
                {
                    comboBox2.Items.Add(club);

                }
                comboBox2.Text = comboBox2.Items[0].ToString();
                //comboBox2.Enabled = true;
            }*/


            /*if (Statistic != null)
            {
                var clubName = new ClubController().GetNameFromID(Statistic.KLUB_idKluba);
                comboBox2.Text = clubName;
                comboBox2.Enabled = false;
                var playerName = new PlayerController().GetNameFromID(Statistic.IGRAC_idIgraca);
                var playerSurname = new PlayerController().GetSurnameFromID(Statistic.IGRAC_idIgraca);
                comboBox1.Text = playerName + " " + playerSurname;
            }*/
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
                        LoginForm.MessageBoxError("Greška", "Polje sa sezonom mora biti uneseno!");
                    }
                    else
                        LoginForm.MessageBoxError("Error", "Field with season must be entered!");
                    break;
                }

                if (textBox2.Text.Length == 0)
                {
                    var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                    if (language.Equals("srp"))
                    {
                        LoginForm.MessageBoxError("Greška", "Polje sa odigranim utakmicama mora biti uneseno!");
                    }
                    else
                        LoginForm.MessageBoxError("Error", "Field with played games must be entered!");
                    break;
                }
                else
                    textBox2_TextChanged(sender, e);

                if (textBox3.Text.Length == 0)
                {
                    var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                    if (language.Equals("srp"))
                    {
                        LoginForm.MessageBoxError("Greška", "Polje sa golovima  mora biti uneseno!");
                    }
                    else
                        LoginForm.MessageBoxError("Error", "Field with goals must be entered!");
                    break;
                }
                else
                    textBox3_TextChanged(sender, e);

                if (textBox4.Text.Length == 0)
                {
                    var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                    if (language.Equals("srp"))
                    {
                        LoginForm.MessageBoxError("Greška", "Polje sa asistencijama mora biti uneseno!");
                    }
                    else
                        LoginForm.MessageBoxError("Error", "Field with assists must be entered!");
                    break;
                }
                else
                    textBox4_TextChanged(sender, e);

                if (textBox5.Text.Length == 0)
                {
                    var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                    if (language.Equals("srp"))
                    {
                        LoginForm.MessageBoxError("Greška", "Polje sa kartonima mora biti uneseno!");
                    }
                    else
                        LoginForm.MessageBoxError("Error", "Field with cards must be entered!");
                    break;
                }
                else
                    textBox5_TextChanged(sender, e);

                if (button1.Text.Equals("Create") || button1.Text.Equals("Kreiraj"))
                {
                    var player = comboBox1.SelectedItem as Player;
                    var club = new ClubController().GetClubFromName(comboBox2.SelectedItem.ToString());
                    Statistic = new PlayerStatistic()
                    {
                        IGRAC_idIgraca = player.ID,
                        KLUB_idKluba = club.ID,
                        Sezona = textBox1.Text,
                        PlayedGames = Int32.Parse(textBox2.Text),
                        Goals = Int32.Parse(textBox3.Text),
                        Assists = Int32.Parse(textBox4.Text),
                        Cards = Int32.Parse(textBox5.Text)
                    };
                    try
                    {
                        if (new StatisticController().AddPlayerStatistic(Statistic))
                        {
                            StatisticControl.isCorrect = true;
                            var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                            if (language.Equals("srp"))
                            {
                                LoginForm.MessageBoxOK("Kreiranje", "Uspješno ste se kreirali statistiku igrača!");
                            }
                            else
                                LoginForm.MessageBoxOK("Creation", "Your player statistic creation is successfull!");
                        }
                        else
                        {
                            StatisticControl.isCorrect = false;
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
                        StatisticControl.isCorrect = false;
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
                    Statistic.Sezona = textBox1.Text;
                    Statistic.PlayedGames = Int32.Parse(textBox2.Text);
                    Statistic.Goals = Int32.Parse(textBox3.Text);
                    Statistic.Assists = Int32.Parse(textBox4.Text);
                    Statistic.Cards = Int32.Parse(textBox5.Text);
                    try
                    {
                        if (new StatisticController().UpdateStatistic(Statistic))
                        {
                            var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                            if (language.Equals("srp"))
                            {
                                LoginForm.MessageBoxOK("Ažuriranje", "Uspješno ste se ažurirali statistiku igrača!");
                            }
                            else
                                LoginForm.MessageBoxOK("Changing", "Your player statistic changing is successfull!");
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
                    catch (Exception e1)
                    {
                        //Console.WriteLine("Ušo u escp");
                        var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                        if (language.Equals("srp"))
                        {
                            LoginForm.MessageBoxError("Kreiranje", "Bezuspješno kreiranje. Postoji već statistika sa tom sezonom i klubom. Pokušajte ponovo!");
                        }
                        else
                            LoginForm.MessageBoxError("Creation", "Unsuccessfull creations. Already exists statistic with input season and club. Try again!");
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
                    LoginForm.MessageBoxError("Greška", "Za odigrane utakmice je moguće unijeti samo brojeve!");
                }
                else
                    LoginForm.MessageBoxError("Error", "Only numbers can be entered for the played games!");
                textBox2.Text = String.Empty;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, "^[0-9]*$"))
            {
                var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                if (language.Equals("srp"))
                {
                    LoginForm.MessageBoxError("Greška", "Za golove je moguće unijeti samo brojeve!");
                }
                else
                    LoginForm.MessageBoxError("Error", "Only numbers can be entered for the goals!");
                textBox3.Text = String.Empty;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text, "^[0-9]*$"))
            {
                var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                if (language.Equals("srp"))
                {
                    LoginForm.MessageBoxError("Greška", "Za asistencije je moguće unijeti samo brojeve!");
                }
                else
                    LoginForm.MessageBoxError("Error", "Only numbers can be entered for the assists!");
                textBox4.Text = String.Empty;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox5.Text, "^[0-9]*$"))
            {
                var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                if (language.Equals("srp"))
                {
                    LoginForm.MessageBoxError("Greška", "Za kartone je moguće unijeti samo brojeve!");
                }
                else
                    LoginForm.MessageBoxError("Error", "Only numbers can be entered for the cards!");
                textBox5.Text = String.Empty;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == '/' && textBox1.Text.Contains("/"))
            {
                var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                if (language.Equals("srp"))
                {
                    LoginForm.MessageBoxError("Greška", "Već postoji /");
                }
                else
                {
                    LoginForm.MessageBoxError("Error", "Already exists /");
                }
                // Stop more than one dot Char
                e.Handled = true;
            }
            else if (e.KeyChar == '/' && textBox1.Text.Length == 0)
            {
                // Stop first char as a dot input
                e.Handled = true;
            }
            else if (e.KeyChar != '/' && textBox1.Text.Length == 4)
            {
                // Stop first char as a dot input
                e.Handled = true;
            }
            else if (char.IsDigit(e.KeyChar) && textBox1.Text.Length > 6)
            {
                // Stop first char as a dot input
                e.Handled = true;
            }
            else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '/')
            {
                // Stop allow other than digit and control
                var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                if (language.Equals("srp"))
                {
                    LoginForm.MessageBoxError("Greška", "Za sezonu je moguće unijeti samo brojeve i / u formatu (xxxx/xx)!");
                }
                else
                {
                    LoginForm.MessageBoxError("Error", "Only numbers and / in format (xxxx/xx) can be entered for the season!");
                }
                e.Handled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            var allClubs = new ClubController().AllClubs();
            var player2 = comboBox1.SelectedItem as Player;
            var clubId = new ContractController().GetClubIdFromPlayerId(player2.ID);
            if (clubId != 0)
            {
                var clubName2 = new ClubController().GetNameFromID(clubId);
                if (!clubName2.Equals(""))
                {
                    comboBox2.Items.Add(clubName2);
                    comboBox2.Text = comboBox2.Items[0].ToString();
                    foreach (var club in allClubs)
                    {
                        if (!club.ClubName.Equals(clubName2))
                            comboBox2.Items.Add(club);

                    }
                    //comboBox2.Enabled = false;
                }
            }
            else
            {
                foreach (var club in allClubs)
                {
                    comboBox2.Items.Add(club);

                }
                comboBox2.Text = comboBox2.Items[0].ToString();
                //comboBox2.Enabled = true;
            }
        }
    }
}

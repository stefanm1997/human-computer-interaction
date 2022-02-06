using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PlayerTransfers.Model;
using PlayerTransfers.Forms;
using PlayerTransfers.Controller;

namespace PlayerTransfers.UserControls
{
    partial class StatisticControl : UserControl
    {
        public static Dictionary<int, PlayerStatistic> allStatisticDic = new Dictionary<int, PlayerStatistic>();
        static int lastKey;
        public static bool isCorrect = true;
        public StatisticControl()
        {
            InitializeComponent();
            PopulateDictionary();
            IntializeDataGridView();
        }
        public void PopulateDictionary()
        {
            var listAllStatistic = new StatisticController().AllStatistic();
            int i = 1;
            foreach (var statistic in listAllStatistic)
            {
                allStatisticDic.Add(i++, statistic);
            }
            lastKey = i;
        }
        public void IntializeDataGridView()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            //dataGridView1.Rows.Clear();
            var plyContrl = new Controller.PlayerController();
            var clbContrl = new Controller.ClubController();
            foreach (var entry in allStatisticDic)
            {
                //DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                var sts = entry.Value;
                var index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = entry.Key;
                dataGridView1.Rows[index].Cells[1].Value = plyContrl.GetNameFromID(sts.IGRAC_idIgraca);
                dataGridView1.Rows[index].Cells[2].Value = plyContrl.GetSurnameFromID(sts.IGRAC_idIgraca);
                dataGridView1.Rows[index].Cells[3].Value = plyContrl.GetPositionFromID(sts.IGRAC_idIgraca);
                dataGridView1.Rows[index].Cells[4].Value = clbContrl.GetNameFromID(sts.KLUB_idKluba);
                dataGridView1.Rows[index].Cells[5].Value = sts.Sezona;
                dataGridView1.Rows[index].Cells[6].Value = sts.PlayedGames;
                dataGridView1.Rows[index].Cells[7].Value = sts.Goals;
                dataGridView1.Rows[index].Cells[8].Value = sts.Assists;
                dataGridView1.Rows[index].Cells[9].Value = sts.Cards;
                // dataGridView1.Rows.Add(row);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //PlayersControl.allPlayersDic.Clear();
            //ClubControl.allClubsDic.Clear();
            var stsForm = new StatisticForm();
            stsForm.ShowDialog();
            var statistic = stsForm.Statistic;
            if (statistic != null)
            {
                if (isCorrect)
                {
                    var plyContrl = new Controller.PlayerController();
                    var clbContrl = new Controller.ClubController();
                    var index = dataGridView1.Rows.Add();
                    dataGridView1.Rows[index].Cells[0].Value = lastKey;
                    dataGridView1.Rows[index].Cells[1].Value = plyContrl.GetNameFromID(statistic.IGRAC_idIgraca);
                    dataGridView1.Rows[index].Cells[2].Value = plyContrl.GetSurnameFromID(statistic.IGRAC_idIgraca);
                    dataGridView1.Rows[index].Cells[3].Value = plyContrl.GetPositionFromID(statistic.IGRAC_idIgraca);
                    dataGridView1.Rows[index].Cells[4].Value = clbContrl.GetNameFromID(statistic.KLUB_idKluba);
                    dataGridView1.Rows[index].Cells[5].Value = statistic.Sezona;
                    dataGridView1.Rows[index].Cells[6].Value = statistic.PlayedGames;
                    dataGridView1.Rows[index].Cells[7].Value = statistic.Goals;
                    dataGridView1.Rows[index].Cells[8].Value = statistic.Assists;
                    dataGridView1.Rows[index].Cells[9].Value = statistic.Cards;
                    allStatisticDic.Add(lastKey++, statistic);
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null)
            {
                if (dataGridView1.SelectedRows[0].Cells[0].Value == null)
                {
                    var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                    if (language.Equals("srp"))
                    {
                        LoginForm.MessageBoxError("Greška", "Nije selektovan ni jedna statistika!");
                    }
                    else
                        LoginForm.MessageBoxError("Error", "No player statistic have been selected!");
                }
                else
                {
                    var key = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                    var statistic = allStatisticDic[key];
                    new StatisticForm(statistic).ShowDialog();
                    allStatisticDic[key] = statistic;
                    var plyContrl = new Controller.PlayerController();
                    var clbContrl = new Controller.ClubController();
                    dataGridView1.SelectedRows[0].Cells[0].Value = key;
                    dataGridView1.SelectedRows[0].Cells[1].Value = plyContrl.GetNameFromID(statistic.IGRAC_idIgraca);
                    dataGridView1.SelectedRows[0].Cells[2].Value = plyContrl.GetSurnameFromID(statistic.IGRAC_idIgraca);
                    dataGridView1.SelectedRows[0].Cells[3].Value = plyContrl.GetPositionFromID(statistic.IGRAC_idIgraca);
                    dataGridView1.SelectedRows[0].Cells[4].Value = clbContrl.GetNameFromID(statistic.KLUB_idKluba);
                    dataGridView1.SelectedRows[0].Cells[5].Value = statistic.Sezona;
                    dataGridView1.SelectedRows[0].Cells[6].Value = statistic.PlayedGames;
                    dataGridView1.SelectedRows[0].Cells[7].Value = statistic.Goals;
                    dataGridView1.SelectedRows[0].Cells[8].Value = statistic.Assists;
                    dataGridView1.SelectedRows[0].Cells[9].Value = statistic.Cards;
                    //IntializeDataGridView();
                }
            }
 
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10)
            {
                //MessageBox.Show("You have selected in image in " + e.RowIndex + " row.");
                if (dataGridView1.SelectedRows[0].Cells[0].Value == null)
                {
                    var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                    if (language.Equals("srp"))
                    {
                        LoginForm.MessageBoxError("Greška", "Selektovan je prazan red!");
                    }
                    else
                        LoginForm.MessageBoxError("Error", "You selected empty row!");
                }
                else
                {
                    var key = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                    var statistic = allStatisticDic[key];
                    if (new StatisticController().DeleteStatistic(statistic.IGRAC_idIgraca, statistic.KLUB_idKluba, statistic.Sezona))
                    {
                        var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                        if (language.Equals("srp"))
                        {
                            LoginForm.MessageBoxOK("Potvrda", "Uspješno ste obrisali statistiku za igrača ");
                        }
                        else
                            LoginForm.MessageBoxOK("Confirmation", "Statistic for player is succesfull removed!");

                    }
                    allStatisticDic.Remove(key);
                    dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                    //IntializeDataGridView();
                }
            }
        }

        private void StatisticControl_Load(object sender, EventArgs e)
        {
            if (LoginForm.role.Equals("User"))
            {
                button1.Visible = false;
                button2.Visible = false;
                dataGridView1.Columns[10].Visible = false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PlayerTransfers.Forms;
using PlayerTransfers.Controller;
using PlayerTransfers.Model;

namespace PlayerTransfers.UserControls
{
    partial class PlayersControl : UserControl
    {

        public static Dictionary<int, Player> allPlayersDic = new Dictionary<int, Player>();
        static int lastKey;
        public PlayersControl()
        {

            InitializeComponent();
            PopulateDictionary();
            IntializeDataGridView();

        }
        
        public void PopulateDictionary()
        {
            var listAllPlayers = new PlayerController().AllPlayers();
            int i = 1;
            foreach (var player in listAllPlayers)
            {
                allPlayersDic.Add(i++, player);
            }
            lastKey = i;
        }
        public void IntializeDataGridView()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            //dataGridView1.Rows.Clear();
            foreach (var entry in allPlayersDic)
            {
                //DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                var ply = entry.Value;
                var index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = entry.Key;
                dataGridView1.Rows[index].Cells[1].Value = ply.Name;
                dataGridView1.Rows[index].Cells[2].Value = ply.Surname;
                dataGridView1.Rows[index].Cells[3].Value = ply.DateOfBirth.ToString("dd-MM-yyyy");
                dataGridView1.Rows[index].Cells[4].Value = ply.PlaceOfBirth;
                dataGridView1.Rows[index].Cells[5].Value = ply.Citizenship;
                dataGridView1.Rows[index].Cells[6].Value = ply.Position;
                dataGridView1.Rows[index].Cells[7].Value = ply.Height;
                dataGridView1.Rows[index].Cells[8].Value = ply.Weight;
                dataGridView1.Rows[index].Cells[9].Value = ply.Price;
                dataGridView1.Rows[index].Cells[10].Value = ply.Foot;
                // dataGridView1.Rows.Add(row);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var plyForm = new PlayerForm();
            plyForm.ShowDialog();
            var player = plyForm.Player;
            if (player != null)
            {
                var index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = lastKey;
                dataGridView1.Rows[index].Cells[1].Value = player.Name;
                dataGridView1.Rows[index].Cells[2].Value = player.Surname;
                dataGridView1.Rows[index].Cells[3].Value = player.DateOfBirth.ToString("dd-MM-yyyy");
                dataGridView1.Rows[index].Cells[4].Value = player.PlaceOfBirth;
                dataGridView1.Rows[index].Cells[5].Value = player.Citizenship;
                dataGridView1.Rows[index].Cells[6].Value = player.Position;
                dataGridView1.Rows[index].Cells[7].Value = player.Height;
                dataGridView1.Rows[index].Cells[8].Value = player.Weight;
                dataGridView1.Rows[index].Cells[9].Value = player.Price;
                dataGridView1.Rows[index].Cells[10].Value = player.Foot;
                allPlayersDic.Add(lastKey++, player);
                //IntializeDataGridView();
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null)
            {
                if(dataGridView1.SelectedRows[0].Cells[0].Value == null)
                {
                    var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                    if (language.Equals("srp"))
                    {
                        LoginForm.MessageBoxError("Greška", "Nije selektovan ni jedan igrač!");
                    }
                    else
                        LoginForm.MessageBoxError("Error", "No player have been selected!");
                }
                else
                {
                    var key = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                    var player = allPlayersDic[key];
                    new PlayerForm(player).ShowDialog();
                    allPlayersDic[key] = player;
                    dataGridView1.SelectedRows[0].Cells[0].Value = key;
                    dataGridView1.SelectedRows[0].Cells[1].Value = player.Name;
                    dataGridView1.SelectedRows[0].Cells[2].Value = player.Surname;
                    dataGridView1.SelectedRows[0].Cells[3].Value = player.DateOfBirth.ToString("dd-MM-yyyy");
                    dataGridView1.SelectedRows[0].Cells[4].Value = player.PlaceOfBirth;
                    dataGridView1.SelectedRows[0].Cells[5].Value = player.Citizenship;
                    dataGridView1.SelectedRows[0].Cells[6].Value = player.Position;
                    dataGridView1.SelectedRows[0].Cells[7].Value = player.Height;
                    dataGridView1.SelectedRows[0].Cells[8].Value = player.Weight;
                    dataGridView1.SelectedRows[0].Cells[9].Value = player.Price;
                    dataGridView1.SelectedRows[0].Cells[10].Value = player.Foot;
                    //IntializeDataGridView();
                }
                
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 11)
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
                        var player = allPlayersDic[key];
                        if (new PlayerController().DeletePlayer(player.ID))
                        {
                            var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                            if (language.Equals("srp"))
                            {
                                LoginForm.MessageBoxOK("Potvrda", "Uspješno ste obrisali igrača: " + player.Name + " " + player.Surname);
                            }
                            else
                                LoginForm.MessageBoxOK("Confirmation", "Player " + player.Name + " " + player.Surname + " is succesfull removed!");
                        }
                        allPlayersDic.Remove(key);
                        dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                        //IntializeDataGridView();
                    }
                }
            }
            catch(Exception e1)
            {
                var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                if (language.Equals("srp"))
                {
                    LoginForm.MessageBoxError("Greška", "Nije moguće obrisati igrača! ");
                }
                else
                    LoginForm.MessageBoxError("Error", "It is not possible to delete player! ");
            }
            
        }

        private void PlayersControl_Load(object sender, EventArgs e)
        {
            if (LoginForm.role.Equals("User"))
            {
                button1.Visible = false;
                button2.Visible = false;
                dataGridView1.Columns[11].Visible = false;
            }
        }
    }
}

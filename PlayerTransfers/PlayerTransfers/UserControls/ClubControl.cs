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
using PlayerTransfers.Controller;
using PlayerTransfers.Forms;

namespace PlayerTransfers.UserControls
{
    partial class ClubControl : UserControl
    {
        public static Dictionary<int, Club> allClubsDic = new Dictionary<int, Club>();
        static int lastKey;
        public ClubControl()
        {
            InitializeComponent();
            PopulateDictionary();
            IntializeDataGridView();
            
        }

        public void PopulateDictionary()
        {
            var listAllClubs = new ClubController().AllClubs();
            int i = 1;
            foreach (var club in listAllClubs)
            {
                allClubsDic.Add(i++, club);
            }
            lastKey = i;
        }
        public void IntializeDataGridView()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            //dataGridView1.Rows.Clear();
            foreach (var entry in allClubsDic)
            {
                //DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                var clb = entry.Value;
                var index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = entry.Key;
                dataGridView1.Rows[index].Cells[1].Value = clb.ClubName;
                dataGridView1.Rows[index].Cells[2].Value = clb.League;
                dataGridView1.Rows[index].Cells[3].Value = clb.FoundationDate.ToString("dd-MM-yyyy");
                dataGridView1.Rows[index].Cells[4].Value = clb.Address;
                dataGridView1.Rows[index].Cells[5].Value = clb.Phone;
                dataGridView1.Rows[index].Cells[6].Value = clb.Stadium;
                // dataGridView1.Rows.Add(row);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 7)
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
                        var club = allClubsDic[key];
                        if (new ClubController().DeleteClub(club.ID))
                        {
                            var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
                            if (language.Equals("srp"))
                            {
                                LoginForm.MessageBoxOK("Potvrda", "Uspješno ste obrisali klub: " + club.ClubName);
                            }
                            else
                                LoginForm.MessageBoxOK("Confirmation", "Club " + club.ClubName + " is succesfull removed!");
                        }
                        allClubsDic.Remove(key);
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
                    LoginForm.MessageBoxError("Greška", "Nije moguće obrisati klub! ");
                }
                else
                    LoginForm.MessageBoxError("Error", "It is not possible to delete club! ");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var clbForm = new ClubForm();
            clbForm.ShowDialog();
            var club = clbForm.Club;
            if (club != null)
            {
                var index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = lastKey;
                dataGridView1.Rows[index].Cells[1].Value = club.ClubName;
                dataGridView1.Rows[index].Cells[2].Value = club.League;
                dataGridView1.Rows[index].Cells[3].Value = club.FoundationDate.ToString("dd-MM-yyyy");
                dataGridView1.Rows[index].Cells[4].Value = club.Address;
                dataGridView1.Rows[index].Cells[5].Value = club.Phone;
                dataGridView1.Rows[index].Cells[6].Value = club.Stadium;
                allClubsDic.Add(lastKey++, club);
                //IntializeDataGridView();
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
                        LoginForm.MessageBoxError("Greška", "Nije selektovan ni jedan klub!");
                    }
                    else
                        LoginForm.MessageBoxError("Error", "No club have been selected!");
                }
                else
                {

                    var key = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                    var club = allClubsDic[key];
                    new ClubForm(club).ShowDialog();
                    allClubsDic[key] = club;
                    dataGridView1.SelectedRows[0].Cells[0].Value = key;
                    dataGridView1.SelectedRows[0].Cells[1].Value = club.ClubName;
                    dataGridView1.SelectedRows[0].Cells[2].Value = club.League;
                    dataGridView1.SelectedRows[0].Cells[3].Value = club.FoundationDate.ToString("dd-MM-yyyy");
                    dataGridView1.SelectedRows[0].Cells[4].Value = club.Address;
                    dataGridView1.SelectedRows[0].Cells[5].Value = club.Phone;
                    dataGridView1.SelectedRows[0].Cells[6].Value = club.Stadium;
                    //IntializeDataGridView();
                }

            }
        }

        private void ClubControl_Load(object sender, EventArgs e)
        {
            if (LoginForm.role.Equals("User"))
            {
                button1.Visible = false;
                button2.Visible = false;
                dataGridView1.Columns[7].Visible = false;
            }
        }
    }
}

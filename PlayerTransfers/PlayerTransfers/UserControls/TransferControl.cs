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
    partial class TransferControl : UserControl
    {
        public static Dictionary<int, Contract> allContractsDic = new Dictionary<int, Contract>();
        public static Dictionary<int, Transfer> allTransfersDic = new Dictionary<int, Transfer>();
        static int lastKeyContract;
        static int lastKeyTransfer;
        public static bool isCorrectContract = true;
        public static bool isCorrectTransfer = true;
        public TransferControl()
        {
            InitializeComponent();
            PopulateDictionaryContracts();
            IntializeDataGridView1();
            PopulateDictionaryTransfers();
            IntializeDataGridView2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var cntrForm = new ContractForm();
            cntrForm.ShowDialog();
            var contract = cntrForm.Contract;
            if (contract != null)
            {
                if (isCorrectContract)
                {
                    var plyContrl = new Controller.PlayerController();
                    var clbContrl = new Controller.ClubController();
                    var index = dataGridView1.Rows.Add();
                    dataGridView1.Rows[index].Cells[0].Value = lastKeyContract;
                    dataGridView1.Rows[index].Cells[1].Value = plyContrl.GetNameFromID(contract.idPlayer);
                    dataGridView1.Rows[index].Cells[2].Value = plyContrl.GetSurnameFromID(contract.idPlayer);
                    dataGridView1.Rows[index].Cells[3].Value = clbContrl.GetNameFromID(contract.idClub);
                    dataGridView1.Rows[index].Cells[4].Value = contract.DateFrom;
                    dataGridView1.Rows[index].Cells[5].Value = contract.DateTo;
                    dataGridView1.Rows[index].Cells[6].Value = contract.Salary;
                    dataGridView1.Rows[index].Cells[7].Value = contract.Number;
                    dataGridView1.Rows[index].Cells[8].Value = contract.Jersey;
                    allContractsDic.Add(lastKeyContract++, contract);
                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var key = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            var contract = allContractsDic[key];
            //new StatisticForm(statistic).ShowDialog();
            var transForm = new TransferForm(contract);
            transForm.ShowDialog();
            allContractsDic[key] = transForm.Contract;
            var transfer = transForm.Transfer;
            if (transfer != null)
            {

                var plyContrl = new Controller.PlayerController();
                var clbContrl = new Controller.ClubController();

                dataGridView1.SelectedRows[0].Cells[0].Value = key;
                dataGridView1.SelectedRows[0].Cells[2].Value = plyContrl.GetSurnameFromID(transForm.Contract.idPlayer);
                dataGridView1.SelectedRows[0].Cells[3].Value = clbContrl.GetNameFromID(transForm.Contract.idClub);
                dataGridView1.SelectedRows[0].Cells[1].Value = plyContrl.GetNameFromID(transForm.Contract.idPlayer);
                dataGridView1.SelectedRows[0].Cells[4].Value = transForm.Contract.DateFrom;
                dataGridView1.SelectedRows[0].Cells[5].Value = transForm.Contract.DateTo;
                dataGridView1.SelectedRows[0].Cells[6].Value = transForm.Contract.Salary;
                dataGridView1.SelectedRows[0].Cells[7].Value = transForm.Contract.Number;
                dataGridView1.SelectedRows[0].Cells[8].Value = transForm.Contract.Jersey;


                var index = dataGridView2.Rows.Add();
                dataGridView2.Rows[index].Cells[0].Value = lastKeyTransfer;
                dataGridView2.Rows[index].Cells[1].Value = plyContrl.GetNameFromID(transfer.idPlayer);
                dataGridView2.Rows[index].Cells[2].Value = plyContrl.GetSurnameFromID(transfer.idPlayer);
                dataGridView2.Rows[index].Cells[3].Value = clbContrl.GetNameFromID(transfer.idClub1);
                dataGridView2.Rows[index].Cells[4].Value = clbContrl.GetNameFromID(transfer.idClub2);
                dataGridView2.Rows[index].Cells[5].Value = transfer.Date;
                dataGridView2.Rows[index].Cells[6].Value = transfer.Price;
                allTransfersDic.Add(lastKeyTransfer++, transfer);


            }
        }

        public void PopulateDictionaryContracts()
        {
            var listAllContracts = new ContractController().AllContracts();
            int i = 1;
            foreach (var statistic in listAllContracts)
            {
                allContractsDic.Add(i++, statistic);
            }
            lastKeyContract = i;
        }

        public void PopulateDictionaryTransfers()
        {
            var listAllTransfers = new TransferController().AllTransfers();
            int i = 1;
            foreach (var transfers in listAllTransfers)
            {
                allTransfersDic.Add(i++, transfers);
            }
            lastKeyTransfer = i;
        }

        public void IntializeDataGridView1()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            //dataGridView1.Rows.Clear();
            var plyContrl = new Controller.PlayerController();
            var clbContrl = new Controller.ClubController();
            foreach (var entry in allContractsDic)
            {
                var index = dataGridView1.Rows.Add();
                var cntr = entry.Value;
                dataGridView1.Rows[index].Cells[0].Value = entry.Key;
                dataGridView1.Rows[index].Cells[1].Value = plyContrl.GetNameFromID(cntr.idPlayer);
                dataGridView1.Rows[index].Cells[2].Value = plyContrl.GetSurnameFromID(cntr.idPlayer);
                dataGridView1.Rows[index].Cells[3].Value = clbContrl.GetNameFromID(cntr.idClub);
                dataGridView1.Rows[index].Cells[4].Value = cntr.DateFrom;
                dataGridView1.Rows[index].Cells[5].Value = cntr.DateTo;
                dataGridView1.Rows[index].Cells[6].Value = cntr.Salary;
                dataGridView1.Rows[index].Cells[7].Value = cntr.Number;
                dataGridView1.Rows[index].Cells[8].Value = cntr.Jersey;
                
            }
        }

        public void IntializeDataGridView2()
        {
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
            //dataGridView1.Rows.Clear();
            var plyContrl = new Controller.PlayerController();
            var clbContrl = new Controller.ClubController();
            foreach (var entry in allTransfersDic)
            {
                var index = dataGridView2.Rows.Add();
                var trns = entry.Value;
                dataGridView2.Rows[index].Cells[0].Value = entry.Key;
                dataGridView2.Rows[index].Cells[1].Value = plyContrl.GetNameFromID(trns.idPlayer);
                dataGridView2.Rows[index].Cells[2].Value = plyContrl.GetSurnameFromID(trns.idPlayer);
                dataGridView2.Rows[index].Cells[3].Value = clbContrl.GetNameFromID(trns.idClub1);
                dataGridView2.Rows[index].Cells[4].Value = clbContrl.GetNameFromID(trns.idClub2);
                dataGridView2.Rows[index].Cells[5].Value = trns.Date;
                dataGridView2.Rows[index].Cells[6].Value = trns.Price;

            }
        }

        private void TransferControl_Load(object sender, EventArgs e)
        {
            if (LoginForm.role.Equals("User"))
            {
                button1.Visible = false;
                button2.Visible = false;
            }
        }
    }
}

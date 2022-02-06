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
    public partial class MenuForm : Form
    {
        UserControl Control = new HomeControl();
        public MenuForm(string message)
        {
            InitializeComponent();
            //Control = new HomeControl();
            label2.Text = message;
        }

       

        private void MenuForm_Load(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Add(Control);
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
            MenuForm_Resize(sender, e);
        }

        private void splitContainer1_Panel2_Resize(object sender, EventArgs e)
        {
            Control.Size = splitContainer1.Panel2.ClientSize;
        }
    
        private void button2_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Remove(Control);
            Control = new HomeControl();
            //splitContainer1.Panel2.Controls.Add(Control);
            MenuForm_Load(sender, e);
            MenuForm_Resize(sender, e);
        }

        public void button3_Click(object sender, EventArgs e)
        {
            PlayersControl.allPlayersDic.Clear();
            splitContainer1.Panel2.Controls.Remove(Control);
            Control = new PlayersControl();
            MenuForm_Load(sender, e);
            //splitContainer1.Panel2.Controls.Add(Control);
            MenuForm_Resize(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        { 
            StatisticControl.allStatisticDic.Clear();
            splitContainer1.Panel2.Controls.Remove(Control);
            Control = new StatisticControl();
            MenuForm_Load(sender, e);
            //splitContainer1.Panel2.Controls.Add(Control);
            MenuForm_Resize(sender, e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TransferControl.allTransfersDic.Clear();
            TransferControl.allContractsDic.Clear();
            splitContainer1.Panel2.Controls.Remove(Control);
            Control = new TransferControl();
            MenuForm_Load(sender, e);
            //splitContainer1.Panel2.Controls.Add(Control);
            MenuForm_Resize(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ClubControl.allClubsDic.Clear();
            splitContainer1.Panel2.Controls.Remove(Control);
            Control = new ClubControl();
            MenuForm_Load(sender, e);
            //splitContainer1.Panel2.Controls.Add(Control);
            MenuForm_Resize(sender, e);
        }

        private void MenuForm_Resize(object sender, EventArgs e)
        {
            Control.Size = splitContainer1.Panel2.ClientSize;  
        }
    }
}

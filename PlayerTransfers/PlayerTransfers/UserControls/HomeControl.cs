using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerTransfers.UserControls
{
    public partial class HomeControl : UserControl
    {
        public HomeControl()
        {
            InitializeComponent();
            InitializeAboutTab();
        }

        private void InitializeAboutTab()
        {
            this.labelProductName.Text += Util.AssemblyProduct;
            this.labelVersion.Text += String.Format("Version {0}", Util.AssemblyVersion);
            this.labelCopyright.Text += Util.AssemblyCopyright;
            this.labelCompanyName.Text += Util.AssemblyCompany;
            this.textBoxDescription.Text = Util.AssemblyDescription;
            var language = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
            if (language.Equals("srp"))
            {
                this.textBoxDescription.Text = "Ovaj proizvod je softver o fudbalskim igračima i njihovi transferima na transfer pijacama.";
            }
        }
    }
}

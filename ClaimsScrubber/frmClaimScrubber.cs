using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClaimsScrubber
{
    public partial class frmClaimScrubber : Form
    {
        public frmClaimScrubber()
        {
            InitializeComponent();
        }

        private void btnScrub_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDiag = new OpenFileDialog();

            string initPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            openFileDiag.InitialDirectory = initPath;
            openFileDiag.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDiag.FilterIndex = 1;
            openFileDiag.RestoreDirectory = true;

            openFileDiag.ShowDialog();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

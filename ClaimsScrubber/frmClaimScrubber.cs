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
using System.Text.RegularExpressions;

namespace ClaimsScrubber
{
    public partial class frmClaimScrubber : Form
    {

        public string fileContents = "";
        public string filePath = "";


        public frmClaimScrubber()
        {
            InitializeComponent();
        }

        private void btnScrub_Click(object sender, EventArgs e)
        {
            if (fileContents != "") {
                parseSegs(fileContents);
            }
            else
            {
                rtbResults.Text = "Please select a file before parsing!";
                //Color the text red to get their attention.
                rtbResults.SelectAll();
                rtbResults.SelectionColor = Color.Red;
                rtbResults.Select(0, 0);
            }
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

            if (openFileDiag.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDiag.FileName;
                fileContents = File.ReadAllText(filePath);

                rtbResults.Text = fileContents;
                //Now that we have the file contents, we need to parse it into "loops".

            }

            


        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rtbResults_TextChanged(object sender, EventArgs e)
        {

        }


        //Parses a string filled with claim data into loops.
        private void parseSegs(string inputClaimData)
        {
            /*Structure will be in a multi-dim vector of strings. 1st reference will be the Segment ID.
             Subsequent loop info will be stored afterwards. Since this is a simple scrubber I won't worry
             about the details of each line, and will only save the info I'll be checking per loop.

             Seg ID 0      Seg ID 1
             0 - NDC        0 - NDC
             1 - Admit Date 1 - Etc...
             2 - Etc        2 - ...
             */

            //Identify the number of segments.
            
            int stSegCount = 0;
            int seSegCount = 0;
            foreach (Match m in Regex.Matches(fileContents, "ST"))
            {
                stSegCount++;
            }
            foreach (Match m in Regex.Matches(fileContents, "SE"))
            {
                seSegCount++;
            }

            //Ensure that every segment has a closing segment. Throw an error if not.
            if (stSegCount == seSegCount)
            {
                rtbResults.Text = "Segment Count: " + Convert.ToString(stSegCount);
            }
            else
            {
                rtbResults.Text = "Start and End Segments mismatched!\n";
                rtbResults.AppendText("Found " + Convert.ToString(seSegCount) + " End Segment statements. Expected " + Convert.ToString(stSegCount) + "!");
                rtbResults.SelectAll();
                rtbResults.SelectionColor = Color.Red;
                rtbResults.Select(0, 0);
            }



        }
    }
}

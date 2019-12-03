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
            fileContents = File.ReadAllText(txtbFilePath.Text);

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
            openFileDiag.Filter = "EDI X12 (*.X12)|*.X12|txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDiag.FilterIndex = 1;
            openFileDiag.RestoreDirectory = true;

            if (openFileDiag.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDiag.FileName;
                txtbFilePath.Text = filePath;
                //In case someone manually changes the text, we should utilize what's in the textbox:
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
             about the details of each line, and will only save the info I'll be checking per segment/loop.

             Seg ID 0      Seg ID 1
             0 - NDC        0 - NDC
             1 - Admit Date 1 - Etc...
             2 - Etc        2 - ...
             */

            //Identify the number of segments.
            
            int stSegCount = 0;
            int seSegCount = 0;
            foreach (Match m in Regex.Matches(fileContents, "\nST"))
            {
                stSegCount++;
            }
            foreach (Match m in Regex.Matches(fileContents, "\nSE"))
            {
                seSegCount++;
            }

            //Ensure that every segment has a closing segment. Throw an error if not.
            if (stSegCount == seSegCount)
            {

                //If the segments match fine, begin parsing them out:

                int endA = fileContents.Length;
                int endB = fileContents.Length;
                int SegCount = stSegCount;
                string[,] segments = new string[stSegCount, 5];                

                /*
                 0 1 2 3 4
                 1 1 2 3 4
                 2 1 2 3 4          
                 
                The firt element is always the full segment info.
                We will use sub-commands to break it apart into smaller sections and assign those to values.


                0 - Segment in full
                1 - CLM #
                2 - Patient Last Name
                3 - Patient First Name
                4 - Patient MI
                1 - Admit Date
                2 - Service Date
                3 - NDC
                4 - Service Code, modifiers
                */


                int ib = 0;
                foreach (Match m in Regex.Matches(fileContents, "(?s)\nST(.+?)\nSE(.+?)(\r|$)"))
                {

                    segments[ib, 0] = Convert.ToString(m);
                    //Account Number from the CLM segment

                    //
                    segments[ib, 1] = findBetween(segments[ib, 0], "CLM\\*", "\\*");
                    //Grab the full name. We'll cut this down to the last name later.
                    segments[ib, 2] = findBetween(segments[ib, 0], "NM1\\*IL\\*1\\*", "\r|$");
                    segments[ib, 3] = findBetween(segments[ib, 2], "\\*", "\\*\\*\\*\\*");
                    segments[ib, 4] = findBetween(segments[ib, 2], "\\*\\*\\*\\*", "\\*");
                    //Cut the full name down to last name only.
                    segments[ib, 2] = findBetween(segments[ib, 2], "^", "\\*");

                 ib++;
                }

                rtbResults.Text = segments[0, 1];
                rtbResults.Text = segments[0, 2];
                rtbResults.AppendText(segments[0, 3]);
                rtbResults.AppendText(segments[0, 4]);






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
        //Returns the string between the findBegin and findEnd
        private string findBetween (string operateString, string findBegin, string findEnd)
        {
            Match n = Regex.Match(operateString, "(?<="+ findBegin + ")(.*?)(?=" + findEnd + ")");
            //segments[ib, 1] = Convert.ToString(n);
            return Convert.ToString(n);
        }

    }
}

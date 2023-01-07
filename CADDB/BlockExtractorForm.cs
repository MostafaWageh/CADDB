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

namespace CADDB
{
    public partial class BlockExtractorForm : Form
    {
        public BlockExtractorForm()
        {
            InitializeComponent();
        }

        private void btnExtractBlock_Click(object sender, EventArgs e)
        {
            if (txtBLockname.Text == "")
            {
                lblInfo.Text = "Please Enter the Blockname to extract.";
                lblInfo.ForeColor = Color.Red;
                txtBLockname.Focus();
                return;

            }
            int i = 1;
            int totalcount = chkLstDwgs.CheckedItems.Count;
            string blockname = txtBLockname.Text.Trim();
                    
            BlockExtractorClass beu = new BlockExtractorClass();
            foreach (string dwgfile in chkLstDwgs.CheckedItems)
            {
                lblInfo.Text = "Processing(" + i.ToString() + " of " + totalcount.ToString() + ") : " + dwgfile;
                lblInfo.ForeColor = Color.Green;
                string filename = dwgfile + " blocks.txt";
                beu.ProcessBlockExtraction(dwgfile, blockname, filename);
                i += 1;

            }
            lblInfo.Text = "Extraction maded Sucessufly !!!";
        }

        private void BlockExtractorForm_Load(object sender, EventArgs e)
        {
            LoadDrawing(textPath.Text);

        }
        //To Generate a method for Browesing and choosing the FIles
        private void LoadDrawing(string dwgPath)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.SelectedPath = dwgPath;

                string[] files = Directory.GetFiles(fbd.SelectedPath, "*.dwg");

                //Velidation to the files (to check if the user select file or the whole files)

                if (files.Length > 0)
                {
                    foreach (string dwg in files)
                    {
                        //Checks for Items in the List Box
                        chkLstDwgs.Items.Add(dwg);
                    }
                    lblInfo.Text = "Total Number of drawing =" + chkLstDwgs.Items.Count;
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create BUtton to moVe and Choose Working File
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.SelectedPath = textPath.Text;
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrEmpty(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath, "*.dwg");
                    //Clear the list to Upload all drawing files in folder
                    //First Clear
                    chkLstDwgs.Items.Clear();
                    foreach (string dwg in files)
                    {
                        chkLstDwgs.Items.Add(dwg);

                    }
                }
                lblInfo.Text = "Total number of drawing = " + chkLstDwgs.Items.Count;
                textPath.Text = fbd.SelectedPath;
            }
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLstDwgs.CheckedItems.Count>0)
            {
                for (int i = 0; i < chkLstDwgs.Items.Count; i++)
                {
                    btnExtractBlock.Enabled = true;
                }
                
            }
            else
            {

                btnExtractBlock.Enabled = false;

            }
            lblInfo.Text = "Number of Selected drawing = " + chkLstDwgs.CheckedItems.Count;
        }
    }
    }

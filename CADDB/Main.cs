using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CADDB
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBLoadUtil dbload = new DBLoadUtil();
            string result = dbload.LoadLines();
            lblInfo.Text = result;  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DBLoadUtil dbload = new DBLoadUtil();
            string result = dbload.LoadMtext();
            lblInfo.Text = result;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DBLoadUtil dbload = new DBLoadUtil();
            string result = dbload.LoadPolylines();
            lblInfo.Text = result;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DBLoadUtil dbload = new DBLoadUtil();
            string result = dbload.LoadBlocksNoattribute();
            lblInfo.Text = result;

        }
        private void button5_Click(object sender, EventArgs e)
        {
            DBLoadUtil dbload = new DBLoadUtil();
            string result = dbload.LoadBlocksWithattribute();
            lblInfo.Text = result;
            
        }

        private void lblInfo_Click(object sender, EventArgs e)
        {

        }

        private void bxt_Click(object sender, EventArgs e)
        {
            BlockExtractorForm form2 = new BlockExtractorForm();
            form2.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}

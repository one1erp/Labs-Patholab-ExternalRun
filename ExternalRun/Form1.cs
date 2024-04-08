using ADODB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExternalRun
{
    public partial class Form1 : Form
    {

        Connection con;
        public Form1(Connection con1)
        {
            con = con1;
            InitializeComponent();
            organBridge1.OrganSelected += organBridge1_OrganSelected;
            LoadOrgan();

            //927975

        }

        void organBridge1_OrganSelected(VB6Bridge.OrganRes obj)
        {
            label4.Text = obj.Organ;
            label3.Text = obj.strProcedure;
            label2.Text = obj.strSide;
        }

        private void LoadOrgan()
        {
            organBridge1.InitilaizeCtrl(con, "lims_sys", 1);

        }
        private void button4_Click(object sender, EventArgs e)
        {
            organBridge1.setSample(0);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string d = numericUpDown1.Value.ToString();
                organBridge1.setSample(long.Parse(d));
            }
            catch (Exception ex)
            {


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            organBridge1.RefreshInitialize();
        }


        #region RequestRemark
        private void LoadReqRem()
        {
            requestRemarksBridge1.InitilaizeCtrl(con, "1");
        }
        private void requestRemarksBridge1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            requestRemarksBridge1.sampleInput(txtSdg.Text);
        }
        #endregion

        private void organBridge1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

    
    }
}

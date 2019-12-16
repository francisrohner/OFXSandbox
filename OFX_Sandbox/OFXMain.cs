using System;
using System.Windows.Forms;
using System.Xml;
using OFX_Sandbox.OFX;
using OFX_Sandbox.UserControls;

namespace OFX_Sandbox
{
    public partial class OFXMain : Form
    {  

        public OFXMain()
        {
            InitializeComponent();
            fetchControl.FetchHandler += OnFetch;
            Load += OFXMain_Load;
            FormClosing += OFXMain_FormClosing;
        }

        private void OFXMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            fetchControl.SaveSettings();
        }

        private void OFXMain_Load(object sender, EventArgs e)
        {
            fetchControl.LoadSettings();   
        }        

        private void OnFetch(object sender, FetchEventArgs e)
        {
            OFXRequest request = e.Request;
            

            OFXResponse response = e.Response;
            rtbRaw.Text = response.Raw;
            if(response.Success)
            {
                //Graphical stuff

            }
            tcMain.SelectedTab = tabpageRaw;
        }
        
    }
}

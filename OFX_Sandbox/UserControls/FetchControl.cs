using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OFX_Sandbox.Utilities;
using OFX_Sandbox.OFX;
using System.IO;
using Newtonsoft.Json;

namespace OFX_Sandbox.UserControls
{
    public partial class FetchControl : UserControl
    {
        public FetchEventHandler FetchHandler;   

        public FetchControl()
        {
            InitializeComponent();
            InitCombos();
            btnFetch.MouseClick += BtnFetch_MouseClick;
            btnFetch.MouseUp += BtnFetch_MouseClick;
        }        

        private string ConfigFileName => "account.json";

        private void InitCombos()
        {
            cmbInstitutions.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBankType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbInstitutions.Items.AddRange(Utils.Institutions.ToArray());
            cmbBankType.Items.AddRange(new[] { "Checking", "Savings" });
            cmbInstitutions.SelectedIndex = 0;
            cmbBankType.SelectedIndex = 0;
        }
        private Institution GetInstitution() => cmbInstitutions.SelectedItem as Institution;
        public void SaveSettings()
        {
            Utils.StoreEncryptedObject(ConfigFileName, new Dictionary<string, string>()
            {
                {"UserName", txtUsername.Text },
                {"Password", txtPassword.Text },
                {"Institution", GetInstitution()?.DisplayName ?? string.Empty },
                {"AccountNumber", txtAccountNumber.Text },
                {"RoutingNumber", txtRoutingNo.Text },
                {"BankAccountType", cmbBankType.Text },
            });
        }
        public void LoadSettings()
        {
            if(!File.Exists(ConfigFileName)) { return; }            
            Dictionary<string, string> settings = Utils.LoadEncryptedObject<Dictionary<string, string>>(ConfigFileName);
            File.WriteAllText("backup.json", JsonConvert.SerializeObject(settings));
            if(settings?.Keys?.Count > 0)
            {
                txtUsername.Text = settings["UserName"];
                txtPassword.Text = settings["Password"];
                cmbInstitutions.Text = settings["Institution"];
                cmbBankType.Text = settings["BankAccountType"];
                txtAccountNumber.Text = settings["AccountNumber"];
                txtRoutingNo.Text = settings["RoutingNumber"];
            }
        }

        private OFXRequest BuildRequest()
        {
            Institution institution = cmbInstitutions.SelectedItem as Institution;
            return new OFXRequest(
                new OFXArgs()
                {
                    Organization = institution.Organization,
                    FinancialId = institution.FinancialId,
                    UserName = txtUsername.Text,
                    Password = txtPassword.Text,
                    StatementRequest = new BankMessageSet(AccountType.CHECKING, txtRoutingNo.Text, txtAccountNumber.Text, true)
                });
        }
        private void PerformRequest()
        {
            OFXRequest request = BuildRequest();
            OFXResponse response = OFXClient.Instance.PostRequest(request);
            FetchHandler?.Invoke(this, new FetchEventArgs(request, response));
        }
        private void BtnFetch_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                rtbRequest.Text = BuildRequest().Content;
            }
            else
            {
                PerformRequest();
            }
        }
        private void btnFetch_Click(object sender, EventArgs e)
        {
            //PerformRequest();
        }
        
    }

    public delegate void FetchEventHandler(object sender, FetchEventArgs e);
    public class FetchEventArgs : EventArgs
    {        
        public OFXRequest Request { get; }
        public OFXResponse Response { get; }
        public FetchEventArgs(OFXRequest request, OFXResponse response)
        {
            Request = request;
            Response = response;
        }
    }
}

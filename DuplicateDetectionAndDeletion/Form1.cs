using DuplicateDetectionAndDeletion.ClassLibrary.CRM;
using DuplicateDetectionAndDeletion.ClassLibrary.Models;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Windows.Forms;

namespace DuplicateDetectionAndDeletion
{
    public partial class MainForm : Form
    {
        private readonly CRMConnection _service = new CRMConnection();

        public MainForm()
        {
            InitializeComponent();
        }

        private void BtnCRMConnect_Click(object sender, EventArgs e)
        {
            CRMCredential crmCredential = new CRMCredential()
            {
                Url = "https://talentlink365dev.api.crm11.dynamics.com/XRMServices/2011/Organization.svc",  //txtUrl.Text
                UrlName = "TALENTLink",                                                              //txtSolutionName.Text
                UserName = "d365integration@advanceddynamics3.onmicrosoft.com",                             //txtUserName.Text,
                Password = "Nas30032",                                                                      //txtPassword.Text
            };

            var context = _service.EstablishCRMConnection(crmCredential);

            RetrieveCrmSkeleton retrieveCrmSkeleton = new RetrieveCrmSkeleton();
            retrieveCrmSkeleton.GetSolutions(context, crmCredential.UrlName);
            var allEntities = retrieveCrmSkeleton.GetEntityList(context);
            foreach (EntityMetadata Entity in allEntities)
            {
                cbxEntities.Items.Add(Entity.LogicalName);
            }
        }
    }
}

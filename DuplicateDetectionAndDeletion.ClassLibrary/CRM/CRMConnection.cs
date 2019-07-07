using DuplicateDetectionAndDeletion.ClassLibrary.Models;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using NLog;
using System;
using System.Net;
using System.ServiceModel.Description;

namespace DuplicateDetectionAndDeletion.ClassLibrary.CRM
{
    public class CRMConnection
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public IOrganizationService EstablishCRMConnection(CRMCredential crmCredential)
        {
            if (crmCredential == null)
            {
                _logger.Error("CRM credentials not found.");
                return null;
            }

            _logger.Info("Connecting to Dynamics 365 ..... ");

            CRMCredential credential = crmCredential;
            //CRMCredential credential = ReadCredentialDetails();

            //Connection 
            Uri organisationurl = new Uri(credential.Url);
            ClientCredentials credentials = new ClientCredentials();
            credentials.UserName.UserName = credential.UserName;
            credentials.UserName.Password = credential.Password;

            //Dyanmics 365 9.0Version DB Server protocol TLS version
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            _logger.Debug("Please wait till connection established...");

            //Creating organasition service
            OrganizationServiceProxy proxy = new OrganizationServiceProxy(organisationurl, null, credentials, null);
            proxy.EnableProxyTypes();
            IOrganizationService service = proxy;

            if (service != null)
            {
                Guid userid = ((WhoAmIResponse)service.Execute(new WhoAmIRequest())).UserId;
                if (userid != Guid.Empty)
                {
                    _logger.Info("Connection Established Succesfully");
                    //_logger.Info($"Connection Established Succesfully with user {0} in {1} environment", credential.UserName.ToUpper(), credential.UrlName.ToUpper());
                    return service;
                }
                else
                {
                    _logger.Error("Connection to Dynamics 365 Failed ... ");
                }
            }
            return null;
        }

        #region READING DETAILS

        //private CRMCredential ReadCredentialDetails()
        //{
        //    var credential = new CRMCredential();

        //    //Console.Write("\n\nPlease enter UserName: ");
        //    //credential.UserName = Console.ReadLine();

        //    //Console.Write("Please enter Password: ");
        //    //credential.Password = GetPassword().ToString();

        //    //Console.Write("\nPlease enter Organization Service URL : ");
        //    //credential.Url = Console.ReadLine();

        //    #region Existing Credentials
        //    // Credentials

        //    // Integration User
        //    credential.UserName = "d365integration@advanceddynamics3.onmicrosoft.com";
        //    credential.Password = "Nas30032";

        //    // Test User
        //    // credential.UserName = "d365testuser1@advanceddynamics3.onmicrosoft.com";
        //    // credential.Password = "Puj43915";
        //    #endregion

        //    #region Organization service URL of Environment to connect
        //    ///<summary> TALENTLink365 DEV Environment </summary>
        //    //credential.Url = "https://talentlink365dev.api.crm11.dynamics.com/XRMServices/2011/Organization.svc";
        //    //credential.UrlName = "TALENTLink365 DEV";

        //    ///<summary> TALENTLink365 TEST Environment </summary>
        //    credential.Url = "https://talentlink365test.api.crm11.dynamics.com/XRMServices/2011/Organization.svc";
        //    credential.UrlName = "TALENTLink365 TEST";
        //    #endregion

        //    return credential;
        //}

        //private SecureString GetPassword()
        //{
        //    var pwd = new SecureString();
        //    while (true)
        //    {
        //        ConsoleKeyInfo i = Console.ReadKey(true);
        //        if (i.Key == ConsoleKey.Enter)
        //        {
        //            break;
        //        }
        //        else if (i.Key == ConsoleKey.Backspace)
        //        {
        //            if (pwd.Length > 0)
        //            {
        //                pwd.RemoveAt(pwd.Length - 1);
        //                Console.Write("\b \b");
        //            }
        //        }
        //        else if (i.KeyChar != '\u0000') // KeyChar == '\u0000' if the key pressed does not correspond to a printable character, e.g. F1, Pause-Break, etc
        //        {
        //            pwd.AppendChar(i.KeyChar);
        //            Console.Write("*");
        //        }
        //    }
        //    return pwd;
        //}
        
        #endregion

    }
}
using OFX_Sandbox.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OFX_Sandbox.OFX
{
    public class OFXArgs
    {
        public string RequestTimeStr => RequestDateTime.ToString("yyyyMMddHHmmss.fff");
        public DateTime RequestDateTime { get; }
        public string UserName;
        public string Password;
        public string Organization;
        public string FinancialId;
        public StatementRequestBase StatementRequest;
        public string Endpoint => Utils.GetInstitutionEndpoint(Organization, FinancialId);
        public OFXArgs()
        {
            RequestDateTime = DateTime.Now;
        }
        public XmlDocument ToDocument()
        {
            XmlDocument doc = new XmlDocument();
            XmlNode root = doc.CreateElement("OFX");
            
            XmlNode signOnNode = (new SignOnMessageSet(RequestTimeStr, UserName, Password,
                Organization, FinancialId)).ToNode(doc);
            root.AppendChild(signOnNode);

            XmlNode transactionRequestNode = StatementRequest.ToNode(doc);
            root.AppendChild(transactionRequestNode);

            doc.AppendChild(root);
            return doc;
        }
    }    

    public class OFXRequest
    {   
        private OFXArgs Arguments { get; }
        public string Endpoint => Arguments.Endpoint;
        public string Content => ArgsToOFX(Arguments);        

        public OFXRequest(OFXArgs args)
        {
            Arguments = args;
        }        

        private string ArgsToOFX(OFXArgs args)
        {
            StringBuilder ret = new StringBuilder();
            ret.AppendLine(GenerateOFXHeader(args.RequestDateTime));
            //ret.AppendLine();
            DocToOFX(args.ToDocument().FirstChild, ret);
            string data = ret.ToString();
            //return ret.ToString();
            return data;
        }
        private void DocToOFX(XmlNode node, StringBuilder outBuilder)
        {            
            if (node.NodeType == XmlNodeType.Text) { return; }
            if (node.HasChildNodes && !node.ChildNodes.Cast<XmlNode>().All(child => child.NodeType == XmlNodeType.Text))
            {
                outBuilder.Append($"<{node.Name}>");
                foreach (XmlNode child in node.ChildNodes)
                {
                    DocToOFX(child, outBuilder);
                }
                outBuilder.Append($"</{node.Name}>"); //Close
            }
            else
            {
                if (string.IsNullOrEmpty(node.InnerText))
                {
                    outBuilder.Append($"<{node.Name}>");
                }
                else
                {
                    outBuilder.Append($"<{node.Name}>{node.InnerText}");
                }
            }
        }

        private string GenerateOFXHeader(DateTime createDate)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("OFXHEADER", "100");
            dict.Add("DATA", "OFXSGML");
            dict.Add("VERSION", "103");
            dict.Add("SECURITY", "NONE");
            dict.Add("ENCODING", "USASCII");
            dict.Add("CHARSET", "1252");
            dict.Add("COMPRESSION", "NONE");
            dict.Add("OLDFILEUID", "NONE");
            dict.Add("NEWFILEUID", createDate.ToString("yyyyMMddHHmmss.fff"));
            StringBuilder ret = new StringBuilder();
            foreach (string key in dict.Keys)
            {
                ret.Append($"{key}:{dict[key]}\n");
            }
            return ret.ToString();
        }
    }

    public static class XmlUtils
    {
        public static XmlNode AppendNode(XmlNode parent, string name, string value = null)
        {
            XmlNode ret = parent.OwnerDocument.CreateElement(name);
            ret.InnerText = value;
            parent.AppendChild(ret);
            return ret;
        }
    }

    public enum AccountType
    {
        CHECKING,
        SAVINGS
    }
    public class DTRange
    {
        public DateTime Start { get; }
        public DateTime End { get; }
        public DTRange(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }
    }
    public interface StatementRequestBase
    {
        XmlNode ToNode(XmlDocument doc);
    }

    public class BankMessageSet : StatementRequestBase //BANKMSGSRQV1
    {        
        private AccountType AccountType { get; }
        private string RoutingNumber { get; }
        private string AccountNumber { get; }
        private bool IncludeTransactions { get; }
        private DTRange Range { get; }
        public BankMessageSet(AccountType accountType, string routingNumber, string accountNumber, bool includeTransactions, DTRange range = null)
        {            
            AccountType = accountType;
            RoutingNumber = routingNumber;
            AccountNumber = accountNumber;
            IncludeTransactions = includeTransactions;
            Range = range;
        }
        public XmlNode ToNode(XmlDocument doc)
        {            
            XmlNode ret = doc.CreateElement("BANKMSGSRQV1");
            XmlNode cccsNode = XmlUtils.AppendNode(ret, "STMTTRNRQ");
            XmlUtils.AppendNode(cccsNode, "TRNUID", Utils.GetDateTimeStr());
            XmlUtils.AppendNode(cccsNode, "CLTCOOKIE", "1"); //Cargo-create (No idea if this is needed)
            XmlNode trqNode = XmlUtils.AppendNode(cccsNode, "STMTRQ");
            XmlNode acctFrom = XmlUtils.AppendNode(trqNode, "BANKACCTFROM");
            XmlUtils.AppendNode(acctFrom, "BANKID", RoutingNumber);
            XmlUtils.AppendNode(acctFrom, "ACCTID", AccountNumber);
            XmlUtils.AppendNode(acctFrom, "ACCTTYPE", "CHECKING");
            XmlNode includeTransactionNode = XmlUtils.AppendNode(trqNode, "INCTRAN");
            if(IncludeTransactions && Range != null)
            {
                XmlUtils.AppendNode(includeTransactionNode, "DTSTART", $"{Range.Start:yyyyMMdd}");
                XmlUtils.AppendNode(includeTransactionNode, "DTEND", $"{Range.End:yyyyMMdd}");
            }            
            XmlUtils.AppendNode(includeTransactionNode, "INCLUDE", IncludeTransactions ? "Y" : "N");
            return ret;            
        }
    }

    public class CreditCardMessageSet : StatementRequestBase //CREDITCARDMSGSRQV1
    {        
        private string AccountNumber { get; }
        private bool IncludeTransactions { get; }
        private DTRange Range { get; }
        public CreditCardMessageSet(string accountNumber, bool includeTransactions, DTRange range)
        {            
            AccountNumber = accountNumber;
            IncludeTransactions = includeTransactions;
            Range = range;
        }
        public XmlNode ToNode(XmlDocument doc)
        {
            XmlNode ret = doc.CreateElement("CREDITCARDMSGSRQV1");
            XmlNode ccardStmtTranQueryNode = ret.AppendChild(XmlUtils.AppendNode(ret, "CCSTMTTRNRQ"));
            XmlUtils.AppendNode(ccardStmtTranQueryNode, "TRNUID", Utils.GetDateTimeStr());
            XmlUtils.AppendNode(ccardStmtTranQueryNode, "CLTCOOKIE", "1"); //Cargo cult (No idea if this is needed)
            XmlNode ccardStmtQuery = ccardStmtTranQueryNode.AppendChild(XmlUtils.AppendNode(ccardStmtTranQueryNode, "CCSTMTRQ"));
            XmlUtils.AppendNode(ccardStmtQuery, "ACCTID", AccountNumber);
            XmlNode includeTransactionNode = XmlUtils.AppendNode(ccardStmtQuery, "INCTRAN");
            if (IncludeTransactions && Range != null)
            {
                XmlUtils.AppendNode(includeTransactionNode, "DTSTART", $"{Range.Start:yyyyMMdd}");
                XmlUtils.AppendNode(includeTransactionNode, "DTEND", $"{Range.End:yyyyMMdd}");
            }
            XmlUtils.AppendNode(includeTransactionNode, "INCLUDE", IncludeTransactions ? "Y" : "N");
            return ret;
        }
    }

    public class SignOnMessageSet //SIGNONMSGSRQV1
    {
        private string ClientDateTime { get; }
        private string UserName { get; }
        private string Password { get; }
        private string Organization { get; }
        private string FinancialId { get; }

        public SignOnMessageSet(string timeStr, string userName, string password, string organization, string financialId)
        {
            ClientDateTime = timeStr;
            UserName = userName;
            Password = password;
            Organization = organization;
            FinancialId = financialId;
        }    
        public XmlNode ToNode(XmlDocument doc)
        {
            XmlNode ret = doc.CreateElement("SIGNONMSGSRQV1");
            XmlNode sonrqNode = doc.CreateElement("SONRQ");
            XmlUtils.AppendNode(sonrqNode, "DTCLIENT", ClientDateTime);
            XmlUtils.AppendNode(sonrqNode, "USERID", UserName);
            XmlUtils.AppendNode(sonrqNode, "USERPASS", Password);
            XmlUtils.AppendNode(sonrqNode, "LANGUAGE", "ENG");
            XmlNode fiNode = XmlUtils.AppendNode(sonrqNode, "FI");
            XmlUtils.AppendNode(fiNode, "ORG", Organization);
            XmlUtils.AppendNode(fiNode, "FID", FinancialId);
            XmlUtils.AppendNode(sonrqNode, "APPID", AppUtils.AppId);
            XmlUtils.AppendNode(sonrqNode, "APPVER", AppUtils.AppVersion);
            XmlUtils.AppendNode(sonrqNode, "CLIENTUID", AppUtils.ClientUID);
            ret.AppendChild(sonrqNode);
            return ret;
        }
    }

}

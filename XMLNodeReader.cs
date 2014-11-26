using System;
using System.Xml;
using System.Xml.Linq;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using entity;

namespace XMLNodeR
{
	public class XMLNodeReader
	{
		public static List<EntryEntity> LogIn(XmlDocument xDoc, string cardNo, string accountNo) {
			List<EntryEntity> transEntries = new List<EntryEntity> ();
			XmlNodeList xList = xDoc.SelectNodes ("/Root/Row/");
			foreach(XmlNode xNode in xList) {
				if (xNode ["Card_No"].InnerText == cardNo && xNode ["Account_No"].InnerText == accountNo) {
					transEntries.Add (new EntryEntity (xNode ["Txn_ID"].InnerText, xNode ["Operation"].InnerText, xNode ["Txn_code"].InnerText,
						xNode ["Time_of_issuer_bank_ABA"].InnerText, xNode ["Time_of_acquiring_bank"].InnerText, xNode ["Approval_code"].InnerText,
						xNode ["Card_No"].InnerText, xNode ["Account_No"].InnerText, xNode ["Amount__USD"].InnerText, xNode ["Acquiring_fee_USD"].InnerText,
						xNode ["Issuer_fee__USD"].InnerText, xNode ["Amount_in_orig__currency"].InnerText, xNode ["Original_currency_of_txn"].InnerText, xNode ["Terminal_type"].InnerText,
						xNode ["Terminal_ID"].InnerText, xNode ["Merchant_category"].InnerText, xNode ["Country_of_terminal"].InnerText,
						xNode ["City_of_terminal"].InnerText, xNode ["ZIP_code"].InnerText, xNode ["Terminal_location"].InnerText,
						xNode ["Terminal_owner"].InnerText));
				}
			}
			return transEntries;
		}
	}
}


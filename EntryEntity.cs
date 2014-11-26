using System;
using System.Text;

namespace entity
{
	public class EntryEntity
	{
		string txnID, txnCode, approvalCode, amountUSD, acquiringFee, issuerFeeUSD, originCurrencyAmount, terminalID, zipCode;
		string operation, timeOfIssuer, timeOfAcquiring, cardNo, accountNo, originCurrencyType, terminalType, 
			merchCategory, terminalCountry, terminalCity, terminalLocation, terminalOwner; 

		public EntryEntity (string tempTxnID, string tempOperation, string tempTxnCode, string tempIssuerTime, string tempAcquiringTime,
			string tempApprovalCode, string tempCardNo, string tempAccountNo, string tempUSDAmount, string tempUSDAcquireFee, string tempUSDIssueFee,
			string tempOriginCurrencyAmount, string tempOriginCurrencyType, string tempTermType, string tempTermID, string tempMerchCat,
			string tempTermCountry, string tempTermCity, string tempZipCode, string tempTermLoc, string tempTermOwner)
		{
			txnID = tempTxnID;
			operation = tempOperation;
			txnCode = tempTxnCode;
			timeOfIssuer = tempIssuerTime;
			timeOfAcquiring = tempAcquiringTime;
			approvalCode = tempApprovalCode;
			cardNo = tempCardNo;
			accountNo = tempAccountNo;
			amountUSD = tempUSDAmount;
			acquiringFee = tempUSDAcquireFee;
			issuerFeeUSD = tempUSDIssueFee;
			originCurrencyAmount = tempOriginCurrencyAmount;
			originCurrencyType = tempOriginCurrencyType;
			terminalType = tempTermType;
			terminalID = tempTermID;
			merchCategory = tempMerchCat;
			terminalCountry = tempTermCountry;
			terminalCity = tempTermCity;
			zipCode = tempZipCode;
			terminalLocation = tempTermLoc;
			terminalOwner = tempTermOwner;
		}
	}
}


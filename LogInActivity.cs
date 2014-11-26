using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Data;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Text;

using entity;
using XMLNodeR;

namespace Prototype {
	[Activity (Label = "Log In", MainLauncher = true)]			
	public class LogInActivity : Activity
	{
		static readonly List<EntryEntity> entries = new List<EntryEntity> ();
		string creditCardNo = "";
		string accountNo = "";

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);


			//Set our view to the LogIn screen. This pretty puts our desired Activity to the screen.
			SetContentView (Resource.Layout.LogInActivity);

			//'Wire up' the buttons and TextFields we have in our LogIn page. We create a reference for each button on the screen so that
			//we can later on give each button functionality.
			EditText cardNoText = FindViewById<EditText> (Resource.Id.cardNoField);
			EditText accountNoText = FindViewById<EditText> (Resource.Id.accountNoField);
			Button logInButton = FindViewById<Button> (Resource.Id.logInButton);

			//Disable the login button until the Credit Card and Account Number fields.
			logInButton.Enabled = false;

			cardNoText.TextChanged += (object sender, TextChangedEventArgs e) => {
				creditCardNo = "************" + cardNoText.Text;
				if(creditCardNo.Length == 16 && accountNo.Length == 9) {
					logInButton.Enabled = true;
				} else {
					logInButton.Enabled = false;
				}
			};

			accountNoText.TextChanged += (object sender, TextChangedEventArgs e) => {
				accountNo = "*****" + accountNoText.Text;
				if(creditCardNo.Length == 16 && accountNo.Length == 9) {
					logInButton.Enabled = true;
				} else {
					logInButton.Enabled = false;
				}
			};

			logInButton.Click += (object sender, EventArgs e) => {
				int entryCount = 0;
				List<EntryEntity> entries = new List<EntryEntity>();
				XmlDocument xDoc = new XmlDocument();
				xDoc.Load(Assets.Open("Sampledata.xml"));

			};
		}
	}
}
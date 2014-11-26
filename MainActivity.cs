using System;
using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using System.Xml;
using System.Xml.Linq;
using System.Data;

using entity;
using core;
//using XMLNodeR;

namespace Prototype
{
	[Activity (Label = "Phoneword")]
	public class MainActivity : Activity
	{
		static readonly List<string> phoneNumbers = new List<string> ();

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			//Get our UI controls from the loaded layout
			EditText phoneNumberText = FindViewById<EditText> (Resource.Id.PhoneNumberText);
			Button translateButton = FindViewById<Button> (Resource.Id.TranslateButton);
			Button callButton = FindViewById<Button> (Resource.Id.CallButton);
			Button callHistoryButton = FindViewById<Button> (Resource.Id.CallHistoryButton);

			//Disable the call button
			callButton.Enabled = false;

			//Add code to the translate number
			string translatedNumber = string.Empty;

			translateButton.Click += (object sender, EventArgs args) => {
				//Translate user's alphanumeric phone number to numeric
				translatedNumber = PhoneTranslator.ToNumber (phoneNumberText.Text);
				if (String.IsNullOrWhiteSpace(translatedNumber)) {
					callButton.Text = "Cannot perform Call";
					callButton.Enabled = false;
				} else {
					callButton.Text = "Call " + translatedNumber;
					callButton.Enabled = true;
				}
			};

			callButton.Click += (object sender, EventArgs e) => {
				//On "Call" button click, try to dial the phone number
				var callDialogue = new AlertDialog.Builder(this);
				callDialogue.SetMessage("Call " + translatedNumber + "?");
				callDialogue.SetNeutralButton("Call", delegate {
					//add dialed number to list of called numbers
					phoneNumbers.Add(translatedNumber);
					//enable the callHistory button
					callHistoryButton.Enabled = true;

					//Create intent to dial phone
					var callIntent = new Intent(Intent.ActionCall);
					callIntent.SetData(Android.Net.Uri.Parse("tel:" + translatedNumber));
					StartActivity(callIntent);
				});
				callDialogue.SetNegativeButton("Cancel", delegate {});

				//Show the alert dialogue to the user and wait for response
				callDialogue.Show();
			};

			callHistoryButton.Click += (object sender, EventArgs e) => {
				var intent = new Intent(this, typeof(CallHistoryActivity));
				intent.PutStringArrayListExtra("phone_numbers", phoneNumbers);
				StartActivity(intent);
			};
		}
	}
}



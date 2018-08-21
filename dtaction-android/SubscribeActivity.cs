using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using dtaction_android.Model;
using dtaction_android.Repository;

namespace dtaction_android
{
    [Activity(Label = "InscriptionActivity")]
    public class SubscribeActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_subscribe);

            Button submit = FindViewById<Button>(Resource.Id.sub_submit);
            EditText username = FindViewById<EditText>(Resource.Id.sub_username);
            EditText email = FindViewById<EditText>(Resource.Id.sub_email);
            EditText psw = FindViewById<EditText>(Resource.Id.sub_psw);
            EditText verif = FindViewById<EditText>(Resource.Id.sub_verif);

            submit.Click += delegate {
                if (username.Text == null || username.Text == "")
                {
                    Toast.MakeText(this, "Username is required !", ToastLength.Short).Show();
                    return;
                }
                if (email.Text == null || email.Text == "" || !(Patterns.EmailAddress.Matcher(email.Text).Matches()))
                {
                    Toast.MakeText(this, "Email is required and with a valid format !", ToastLength.Short).Show();
                    return;
                }
                if (psw.Text == null || psw.Text == "")
                {
                    Toast.MakeText(this, "Password is required !", ToastLength.Short).Show();
                    return;
                }
                if (verif.Text != psw.Text)
                {
                    Toast.MakeText(this, "Your password isn't the same !", ToastLength.Short).Show();
                    return;
                }
                User usr = new User { Id = localStorage.UserCount(), Pseudo = username.Text, Email = email.Text, Psw = psw.Text, Lists = localStorage.GetDefaultProject() };
                localStorage.AddUser(usr);
                Toast.MakeText(this, "Subscribe successful, " + usr.Pseudo, ToastLength.Short).Show();
                StartActivity(new Intent(this, typeof(ProjectActivity)));
                Finish();
            };
        }
    }
}
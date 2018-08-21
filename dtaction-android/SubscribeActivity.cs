using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

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





            Button submit = FindViewById<Button>(Resource.Id.log_submit);
            EditText login = FindViewById<EditText>(Resource.Id.log_login);
            EditText password = FindViewById<EditText>(Resource.Id.log_psw);

            submit.Click += delegate {
                var usr = localStorage.FindByLoginPsw(login.Text, password.Text);
                if (usr != null)
                {
                    Toast.MakeText(this, "Login successful, " + usr.Pseudo, ToastLength.Short).Show();
                    StartActivity(new Intent(this, typeof(ProjectActivity)));
                    Finish();
                }
                else
                {
                    AlertDialog.Builder alert = new AlertDialog.Builder(this);
                    alert.SetTitle("Login fail");
                    alert.SetMessage("Login or password doesn't exist.");
                    Dialog dialog = alert.Create();
                    dialog.Show();
                }
            };
        }
    }
}
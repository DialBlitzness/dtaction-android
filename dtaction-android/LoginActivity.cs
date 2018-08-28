using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using dtaction_android.Model;
using dtaction_android.Repository;
using SQLite;

namespace dtaction_android
{
    [Activity(Label = "ConnexionActivity", Theme = "@style/Theme.AppCompat.Light")]
    public class LoginActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_login);

            Button submit = FindViewById<Button>(Resource.Id.log_submit);
            EditText login = FindViewById<EditText>(Resource.Id.log_login);
            EditText password = FindViewById<EditText>(Resource.Id.log_psw);
            login.Text = "";
            password.Text = "";

            submit.Click += async delegate {
                User usr = await localStorage.FindByLoginPsw(login.Text, password.Text);
                if (usr != null)
                {
                    Toast.MakeText(this, "Login successful, "+usr.Pseudo, ToastLength.Short).Show();
                    var activity = new Intent(this, typeof(ProjectActivity));
                    activity.PutExtra("IdUser", usr.Id);
                    StartActivity(activity);
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
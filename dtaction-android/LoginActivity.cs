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
    [Activity(Label = "ConnexionActivity")]
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

            // Il faut récupérer les users. User en dur :
            string testlogin = "Test";
            string testpassword = "Test";

            submit.Click += delegate {
                if((login.Text == testlogin) && (password.Text == testpassword))
                {
                    // Ca marche !!
                }
                else
                {
                    // Ca marche pas
                }
            };
        }
    }
}
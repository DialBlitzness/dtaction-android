using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Content;

namespace dtaction_android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Button login = FindViewById<Button>(Resource.Id.main_login);
            Button subscribe = FindViewById<Button>(Resource.Id.main_subscribe);

            login.Click += delegate {
                StartActivity(new Intent(this, typeof(LoginActivity)));
            };

            subscribe.Click += delegate {
                StartActivity(new Intent(this, typeof(SubscribeActivity)));
            };
        }
    }
}


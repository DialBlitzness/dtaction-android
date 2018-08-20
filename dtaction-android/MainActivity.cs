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

            Button connexion = FindViewById<Button>(Resource.Id.main_connexion);
            Button inscription = FindViewById<Button>(Resource.Id.main_inscription);

            connexion.Click += delegate {
                StartActivity(new Intent(this, typeof(ConnexionActivity)));
            };

            inscription.Click += delegate {
                StartActivity(new Intent(this, typeof(InscriptionActivity)));
            };
        }
    }
}


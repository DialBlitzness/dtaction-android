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
using dtaction_android.Model;

namespace dtaction_android.Repository
{
    static public class localStorage
    {
        static List<User> Users = new List<User>
        {
            new User{Id=1, Pseudo="Test", Email="Test@test.fr", Psw="Test" },
            new User{Id=2, Pseudo="Room mastah", Email="Room@mastah.fr", Psw="mdp1" },
            new User{Id=3, Pseudo="Ludo", Email="Jefous@rien.fr", Psw="mdp2" },
            new User{Id=4, Pseudo="Juju", Email="Je@galere.fr", Psw="mdp3" },
            new User{Id=5, Pseudo="Brendou", Email="Jesuisla@etcestdejabien.fr", Psw="mdp4" }
        };

        static public User FindByLoginPsw(string txt, string psw)
        {
            User result = null;
            try
            {
                result = Users.First(item => ((item.Email == txt) || (item.Pseudo == txt) && item.Psw == psw));

            }
            catch (Exception e)
            {
                Android.Util.Log.Debug("DTAction", e.ToString());
            }
            return result;
        }
    }
}
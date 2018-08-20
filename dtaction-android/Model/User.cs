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

namespace dtaction_android.Model
{
    class User
    {
        int Id { get; set; }
        string Pseudo { get; set; }
        string Email { get; set; }
        string Mdp { get; set; }
        string Url { get; set; }
        List<Liste> Listes { get; set; }

        public User()
        {
            Listes = new List<Liste>();
        }
    }
}
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
    class Liste
    {
        int Id { get; set; }
        string Titre { get; set; }
        List<Tache> Taches { get; set; }

        public Liste()
        {
            Taches = new List<Tache>();
        }
    }
}
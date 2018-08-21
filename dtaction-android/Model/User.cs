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
    public class User
    {
        public int Id { get; set; }
        public string Pseudo { get; set; }
        public string Email { get; set; }
        public string Psw { get; set; }
        public string Url { get; set; }
        public List<SingleList> Lists { get; set; }

        public User()
        {
            Lists = new List<SingleList>();
        }
    }
}
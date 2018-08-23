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
using SQLite;

namespace dtaction_android.Model
{
    [Table("User")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Pseudo { get; set; }
        public string Email { get; set; }
        public string Psw { get; set; }
        public string Url { get; set; }

        public User()
        {
        }
    }
}
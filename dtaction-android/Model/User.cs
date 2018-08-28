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
        [MaxLength(20)]
        public string Pseudo { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        public string Psw { get; set; }
        [MaxLength(250)]
        public string Img { get; set; }

        public User()
        {
        }
    }
}
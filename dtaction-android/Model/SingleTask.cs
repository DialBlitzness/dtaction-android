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
    public class SingleTask
    {
        [PrimaryKey]
        public int Id { get; set; }
        [MaxLength(200)]
        public string Content { get; set; }
        public int Position { get; set; }
        [Indexed]
        public int IdList { get; set; }
    }
}
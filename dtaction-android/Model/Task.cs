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
    public class Task
    {
        public int Id { get; set; }
        public string Content { get; set; }
    }
}
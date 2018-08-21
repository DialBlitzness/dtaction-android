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
    public class SingleList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Task> Tasks { get; set; }

        public SingleList()
        {
            Tasks = new List<Task>();
        }
    }
}
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
using dtaction_android.Repository;
using SQLite;

namespace dtaction_android.Model
{
    public class SingleList
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(40)]
        public string Title { get; set; }
        public int Position { get; set; }
        [Indexed]
        public int IdUser { get; set; }

        public SingleList()
        {
        }

        public int LastPosition()
        {
            return localStorage.GetMyTask(Id).Count + 1;
        }
    }
}
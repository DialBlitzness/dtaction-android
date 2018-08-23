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
using dtaction_android.Repository;

namespace dtaction_android
{
    [Activity(Label = "TaskActivity", Theme = "@style/Theme.AppCompat.Light")]
    public class TaskActivity : Activity
    {
        SingleTask tsk;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_task);

            bool edit = Intent.GetBooleanExtra("Edit", false);
            if(edit) {
                int tskId = Intent.GetIntExtra("Id", 0);
                tsk = localStorage.GetTask(tskId);
            }
            else
            {
                // Partie à changer pour gérer les ajouts
                tsk = new SingleTask { Content = "", SingleListId = 0 };
            }

            EditText content = FindViewById<EditText>(Resource.Id.task_content);
        }
    }
}
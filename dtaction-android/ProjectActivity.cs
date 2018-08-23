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
using dtaction_android.Helpers;
using dtaction_android.Model;
using dtaction_android.Repository;

namespace dtaction_android
{
    [Activity(Label = "ProjectActivity", Theme = "@style/Theme.AppCompat.Light")]
    public class ProjectActivity : Activity
    {
        TasksAdapter adapter;
        ListView lstTask;
        Button add;
        User usr;
        List<SingleTask> myTasks;
        List<SingleList> myLists;

        public void LoadTaskList()
        {
            myTasks = localStorage.GetMyTask(usr);
            adapter = new TasksAdapter(this, localStorage.GetMyTask(usr));
            lstTask.Adapter = adapter;
        }

        public void LoadListList()
        {
            myLists = localStorage.GetMyList(usr);
            TextView lstListTitle = FindViewById<TextView>(Resource.Id.proj_title_list);

            // Pour tester, à effacer
            lstListTitle.Text = "List n°1";
            // ajouter List adapter, et se servir de myLists
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            usr = localStorage.GetUser(Intent.GetIntExtra("IdUser", 0));
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_project);
            lstTask = FindViewById<ListView>(Resource.Id.proj_list);
            
            add = FindViewById<Button>(Resource.Id.proj_add);
            LoadListList();
            LoadTaskList();

            add.Click += delegate
            {
                var activity = new Intent(this, typeof(TaskActivity));
                activity.PutExtra("IdUser", usr.Id);
                activity.PutExtra("Edit", false);
                StartActivity(activity);
                Finish();
                LoadTaskList();
            };
        }
    }
}
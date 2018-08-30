using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Widget;
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
        TasksAdapter taskAdapter;
        ListView lstTask;
        Button add;
        User usr;
        List<SingleTask> myTasks;
        List<SingleList> myLists;

        public void LoadTaskList()
        {
            LoadListList();
            myTasks = localStorage.GetMyTask(myLists.FirstOrDefault().Id);
            taskAdapter = new TasksAdapter(this, myTasks);
            lstTask.Adapter = taskAdapter;
        }

        public async void LoadTaskCloudList()
        {
            LoadListList();
            myTasks = await localStorage.GetMyTaskCloud(myLists.FirstOrDefault().Id);
            taskAdapter = new TasksAdapter(this, myTasks);
            lstTask.Adapter = taskAdapter;
        }

        public void LoadListList()
        {
            myLists = localStorage.GetMyList(usr);
            SingleList myList = myLists.FirstOrDefault();
            
            TextView lstListTitle = FindViewById<TextView>(Resource.Id.proj_title_list);
            lstListTitle.Text = myList.Title;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            int idUser = Intent.GetIntExtra("IdUser", 0);
            usr = localStorage.GetUser(idUser);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_project);
            lstTask = FindViewById<ListView>(Resource.Id.proj_list);
            ImageView decobutton = FindViewById<ImageView>(Resource.Id.proj_img);

            add = FindViewById<Button>(Resource.Id.proj_add);
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

            SwipeRefreshLayout refresher = FindViewById<SwipeRefreshLayout>(Resource.Id.refresher);
            refresher.Refresh += delegate {
                LoadTaskCloudList();
                refresher.Refreshing = false;
            };

            decobutton.Click += delegate
            {
                var activity = new Intent(this, typeof(MainActivity));
                StartActivity(activity);
                Finish();
                LoadTaskList();
            };
        }
    }
}
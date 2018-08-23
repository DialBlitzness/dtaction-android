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
        EditText edtTask;
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

        protected override void OnCreate(Bundle savedInstanceState)
        {
            usr = localStorage.GetUser(Intent.GetIntExtra("Id", 0));
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_project);
            lstTask = FindViewById<ListView>(Resource.Id.proj_list);
            add = FindViewById<Button>(Resource.Id.proj_add);
            LoadTaskList();

            add.Click += delegate
            {
                myLists = localStorage.GetMyList(usr);
                foreach (SingleList item in myLists)
                {
                    localStorage.AddTask(
                        new SingleTask { Content = "Add successful !", SingleListId = item.Id }
                    );
                };
                LoadTaskList();
            };
        }



        /*
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Layout.activity_project_menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.proj_menu_add:
                    edtTask = new EditText(this);
                    Android.Support.V7.App.AlertDialog alertDialog = new Android.Support.V7.App.AlertDialog.Builder(this)
                        .SetTitle("Add New Task")
                        .SetMessage("What do you want to do next ?")
                        .SetView(edtTask)
                        .SetPositiveButton("Add", OkAction)
                        .SetNegativeButton("Cancel", CancelAction)
                        .Create();
                    alertDialog.Show();
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        private void CancelAction(object sender, DialogClickEventArgs e)
        {
        }
        private void OkAction(object sender, DialogClickEventArgs e)
        {
            SingleTask task = new SingleTask { Content = edtTask.Text };
            localStorage.AddTask(task);
            LoadTaskList();
        }
        */
    }
}
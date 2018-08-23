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
using Java.Lang;

namespace dtaction_android.Helpers
{
    class TasksAdapter : BaseAdapter
    {
        private ProjectActivity activity;
        private List<SingleTask> taskList;

        public TasksAdapter(ProjectActivity activity, List<SingleTask> taskList)
        {
            this.activity = activity;
            this.taskList = taskList;
        }

        public override int Count { get { return taskList.Count; } }

        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            LayoutInflater inflater = (LayoutInflater)activity.GetSystemService(Context.LayoutInflaterService);
            View view = inflater.Inflate(Resource.Layout.activity_project_task, null);
            TextView txtTask = view.FindViewById<TextView>(Resource.Id.proj_task_content);
            Button btnDelete = view.FindViewById<Button>(Resource.Id.proj_task_delete);
            txtTask.Text = taskList[position].Content;
            // A changer pour mettre la suppression des tasks sur la base de données
            btnDelete.Click += delegate
            {
                SingleTask task = taskList[position];
                localStorage.RemoveTask(task);
                activity.LoadTaskList();
            };
            view.Click += delegate
            {
                // Ca marche ! Taper du code ici
                var activity2 = new Intent(activity, typeof(TaskActivity));
                activity2.PutExtra("Id", taskList[position].Id);
                activity2.PutExtra("Edit", true);
                activity.StartActivity(activity2);
                activity.Finish();
            };
            return view;
        }
    }
}
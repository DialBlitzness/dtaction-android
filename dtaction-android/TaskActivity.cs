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
        SingleList lst;
        User usr;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_task);

            EditText content = FindViewById<EditText>(Resource.Id.task_content);
            Button submit = FindViewById<Button>(Resource.Id.task_submit);
            Button cancel = FindViewById<Button>(Resource.Id.task_cancel);
            int usrId = Intent.GetIntExtra("IdUser", 0);
            bool edit = Intent.GetBooleanExtra("Edit", false);

            if(edit) {
                int lstId = Intent.GetIntExtra("IdList", 0);
                int tskId = Intent.GetIntExtra("IdTask", 0);
                lst = localStorage.GetList(lstId);
                tsk = localStorage.GetTask(tskId);
                content.Text = tsk.Content;
            }
            else
            {
                tsk = new SingleTask { Content = "", IdList = 0 };
            }

            usr = localStorage.GetUser(usrId);

            submit.Click += async delegate
            {
                if (edit) {
                    tsk.Content = content.Text;
                    localStorage.UpdateTask(tsk);
                } else {
                    // A l'avenir, chercher la liste concernée, et ne pas rajouter à la première liste de l'user
                    List<SingleList> myLists = localStorage.GetMyList(usr);
                    await localStorage.AddTask(
                        new SingleTask { Content = content.Text, IdList = myLists.First().Id }
                    );
                }

                var activity = new Intent(this, typeof(ProjectActivity));
                activity.PutExtra("IdUser", usr.Id);
                StartActivity(activity);
                Finish();
            };

            cancel.Click += delegate
            {
                var activity = new Intent(this, typeof(ProjectActivity));
                activity.PutExtra("IdUser", usr.Id);
                StartActivity(activity);
                Finish();
            };
        }
    }
}
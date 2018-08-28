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

            submit.Click += delegate
            {
                if (edit) {
                    tsk.Content = content.Text;
                    localStorage.UpdateTask(tsk);
                } else {
                    // A l'avenir, chercher la liste concernée, et ne pas rajouter à toutes les listes de l'user
                    List<SingleList> myLists = localStorage.GetMyList(usr);
                    localStorage.AddTask(
                        new SingleTask { Content = content.Text, IdList = myLists.First().Id, Position = myLists.First().LastPosition() }
                    );
                }

                var activity = new Intent(this, typeof(ProjectActivity));
                activity.PutExtra("IdUser", usr.Id);
                StartActivity(activity);
                Finish();
            };
        }
    }
}
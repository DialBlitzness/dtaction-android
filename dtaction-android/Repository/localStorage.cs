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

namespace dtaction_android.Repository
{
    static public class localStorage
    {
        static List<User> Users = new List<User>
        {
            new User{Id=1, Pseudo="Test", Email="Test@test.fr", Psw="Test", Lists=new List<SingleList>{GetDefaultList()} },
            new User{Id=2, Pseudo="Room mastah", Email="Room@mastah.fr", Psw="mdp1", Lists=new List<SingleList>{GetDefaultList()} },
            new User{Id=3, Pseudo="Ludo", Email="Jefous@rien.fr", Psw="mdp2", Lists=new List<SingleList>{GetDefaultList()} },
            new User{Id=4, Pseudo="Juju", Email="Je@galere.fr", Psw="mdp3", Lists=new List<SingleList>{GetDefaultList()} },
            new User{Id=5, Pseudo="Brendou", Email="Jesuisla@etcestdejabien.fr", Psw="mdp4", Lists=new List<SingleList>{GetDefaultList()} }
        };

        static public User FindByLoginPsw(string txt, string psw)
        {
            User result = null;
            try
            {
                result = Users.First(item => ((item.Email == txt) || (item.Pseudo == txt) && item.Psw == psw));

            }
            catch (Exception e)
            {
                Android.Util.Log.Debug("DTAction", e.ToString());
            }
            return result;
        }

        static public int UserCount()
        {
            return Users.Count();
        }

        static public List<SingleList> GetDefaultProject()
        {
            List<SingleList> item = new List<SingleList> { GetDefaultList() };
            return item;
        }

        static public SingleList GetDefaultList()
        {
            SingleList item = new SingleList { Id = 1, Title = "ToDo1", Tasks = new List<Task> { GetDefaultTask() } };
            return item;
        }

        static public Task GetDefaultTask()
        {
            Task item = new Task { Id = 1, Content = "First task" };
            return item;
        }

        internal static bool userAlreadyExist(string mail)
        {
            bool isExist = Users.Exists(item => item.Email == mail);
            return isExist;
        }

        static public void AddUser(User item)
        {
            Users.Add(item);
        }
    }
}
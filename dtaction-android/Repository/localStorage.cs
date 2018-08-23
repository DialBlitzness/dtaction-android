using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using dtaction_android.Model;
using SQLite;

namespace dtaction_android.Repository
{
    public static class localStorage
    {
        public static string databasePath;
        public static SQLiteConnection db;

        static localStorage()
        {
            
            databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "DTActionData.db");
            db = new SQLiteConnection(databasePath);
            // CreateAllDatasForTest();
        }

        public static void AddUser(User usr)
        {
            db.Insert(usr, typeof(User));
        }

        public static void AddList(SingleList lst)
        {
            db.Insert(lst, typeof(SingleList));
        }

        public static void AddTask(SingleTask tsk)
        {
            db.Insert(tsk, typeof(SingleTask));
        }

        public static void UpdateUser(User usr)
        {
            db.Update(usr);
        }

        public static void UpdateList(SingleList lst)
        {
            db.Update(lst);
        }

        public static void UpdateTask(SingleTask tsk)
        {
            db.Update(tsk);
        }

        public static void RemoveUser(User usr)
        {
            db.Delete<User>(usr.Id);
        }

        public static void RemoveList(SingleList lst)
        {
            db.Delete<SingleList>(lst.Id);
        }

        public static void RemoveTask(SingleTask tsk)
        {
            db.Delete<SingleTask>(tsk.Id);
        }

        static public User FindByLoginPsw(string txt, string psw)
        {
            User result = db.Query<User>("select * from User where (Pseudo = ? or Email = ?) and Psw = ?", new string[3] { txt, txt, psw }).FirstOrDefault();
            return result;
        }

        static public User GetUser(int id)
        {
            return db.Get<User>(id);
        }

        static public SingleList GetList(int id)
        {
            return db.Get<SingleList>(id);
        }

        static public SingleTask GetTask(int id)
        {
            return db.Get<SingleTask>(id);
        }

        static public List<User> GetAllUser()
        {
            return db.Table<User>().ToList();
        }

        static public List<SingleList> GetAllList()
        {
            return db.Table<SingleList>().ToList();
        }

        static public List<SingleTask> GetAllTask()
        {
            return db.Table<SingleTask>().ToList();
        }

        static public List<SingleList> GetMyList(User usr)
        {
            List<SingleList> lst = db.Query<SingleList>("select * from SingleList where UserId = ?", usr.Id).ToList();
            return lst;
        }

        static public List<SingleTask> GetMyTask(User usr)
        {
            List<SingleList> lst = db.Query<SingleList>("select * from SingleList where UserId = ?", usr.Id).ToList();
            List<SingleTask> tsk = new List<SingleTask>();
            foreach(SingleList item1 in lst)
            {
                List<SingleTask> tmp = db.Query<SingleTask>("select * from SingleTask where SingleListId = ?", item1.Id).ToList();
                foreach(SingleTask item2 in tmp) { tsk.Add(item2); }
            }
            return tsk;
        }

        static public bool userAlreadyExist(string mail)
        {
            bool isExist = true;
            User result = db.Query<User>("select * from User where Email = {0}", mail).FirstOrDefault();
            if (result == null) isExist = false;
            return isExist;
        }

        static public void GetDefaultList(User usr)
        {
            db.Insert(new SingleList { Title = "ToDo1", UserId = usr.Id }, typeof(SingleList));
            db.Insert(new SingleList { Title = "In progress", UserId = usr.Id }, typeof(SingleList));
            db.Insert(new SingleList { Title = "Finish", UserId = usr.Id }, typeof(SingleList));
        }

        static public void GetDefaultTask(SingleList lst)
        {
            db.Insert(new SingleTask { Content = "First task", SingleListId = lst.Id }, typeof(SingleTask));
            db.Insert(new SingleTask { Content = "Second task", SingleListId = lst.Id }, typeof(SingleTask));
            db.Insert(new SingleTask { Content = "Third task", SingleListId = lst.Id }, typeof(SingleTask));
        }

        static public void CreateAllDatasForTest()
        {
            db.CreateTable<User>();
            db.CreateTable<SingleList>();
            db.CreateTable<SingleTask>();

            db.Insert(new User { Pseudo = "Test", Email = "Test@test.fr", Psw = "Test" }, typeof(User));
            db.Insert(new User { Pseudo = "Room mastah", Email = "Room@mastah.fr", Psw = "mdp1" }, typeof(User));
            db.Insert(new User { Pseudo = "Ludo", Email = "Jefous@rien.fr", Psw = "mdp2" }, typeof(User));
            db.Insert(new User { Pseudo = "Seppuku", Email = "Je@galere.fr", Psw = "mdp3" }, typeof(User));
            db.Insert(new User { Pseudo = "Brendou", Email = "Jesuisla@etcestdejabien.fr", Psw = "mdp4" }, typeof(User));

            db.Insert(new SingleList { Title = "ToDo1", UserId = 0 }, typeof(SingleList));
            db.Insert(new SingleList { Title = "ToDo1", UserId = 1 }, typeof(SingleList));
            db.Insert(new SingleList { Title = "ToDo1", UserId = 2 }, typeof(SingleList));
            db.Insert(new SingleList { Title = "ToDo1", UserId = 3 }, typeof(SingleList));
            db.Insert(new SingleList { Title = "ToDo1", UserId = 4 }, typeof(SingleList));

            db.Insert(new SingleTask { Content = "First task" , SingleListId = 0 }, typeof(SingleTask));
            db.Insert(new SingleTask { Content = "First task", SingleListId = 1 }, typeof(SingleTask));
            db.Insert(new SingleTask { Content = "First task", SingleListId = 2 }, typeof(SingleTask));
            db.Insert(new SingleTask { Content = "First task", SingleListId = 3 }, typeof(SingleTask));
            db.Insert(new SingleTask { Content = "First task", SingleListId = 4 }, typeof(SingleTask));

            WriteAll();
        }

        static public void WriteAll()
        {
            string result = "";
            List<User> items1 = GetAllUser();
            List<SingleList> items2 = GetAllList();
            List<SingleTask> items3 = GetAllTask();
            result += "\n --- USERS --- \n";
            foreach (User item1 in items1) { result+= "User n°" + item1.Id + " - " + item1.Pseudo+"\n"; }
            result += "\n --- LISTES --- \n";
            foreach (SingleList item2 in items2) { result+= item2.Title + " - User n°" + item2.UserId + "\n"; }
            result += "\n --- TASKS --- \n";
            foreach (SingleTask item3 in items3) { result += item3.Content+ " - Listes n°" + item3.SingleListId + "\n"; }
            Console.WriteLine(result);
        }
    }
}
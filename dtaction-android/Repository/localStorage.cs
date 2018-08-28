using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using dtaction_android.Model;
using Newtonsoft.Json;
using SQLite;

namespace dtaction_android.Repository
{
    public static class localStorage
    {
        public static string databasePath;
        public static SQLiteConnection db;

        static localStorage()
        {
            databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "DTActionData3.db");
            db = new SQLiteConnection(databasePath);

            // Test en ligne avec web api
            if (CheckInternet()) { cloudStorage.refresh(); }

            // Test en local
            /*
            CreateAllDatasForTest();
            WriteAll();
            */
        }

        public static async void AddUser(User usr)
        {
            db.Insert(usr, typeof(User));
            if (CheckInternet())
            {
                using (HttpClient webAPI = new HttpClient())
                {
                    webAPI.MaxResponseContentBufferSize = 256000;
                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(usr);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response;
                    try
                    {
                        response = await webAPI.PostAsync("http://dtaction.azurewebsites.net/api/user", content);
                    }
                    catch (Exception err)
                    {
                        string sHold = err.Message;
                        throw;
                    }
                }
            }
        }

        public static async void AddList(SingleList lst)
        {
            db.Insert(lst, typeof(SingleList));
            if (CheckInternet())
            {
                using (HttpClient webAPI = new HttpClient())
                {
                    webAPI.MaxResponseContentBufferSize = 256000;
                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(lst);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response;
                    try
                    {
                        response = await webAPI.PostAsync("http://dtaction.azurewebsites.net/api/list", content);
                    }
                    catch (Exception err)
                    {
                        string sHold = err.Message;
                        throw;
                    }
                }
            }
        }

        public static async void AddTask(SingleTask tsk)
        {
            db.Insert(tsk, typeof(SingleTask));
            if (CheckInternet())
            {
                using (HttpClient webAPI = new HttpClient())
                {
                    webAPI.MaxResponseContentBufferSize = 256000;
                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(tsk);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response;
                    try
                    {
                        response = await webAPI.PostAsync("http://dtaction.azurewebsites.net/api/task", content);
                    }
                    catch (Exception err)
                    {
                        string sHold = err.Message;
                        throw;
                    }
                }
            }
        }

        internal static void CreateAllObjects(List<User> users, List<SingleList> lists, List<SingleTask> tasks)
        {
            foreach (User item in users) { db.Insert(item, typeof(User)); }
            foreach (SingleList item in lists) { db.Insert(item, typeof(SingleList)); }
            foreach (SingleTask item in tasks) { db.Insert(item, typeof(SingleTask)); }
        }

        public static async void UpdateUser(User usr)
        {
            db.Update(usr);
            if (CheckInternet())
            {
                using (HttpClient webAPI = new HttpClient())
                {
                    webAPI.MaxResponseContentBufferSize = 256000;
                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(usr);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response;
                    try
                    {
                        response = await webAPI.PutAsync("http://dtaction.azurewebsites.net/api/user/" + usr.Id, content);
                    }
                    catch (Exception err)
                    {
                        string sHold = err.Message;
                        throw;
                    }
                }
            }
        }

        public static async void UpdateList(SingleList lst)
        {
            db.Update(lst);
            if (CheckInternet())
            {
                using (HttpClient webAPI = new HttpClient())
                {
                    webAPI.MaxResponseContentBufferSize = 256000;
                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(lst);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response;
                    try
                    {
                        response = await webAPI.PutAsync("http://dtaction.azurewebsites.net/api/list/" + lst.Id, content);
                    }
                    catch (Exception err)
                    {
                        string sHold = err.Message;
                        throw;
                    }
                }
            }
        }

        public static async void UpdateTask(SingleTask tsk)
        {
            db.Update(tsk);
            if (CheckInternet())
            {
                using (HttpClient webAPI = new HttpClient())
                {
                    webAPI.MaxResponseContentBufferSize = 256000;
                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(tsk);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response;
                    try
                    {
                        response = await webAPI.PutAsync("http://dtaction.azurewebsites.net/api/task/" + tsk.Id, content);
                    }
                    catch (Exception err)
                    {
                        string sHold = err.Message;
                        throw;
                    }
                }
            }
        }

        public static async void RemoveUser(User usr)
        {
            db.Delete<User>(usr.Id);
            if (CheckInternet())
            {
                using (HttpClient webAPI = new HttpClient())
                {
                    webAPI.MaxResponseContentBufferSize = 256000;
                    HttpResponseMessage response;
                    try
                    {
                        response = await webAPI.DeleteAsync("http://dtaction.azurewebsites.net/api/user/" + usr.Id);
                    }
                    catch (Exception err)
                    {
                        string sHold = err.Message;
                        throw;
                    }
                }
            }
        }

        public static async void RemoveList(SingleList lst)
        {
            db.Delete<SingleList>(lst.Id);
            if (CheckInternet())
            {
                using (HttpClient webAPI = new HttpClient())
                {
                    webAPI.MaxResponseContentBufferSize = 256000;
                    HttpResponseMessage response;
                    try
                    {
                        response = await webAPI.DeleteAsync("http://dtaction.azurewebsites.net/api/list/" + lst.Id);
                    }
                    catch (Exception err)
                    {
                        string sHold = err.Message;
                        throw;
                    }
                }
            }

        }

        public static async void RemoveTask(SingleTask tsk)
        {
            db.Delete<SingleTask>(tsk.Id);
            if (CheckInternet())
            {
                using (HttpClient webAPI = new HttpClient())
                {
                    webAPI.MaxResponseContentBufferSize = 256000;
                    HttpResponseMessage response;
                    try
                    {
                        response = await webAPI.DeleteAsync("http://dtaction.azurewebsites.net/api/task/" + tsk.Id);
                    }
                    catch (Exception err)
                    {
                        string sHold = err.Message;
                        throw;
                    }
                }
            }
        }

        static public User FindByLoginPsw(string txt, string psw)
        {
            if (CheckInternet()) { cloudStorage.refresh(); }
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
            if ((db.Query<SingleList>("select * from SingleList where IdUser = ?", usr.Id).FirstOrDefault()) == null) { AddList(new SingleList { Title = "ToDo1", IdUser = usr.Id }); };
            List<SingleList> lst = db.Query<SingleList>("select * from SingleList where IdUser = ?", usr.Id).ToList();
            return lst;
        }

        static public List<SingleTask> GetMyTask(User usr)
        {
            List<SingleList> lst = db.Query<SingleList>("select * from SingleList where IdUser = ?", usr.Id).ToList();
            List<SingleTask> tsk = new List<SingleTask>();
            foreach(SingleList item1 in lst)
            {
                List<SingleTask> tmp = db.Query<SingleTask>("select * from SingleTask where IdList = ?", item1.Id).ToList();
                foreach(SingleTask item2 in tmp) { tsk.Add(item2); }
            }
            return tsk;
        }

        static public List<SingleTask> GetMyTask(SingleList lst)
        {
            if ((db.Query<SingleTask>("select * from SingleTask where IdList = ?", lst.Id).FirstOrDefault()) == null) { AddTask(new SingleTask { Content = "First task", IdList = lst.Id }); };
            List<SingleTask> tsk = db.Query<SingleTask>("select * from SingleTask where IdList = ?", lst.Id).ToList();
            return tsk;
        }

        static public List<SingleTask> GetMyTask(int lstId)
        {
            if ((db.Query<SingleTask>("select * from SingleTask where IdList = ?", lstId).FirstOrDefault()) == null) { AddTask(new SingleTask { Content = "First task", IdList = lstId }); };
            List<SingleTask> tsk = db.Query<SingleTask>("select * from SingleTask where IdList = ?", lstId).ToList();
            return tsk;
        }

        static public bool userAlreadyExist(string mail)
        {
            bool isExist = true;
            User result = db.Query<User>("select * from User where Email = ?", mail).FirstOrDefault();
            if (result == null) isExist = false;
            return isExist;
        }

        static public void GetDefaultList(User usr)
        {
            db.Insert(new SingleList { Title = "ToDo1", IdUser = usr.Id }, typeof(SingleList));
            db.Insert(new SingleList { Title = "In progress", IdUser = usr.Id }, typeof(SingleList));
            db.Insert(new SingleList { Title = "Finish", IdUser = usr.Id }, typeof(SingleList));
        }

        static public void GetDefaultTask(SingleList lst)
        {
            db.Insert(new SingleTask { Content = "First task", IdList = lst.Id }, typeof(SingleTask));
            db.Insert(new SingleTask { Content = "Second task", IdList = lst.Id }, typeof(SingleTask));
            db.Insert(new SingleTask { Content = "Third task", IdList = lst.Id }, typeof(SingleTask));
        }

        static public void CreateAllDatasForTest()
        {
            DeleteAllTables();
            CreateAllTables();

            db.Insert(new User { Pseudo = "Test", Email = "Test@test.fr", Psw = "Test" }, typeof(User));
            db.Insert(new User { Pseudo = "Room mastah", Email = "Room@mastah.fr", Psw = "mdp1" }, typeof(User));
            db.Insert(new User { Pseudo = "Ludo", Email = "Jefous@rien.fr", Psw = "mdp2" }, typeof(User));
            db.Insert(new User { Pseudo = "Seppuku", Email = "Je@galere.fr", Psw = "mdp3" }, typeof(User));
            db.Insert(new User { Pseudo = "Brendou", Email = "Jesuisla@etcestdejabien.fr", Psw = "mdp4" }, typeof(User));

            db.Insert(new SingleList { Title = "ToDo1", IdUser = 1 }, typeof(SingleList));
            db.Insert(new SingleList { Title = "ToDo1", IdUser = 2 }, typeof(SingleList));
            db.Insert(new SingleList { Title = "ToDo1", IdUser = 3 }, typeof(SingleList));
            db.Insert(new SingleList { Title = "ToDo1", IdUser = 4 }, typeof(SingleList));
            db.Insert(new SingleList { Title = "ToDo1", IdUser = 5 }, typeof(SingleList));

            db.Insert(new SingleTask { Content = "First task" , IdList = 1, Position = 1 }, typeof(SingleTask));
            db.Insert(new SingleTask { Content = "Second task", IdList = 1, Position = 2 }, typeof(SingleTask));
            db.Insert(new SingleTask { Content = "Third task", IdList = 1, Position = 3 }, typeof(SingleTask));
            db.Insert(new SingleTask { Content = "First task", IdList = 2 }, typeof(SingleTask));
            db.Insert(new SingleTask { Content = "First task", IdList = 3 }, typeof(SingleTask));
            db.Insert(new SingleTask { Content = "First task", IdList = 4 }, typeof(SingleTask));
            db.Insert(new SingleTask { Content = "First task", IdList = 5 }, typeof(SingleTask));

            WriteAll();
        }

        static public void DeleteAllTables()
        {
            db.DropTable<SingleTask>();
            db.DropTable<SingleList>();
            db.DropTable<User>();
        }

        static public void CreateAllTables()
        {
            db.CreateTable<User>();
            db.CreateTable<SingleList>();
            db.CreateTable<SingleTask>();
        }

        static public void WriteAll()
        {
            string result = "----->>>> DANS LOCALSTORAGE\n";
            List<User> items1 = GetAllUser();
            List<SingleList> items2 = GetAllList();
            List<SingleTask> items3 = GetAllTask();
            System.Threading.Thread.Sleep(200);
            result += "\n --- USERS --- \n";
            foreach (User item1 in items1) { result += "(User) Id:" + item1.Id + " - Pseudo:" + item1.Pseudo + " - Email:" + item1.Email + " - Psw:" + item1.Psw + "\n"; }
            result += "\n --- LISTES --- \n";
            foreach (SingleList item2 in items2) { result += "(Liste) Id:" + item2.Id + " - Title:" + item2.Title + " - UserId:" + item2.IdUser + " - Position:" + item2.Position + "\n"; }
            result += "\n --- TASKS --- \n";
            foreach (SingleTask item3 in items3) { result += "(Task) Id:" + item3.Id + " - Content:" + item3.Content + " - ListId:" + item3.IdList + " - Position:" + item3.Position + "\n"; }
            Console.WriteLine(result);
        }

        static public bool CheckInternet()
        {
            string CheckUrl = "http://google.com";
            try
            {
                HttpWebRequest iNetRequest = (HttpWebRequest)WebRequest.Create(CheckUrl);
                iNetRequest.Timeout = 5000;
                WebResponse iNetResponse = iNetRequest.GetResponse();
                iNetResponse.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
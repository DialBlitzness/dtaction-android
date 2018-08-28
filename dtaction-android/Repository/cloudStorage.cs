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
using System.Net.Http;
using Newtonsoft.Json;
using dtaction_android.Model;
using System.Net;
using System.Threading.Tasks;

namespace dtaction_android.Repository
{
    public static class cloudStorage
    {
        public static List<SingleTask> tasks;
        public static List<SingleList> lists;
        public static List<User> users;

        public static async void refresh()
        {
            using (var client = new HttpClient())
            {
                string result;
                // tout récupérer avec des GET 
                result = await client.GetStringAsync("http://dtaction.azurewebsites.net/api/task");
                tasks = JsonConvert.DeserializeObject<List<SingleTask>>(result);

                result = await client.GetStringAsync("http://dtaction.azurewebsites.net/api/list");
                lists = JsonConvert.DeserializeObject<List<SingleList>>(result);

                result = await client.GetStringAsync("http://dtaction.azurewebsites.net/api/user");
                users = JsonConvert.DeserializeObject<List<User>>(result);

                // Puis traitement SQLite en local
                localStorage.DeleteAllTables();
                localStorage.CreateAllTables();
                localStorage.CreateAllObjects(users, lists, tasks);
                localStorage.WriteAll();
            }
        }

        static public void WriteAll()
        {
            System.Threading.Thread.Sleep(200);
            string result = "----->>>> DANS CLOUDSTORAGE\n";
            result += "\n --- USERS --- \n";
            foreach (User item1 in users) { result += "(User) Id:" + item1.Id + " - Pseudo:" + item1.Pseudo + " - Email:"+ item1.Email +" - Psw:"+ item1.Psw +"\n"; }
            result += "\n --- LISTES --- \n";
            foreach (SingleList item2 in lists) { result += "(Liste) Id:" + item2.Id + " - Title:" + item2.Title + " - UserId:" + item2.IdUser + " - Position:"+ item2.Position +"\n"; }
            result += "\n --- TASKS --- \n";
            foreach (SingleTask item3 in tasks) { result += "(Task) Id:" + item3.Id + " - Content:" + item3.Content + " - ListId:" + item3.IdList +" - Position:"+ item3.Position+ "\n"; }
            Console.WriteLine(result);
        }
    }
}
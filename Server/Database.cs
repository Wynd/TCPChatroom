using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Database
    {

        public static Database instance = new Database();

        public string PATH_DATA = "data/";
        public string PATH_ACCOUNT = "accounts/";
        public string PATH_CHATROOM = "chatroom/";

        public string FILE_EXTENSION = ".bin";

        public void CheckPath(string folder)
        {
            Console.WriteLine("Checking: .../" + PATH_DATA + folder);

            if (!Directory.Exists(PATH_DATA + folder))
                Directory.CreateDirectory(PATH_DATA + folder);
        }

        #region "Account Auth"
        public bool AccountExists(string name)
        {
            if (!File.Exists(PATH_DATA + PATH_ACCOUNT + name + FILE_EXTENSION))
                return false;
            else
                return true;
        }

        public void AddNewAccount(int clientIndex, string username, string password)
        {
            Network.users[clientIndex].username = username;
            Network.users[clientIndex].password = password;

            SavePlayer(clientIndex);
            Console.WriteLine("Account: '" + username + "' has been created.");
        }

        public void SavePlayer(int clientIndex)
        {
            System.IO.Stream stream = File.Open(PATH_DATA + PATH_ACCOUNT + "/" + Network.users[clientIndex].username + FILE_EXTENSION, FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(stream, Network.users[clientIndex]);
            stream.Close();
        }


        public void LoadPlayer(int clientIndex, string username)
        {
            System.IO.Stream stream = File.Open(PATH_DATA + PATH_ACCOUNT + "/" + username + FILE_EXTENSION, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();

            Network.users[clientIndex] = null;
            Network.users[clientIndex] = (User)bf.Deserialize(stream);
            stream.Close();

            Console.WriteLine(Network.users[clientIndex].username + " has joined as a registered user !");
            //ServerSendData.instance.SendSpawn(clientIndex);
        }

        public bool CheckPassword(string name, string password)
        {
            System.IO.Stream stream = File.Open(PATH_DATA + PATH_ACCOUNT + "/" + name + FILE_EXTENSION, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            var user = (User)bf.Deserialize(stream);

            if (user.password == password)
            {
                stream.Close();
                return true;
            }
            else
            {
                stream.Close();
                return false;
            }
        }
        #endregion
    }
}

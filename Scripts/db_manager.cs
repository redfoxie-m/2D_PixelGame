using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class db_manager : MonoBehaviour
{
    IDbCommand dbcmd;
    IDbConnection dbcon;
    public Text Username_field;
    public Text Userpassword_field;
    public Text smth_wrong;
    string user_name;
    public Transform box;



    void Start()
	{
		// Create database
		string connection = "URI=file:" + Application.persistentDataPath + "/" + "My_Database";

        // Open connection
        dbcon = new SqliteConnection(connection);
		dbcon.Open();

		// Create table
		
		dbcmd = dbcon.CreateCommand();
		string q_createTable = "CREATE TABLE IF NOT EXISTS users (id INTEGER PRIMARY KEY, name VARCHAR(50) UNIQUE, password VARCHAR(50) UNIQUE,level_completed INTEGER DEFAULT 0,num_of_food integer default 0)";

		dbcmd.CommandText = q_createTable;
		dbcmd.ExecuteReader();
        dbcon.Close();
    }
    private  void wrong_format()
    {
        box.LeanMoveY(8.0f, 2.0f).setEaseOutExpo().delay = 0.1f;
    }
    public void add_new_user()
    {
        dbcon.Open();
        string name = Username_field.text.ToString();
        string password = Userpassword_field.text.ToString();
        if (name!="" && password!="")
        {
            IDbCommand cmnd = dbcon.CreateCommand();
            cmnd.CommandText = "INSERT INTO users (name,password) VALUES('" + name + "',+'" + password + "')";
            User.name = name;
            User.level_compleeted = 0;
            User.num_of_food = 0;

            cmnd.ExecuteNonQuery();
            SceneManager.LoadScene(5);
        }
        else
        {
            smth_wrong.text = "Wrong format";
            wrong_format();
        }
        dbcon.Close();
    }

    public void read_table()
    {
        dbcon.Open();
        string name = Username_field.text.ToString();
        string password = Userpassword_field.text.ToString();
        if (name != "" && password != "")
        {
            IDbCommand cmnd_read = dbcon.CreateCommand();
            IDataReader reader;
            string query = "SELECT * FROM users WHERE name ='" + name + "' and password='" + password + "'";
            cmnd_read.CommandText = query;
            reader = cmnd_read.ExecuteReader();
            bool f =true;
            while (reader.Read())
            {
                f = false;
                User.name = reader[1].ToString();
            
                User.level_compleeted = Int32.Parse(reader[3].ToString());
                User.num_of_food = Int32.Parse(reader[4].ToString());
                //User. = reader.GetInt32(3);
                SceneManager.LoadScene(5);
            }

            if (f) {
                smth_wrong.text = "No such account";
                wrong_format(); 
            }


        }
        else
        {
            smth_wrong.text = "Wrong format";
            wrong_format();
        }
        dbcon.Close();
    }

    void Update()
	{

	}
}
public static class User
{
    public static string name ="";
    public static int level_compleeted;
    public static int num_of_food;
    static string connection = "URI=file:" + Application.persistentDataPath + "/" + "My_Database";

    public static void modify_food_count(int num)
    {
        
        IDbConnection dbcon = new SqliteConnection(connection);
        dbcon.Open();
        Debug.Log(User.num_of_food + num);
        if (User.num_of_food+num < 20)
        {

            IDbCommand cmnd = dbcon.CreateCommand();
            
            cmnd.CommandText = string.Format("UPDATE users SET num_of_food = {0} WHERE name='{1}'", User.num_of_food+num, User.name);
            cmnd.ExecuteNonQuery();
            User.num_of_food += num;
        }
        else
        {
            IDbCommand cmnd = dbcon.CreateCommand();
            cmnd.CommandText = string.Format("UPDATE users SET num_of_food = {0} WHERE name='{1}'", 20, User.name);
            cmnd.ExecuteNonQuery();
            User.num_of_food =20;
        }
        dbcon.Close();
    }
    public static void modify_level_count()
    {
        IDbConnection dbcon = new SqliteConnection(connection);
        IDbCommand cmnd = dbcon.CreateCommand();
        dbcon.Open();
        if (User.level_compleeted != 3)
        {
            string connection = "URI=file:" + Application.persistentDataPath + "/" + "My_Database";

            cmnd.CommandText = string.Format("UPDATE users SET level_completed = {0} WHERE name='{1}'", User.level_compleeted+=1, User.name);
            cmnd.ExecuteNonQuery();
            User.level_compleeted += 1;
        }
        dbcon.Close();
    }


}
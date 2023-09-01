using Mono.Data.Sqlite;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    IDbConnection dbcon;
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        string connection = "URI=file:" + Application.persistentDataPath + "/" + "My_Database";

        // Open connection
        dbcon = new SqliteConnection(connection);
        dbcon.Close();
        Application.Quit();
    }
}

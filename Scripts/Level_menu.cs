using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level_menu : MonoBehaviour
{
    public Button level2;
    public Button level3;
    public void Awake()
    {
        control_level_menu();
    }
    public void Back_to_menu()
    {
        SceneManager.LoadScene(0);
    }
    public void level_menu()
    {
        SceneManager.LoadScene(1);
    }
    public void Level1()
    {
        SceneManager.LoadScene(2);
    }
    public void Level2()
    {
        SceneManager.LoadScene(3);
    }
    public void Level3()
    {
       SceneManager.LoadScene(4);
    }
    public void account_info()
    {
        SceneManager.LoadScene(5);
    }
    public void account()
    {
        SceneManager.LoadScene(6);
    }
    public void control_level_menu()
    {
        if (User.name !="")
        {
            switch (User.level_compleeted)
            {
                case 0:
                    level2.enabled = false;
                    level3.enabled = false;
                    break;
                case 1:
                    level2.enabled = true;
                    level3.enabled = false;
                    break;
                case 2:
                    level2.enabled = true;
                    level3.enabled = true;
                    break;
            }
        }
        else
        {
            level2.enabled = false;
            level3.enabled = false;
        }
     /*  */
    }
    public void Exit() { Application.Quit(); }
}

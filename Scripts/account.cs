using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class account : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Back_to_menu()
    {
        SceneManager.LoadScene(0);
    }
    public void level_menu()
    {
        SceneManager.LoadScene(1);
    }

    public void account_info()
    {
        SceneManager.LoadScene(5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

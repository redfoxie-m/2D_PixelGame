using UnityEngine;
using UnityEngine.SceneManagement;

public class little_menu : MonoBehaviour
{
    public Transform box;
    private float y_pos;
    private bool f = true;
    public Animator animators;
    public GameObject hero1;
    public GameObject hero2;
    public int num1;


    void StopAnimation()
    {
    }
    void StartAnimation()
    {

    }
    public void winner()
    {
        if (User.name != "")
        {
            int num = hero1.GetComponent<fish_coolect>().fish + hero2.GetComponent<fish_coolect>().fish;
            Debug.Log(num);
            User.modify_food_count(num);
            if (User.level_compleeted == num1 - 1)
            {
                User.modify_level_count();
            }
        }


    }
    public void Awake()
    {
        y_pos = box.transform.position.y;
    }
    public void Check()
    {
        if (f)
        {
            OnEnable_1();
            StopAnimation();
            f = false;
        }
        else 
        { 
            CloseDialog();
            StartAnimation();
            f = true;
        }
    }
    private void OnEnable_1()
    {
        box.LeanMoveY(4.0f, 2.0f).setEaseOutExpo().delay = 0.1f;
    }
    public void Close1Dialog()
    {
        box.LeanMoveY(y_pos, 2.0f).setEaseOutExpo().delay = 0.1f;
    }
    private void CloseDialog()
    {
        box.LeanMoveY(y_pos, 2.0f).setEaseOutExpo().delay = 0.1f;
    }
    public void Retry_level()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Back_to_menu()
    {
        SceneManager.LoadScene(1);
    }
    public void Back_to_menu_winner()
    {
        winner();
        SceneManager.LoadScene(1);

    }

}

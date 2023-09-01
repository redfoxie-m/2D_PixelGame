using UnityEngine;

public class level_control : MonoBehaviour
{
    // Update is called once per frame
    public Transform box;

    void Update()
    {
        if(GameObject.Find("lava_door").GetComponent<door_controller>().open && GameObject.Find("water_door").GetComponent<door_controller>().open)
        {
            box.LeanMoveY(3.0f, 2.0f).setEaseOutExpo().delay = 0.1f;

            
        }
        
        
    }
}

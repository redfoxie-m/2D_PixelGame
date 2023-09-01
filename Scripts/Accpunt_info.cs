using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Accpunt_info : MonoBehaviour

{
    public Text Username_field;
    public Text level_field;
    public Text food_field;
    // Start is called before the first frame update
    void Start()
    {
        Username_field.text = User.name;
        level_field.text = User.level_compleeted.ToString() ;
        food_field.text = User.num_of_food.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

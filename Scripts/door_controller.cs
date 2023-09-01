using UnityEngine;

public class door_controller : MonoBehaviour
{
    // Start is called before the first frame
    public string tag_name;
    public bool open=false;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tag_name)
        {
            open = true;
            anim.SetBool("open", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tag_name)
        {
            open = false;
            anim.SetBool("open", false);
        }
    }
}

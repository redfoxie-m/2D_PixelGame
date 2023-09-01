using UnityEngine;
using UnityEngine.UI;

public class fish_coolect : MonoBehaviour
{
    public int fish = 0;
    public string tag_name;
    public  Image m_Image_1;
    public Image m_Image_2;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tag_name)
        {
            Destroy(collision.gameObject);
            fish++;
            m_Image_1.GetComponent<Image>().sprite = Resources.Load<Sprite>(fish.ToString());
            m_Image_2.GetComponent<Image>().sprite = Resources.Load<Sprite>(fish.ToString());
        }
    }
}

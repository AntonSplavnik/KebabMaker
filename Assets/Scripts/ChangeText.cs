using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    public Text text;
    private float collisionStartTime;
    private bool isCollision = false;

    void OnCollisionEnter2D(Collision2D coll)
    {
        isCollision = true;
        if (coll.gameObject.CompareTag("Salad"))
        {
            text.text = "Salad is ready!";
            collisionStartTime = Time.time;
        }
    }
    // void OnCollisionExit2D(Collision2D coll)
    // {
    //     isCollision = false;
    //     Debug.Log("exit!");
    // }
    void Update()
    {
        if (isCollision && Time.time - collisionStartTime > 3f)
        {
            Debug.Log("You did it!");
            isCollision = false;
        }
    }
}

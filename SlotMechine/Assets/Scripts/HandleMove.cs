
using UnityEngine;

public class HandleMove : MonoBehaviour
{
    //For handle animation
    public void pullDown()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x,gameObject.transform.position.y - 2.4f);
    }
    public void pushUp()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 2.4f);
    }
}

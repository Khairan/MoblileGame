using UnityEngine;


public class FollowCursorView : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = false;
    }
    
    void Update()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = pos;
    }
}

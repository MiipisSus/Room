using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickonObjects : MonoBehaviour
{
    public GameObject talkUI;
    public Texture2D cursor1;
    void OnMouseDown()
    {
                DialougeSystem.Text_name = this.name;
                    
                talkUI.SetActive(true);
    }
    void OnMouseOver()
    {
        Cursor.SetCursor(cursor1, Vector2.zero, CursorMode.Auto);
    }
    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
    void PuzzleEvent(int id)
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameStart : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject talkUI;
    public GameObject sprite;
    public GameObject start_panel;
    public Texture2D cursor1;

    void Start()
    {
        if (Screen.fullScreen)
            Screen.fullScreen = false;
        Cursor.visible = true;
    }
    void OnMouseDown()
    {
        DialougeSystem.Text_name = "start";
        talkUI.SetActive(true);
        sprite.SetActive(true);
        start_panel.SetActive(false);
    }
    void OnMouseOver()
    {
        Cursor.SetCursor(cursor1, Vector2.zero, CursorMode.Auto);
    }
    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}

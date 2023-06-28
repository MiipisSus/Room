using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickonDialouge : MonoBehaviour
{
    public Texture2D cursor1;
    public GameObject[] d = new GameObject[3];
    public int r_state;
    void OnMouseDown()
    {
        DialougeSystem.Text_name = this.name;
        DialougeSystem.Dec_response = DialougeSystem.textList[DialougeSystem.index].Split('/');
        DialougeSystem.textList[DialougeSystem.index] = DialougeSystem.Dec_response[r_state];
        DialougeSystem.Dialouge_State = false;
        for (int i=0;i<3;i++)
            d[i].SetActive(false);
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

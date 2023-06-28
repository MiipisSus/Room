using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinished : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject talkUI;
    public GameObject sprite;
    void Start()
    {
        DialougeSystem.Text_name = "Finish";
        talkUI.SetActive(true);
        sprite.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

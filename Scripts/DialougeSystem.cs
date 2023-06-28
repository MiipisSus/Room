using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialougeSystem : MonoBehaviour
{
    [Header("UI介面")]
    public Text textLabel;
    public Text d1, d2, d3;
    public GameObject codePanel;
    public Image imageLabel;
    public GameObject sprite;
    public GameObject gameOver;

    [Header("文本")]
    public TextAsset textFile;
    public static string Text_name;
    public static int index;
    public float textSpeed;
    public int event_id;    //0:sofa, 1:cabinet
    public Sprite s1, s2;
    public static string[] Dec_response = new string[3];

    bool textFinished = true;
    public static bool Dialouge_State = false;
    public static bool Code_State = false;
    bool cancelTyping;
    bool Loaded = false;
    bool GameFinished = false;
    public static bool psd = false;

    [Header("選項")]
    public GameObject[] Dialouge = new GameObject[3];

    public static List<string> textList = new List<string>();

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(!Loaded)
        {
            textFile = Resources.Load(Text_name) as TextAsset;
            GetTextFromFile(textFile);
            Loaded = true;
        }
        if (Input.GetButtonDown("Fire1") && index == textList.Count)
        {

            if (GameFinished)
            {
                GameFinished = false;
                sprite.SetActive(true);
                index = 0;
                textFile = Resources.Load("Finish") as TextAsset;
                GetTextFromFile(textFile);
            }
            else
            {
                gameObject.SetActive(false);
                sprite.SetActive(false);
                index = 0;
                Loaded = false;
                return;
            }         

        }
        if (Input.GetButtonDown("Fire1")) 
        {
            if (textFinished && !cancelTyping&&!Dialouge_State&&!Code_State) 
            {
                StartCoroutine(setTextUI());
            }
            else if(!textFinished)
            {
                cancelTyping = !cancelTyping;
            }
        }
    }
    void GetTextFromFile(TextAsset file)
    {
        textList.Clear();
        index = 0;

        var lineDate=file.text.Split('\n');
        foreach(var line in lineDate)
        {
            textList.Add(line);
        }
    }
    IEnumerator setTextUI()
    {
        textFinished = false;
        textLabel.text = "";
        
        switch(textList[index].Trim().ToString())
        {
            case "S_a":
                imageLabel.sprite = s1;
                index++;
                break;
            case "S_b":
                imageLabel.sprite = s2;
                index++;
                break;
            case "[Dec_key]":
                index++;
                Dec_response = textList[index].Split('/');
                if (GetObjectEvent.iron_key)
                {                  
                    textList[index] = Dec_response[0];
                    GetObjectEvent.milk = true;
                }
                else
                    textList[index] = Dec_response[1];
                break;
            case "[Dec_milk]":
                index++;
                Dec_response = textList[index].Split('/');
                if (!GetObjectEvent.milk)
                {
                    index += 4;
                }
                break;
            case "[Dec_doorkey]":
                index++;
                Dec_response = textList[index].Split('/');
                if (GetObjectEvent.door_key)
                {
                    textList[index] = Dec_response[0];
                    GameFinished = true;
                }
                else
                    textList[index] = Dec_response[1];
                break;
            case "[Get_key]":
                GetObjectEvent.iron_key = true;
                index++;
                break;
            case "[Get_doorKey]":
                index++;
                Dec_response = textList[index].Split('/');
                if (psd)
                {
                    textList[index] = Dec_response[0];
                    GetObjectEvent.door_key = true;
                }
                else
                    textList[index] = Dec_response[1];
                break;
            case "[D_3]":
                Dialouge[0].SetActive(true);
                Dialouge[1].SetActive(true);
                Dialouge[2].SetActive(true);
                Dialouge_State = true;
                index++;
                Dec_response = textList[index].Split('/');
                d1.text = Dec_response[0];
                d2.text = Dec_response[1];
                d3.text = Dec_response[2];
                index++;
                Debug.Log(Dec_response[0]);
                break;
            case "[code]":
                codePanel.SetActive(true);
                Code_State = true;
                index++;
                break;
            case "[finish]":
                gameOver.SetActive(true);
                break;
        }
        int len = 0;
        while (!cancelTyping && len < textList[index].Length - 1)
        {
            textLabel.text += textList[index][len];
            len++;
            yield return new WaitForSeconds(textSpeed);
        }
        textLabel.text = textList[index];
        cancelTyping = false;
        textFinished = true;
        index++;
    }
}

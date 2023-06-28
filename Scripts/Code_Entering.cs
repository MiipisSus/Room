using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Code_Entering : MonoBehaviour
{
    public InputField input;
    public GameObject cPanel;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            DialougeSystem.Code_State = false;
            if (input.text.ToString()=="5268")
            {
                DialougeSystem.psd = true;
            }
            Debug.Log(input.text.ToString());
            cPanel.SetActive(false);
        }
        
    }
}

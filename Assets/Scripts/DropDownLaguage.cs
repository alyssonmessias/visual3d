using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropDownLaguage : MonoBehaviour
{
    //public TextMeshProUGUI output;
    TMP_Dropdown dropDown;
    int m_DropdownValue;
    string m_Message;
    // Start is called before the first frame update
    void Start()
    {
        dropDown = GameObject.Find("DropdownLanguage").GetComponent<TMP_Dropdown>();
        switch (LangResolver._language)
        {
            case SystemLanguage.English:
                dropDown.value = 1;
                break;
            case SystemLanguage.Portuguese:
                dropDown.value = 0;
                break;
        }
        //Debug.Log("LangResolver._language:" + LangResolver._language);
    }

    public void HandleInputData(int val)
    {
        switch (val)
        {
            case 0:
                //output.text = "Português";
                Debug.Log("HandleInputData:" + val);
                LangResolver.ChangeToPortuguese();
                break;
            case 1:
                //output.text = "Inglês";
                Debug.Log("HandleInputData:" + val);
                LangResolver.ChangeToEnglish();
                break;

        }

    }

   
}

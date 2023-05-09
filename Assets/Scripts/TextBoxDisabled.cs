using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextBoxDisabled : MonoBehaviour
{
    public Image chatBox;
    bool boxEnabled = false;
    public TextMeshProUGUI text;
    public string dialogue;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            print("hi");
            chatBox.enabled = false;
            boxEnabled = false;
            text.enabled = false;
        }
    }
}

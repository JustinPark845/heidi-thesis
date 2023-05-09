using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SunOrbChat : MonoBehaviour
{
    public Image chatBox;
    bool boxEnabled = false;
    public TextMeshProUGUI text;
    public string dialogue;

    void Start()
    {
        chatBox.enabled = false;
        text.enabled = false;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player")) {
            chatBox.enabled = true;
            boxEnabled = true;
            text.text = dialogue;
            text.enabled = true;
        }
    }
    /*void Update()
    {
        //if (chatBox.enabled) {
            if (Input.GetKeyDown(KeyCode.F)) {
                print("hi");
                chatBox.enabled = false;
                boxEnabled = false;
                text.enabled = false;
            }
        //}
    }*/

	private void FixedUpdate()
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

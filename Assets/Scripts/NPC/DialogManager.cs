using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogManager : MonoBehaviour
{
    public NPC npc;

    bool isTalking = false;
    float distance;
    float currentResponseTracker = 0;
    
    public GameObject player;
    public GameObject dialogUI;

    public Text npcName;
    public Text npcDialogBox;
    public Text playerResponse;


    // Start is called before the first frame update
    void Start()
    {
        dialogUI.SetActive(false);
    }
    private void OnMouseOver()
    {
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        if (distance<=20f)
        {
            //if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
            //{
            //    currentResponseTracker++;
            //    if (currentResponseTracker >= npc.playerDialogue.Length-1)
            //    {
            //        currentResponseTracker = npc.playerDialogue.Length - 1;
            //    }
            //}
            //else if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
            //{
            //    currentResponseTracker--;
            //    if (currentResponseTracker<0)
            //    {
            //        currentResponseTracker = 0; 
            //    }
            //}

            //Trigger dialogue
            if (Input.GetKeyDown(KeyCode.E) && isTalking == false)
            {
                StartConversation();
            }
            else if (Input.GetKeyDown(KeyCode.E) && isTalking == true)
            {
                EndDialog();
            }
            if (currentResponseTracker == 0 && npc.playerDialogue.Length >= 0)
            {
                playerResponse.text = npc.playerDialogue[0];
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    npcDialogBox.text = npc.dialogue[1];
                    currentResponseTracker++;
                }
            }
            else if (currentResponseTracker == 1 && npc.playerDialogue.Length >= 1)
            {
                playerResponse.text = npc.playerDialogue[1];
                //if (Input.GetKeyDown(KeyCode.Return))
                //{
                //    npcDialogBox.text = npc.dialogue[2];
                //}
            }
        }
    }

    private void StartConversation()
    {
        isTalking = true;
        currentResponseTracker = 0;
        dialogUI.SetActive(true);
        npcName.text = npc.npcName;
        npcDialogBox.text = npc.dialogue[0];
        print("Pocetak dijaloga...");
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void EndDialog()
    {
        isTalking = false;
        dialogUI.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        print("Kraj dijaloga...");
    }

}

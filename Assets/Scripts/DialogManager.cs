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
    public Text PlayerResponse;


    // Start is called before the first frame update
    void Start()
    {
        print("Doslo je do dijaloga");
        dialogUI.SetActive(false);
    }
    private void OnMouseOver()
    {
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        if (distance<=2.5f)
        {
            //Trigger dialogue
            if (Input.GetKeyDown(KeyCode.E) && isTalking == false)
            {
                StartConversation();
            }
            else if (Input.GetKeyDown(KeyCode.E) && isTalking == true)
            {
                EndDialog();
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
        print("Doslo je do dijaloga");

    }

    private void EndDialog()
    {
        isTalking = false;
        dialogUI.SetActive(false);
    }

}

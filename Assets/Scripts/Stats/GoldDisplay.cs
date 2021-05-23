using RPG.Stats;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    Experience experience;
    private void Awake()
    {
        experience = GameObject.FindWithTag("Player").GetComponent<Experience>();
    }
    private void Update()
    {
        GetComponent<Text>().text = String.Format("{0:00}", experience.Gold());
    }
}

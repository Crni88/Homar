using RPG.Resources;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddHealth : MonoBehaviour
{
    public GameObject player;

    private void Start()
    {
        StartCoroutine(player.GetComponent<Health>().addHealth());
    }
    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}

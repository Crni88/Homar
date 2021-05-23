using RPG.Resources;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class VratiNaPocetak : MonoBehaviour
{
    [System.Obsolete]
    private void Update()
    {
            if (GetComponent<Health>().IsDead())
            {
            Application.LoadLevel(Application.loadedLevel);

            }
    }
    }

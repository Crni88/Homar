using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Stats
{
    public class BaseStats : MonoBehaviour
    {
        [Range(1,99)]
        [SerializeField] int startingLevel=1;
        [SerializeField] CharactherClass charactherClass;
        [SerializeField] Progression progression=null;

        public float GetHealth()
        {
            return progression.GetHealth(charactherClass,startingLevel);
        }
        public float GetXPReward()
        {
            return 10;
        }
    }
}
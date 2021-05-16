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

        public float GetStat(Stats stats)
        {
            return progression.GetStats(stats,charactherClass,startingLevel);
        }

        public int GetLevel()
        {
           float currentXP = GetComponent<Experience>().GetXPPoints();
            return 0; 
        }
    }
}
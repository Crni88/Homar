using UnityEngine;

namespace RPG.Stats
{

    [CreateAssetMenu(fileName = "Progression", menuName = "Stats/New Progression")]
    public class Progression : ScriptableObject
    {
        [SerializeField] ProgressionCharacterClass[] characterClasses = null;

        public float GetStats(Stats stats,CharactherClass characterClass, int level)
        {
            foreach (ProgressionCharacterClass progressionClass in characterClasses)
            {
                if (progressionClass.characterClass != characterClass)
                {
                    continue; 
                }
                foreach (ProggressionStats proggressionStats in progressionClass.stats)
                {
                    if (proggressionStats.stats != stats)
                    {
                        continue;
                    }
                    if (proggressionStats.levels.Length <  level)
                    {
                        continue;
                    }
                    return proggressionStats.levels[level - 1];
                }
            } 
            return 0;
        }
           
        [System.Serializable]
        class ProgressionCharacterClass
        {
            public CharactherClass characterClass;
            public ProggressionStats[] stats;
        }
        [System.Serializable]
        class ProggressionStats
        {
            public Stats stats;
            public float[] levels;
        }
    }
}
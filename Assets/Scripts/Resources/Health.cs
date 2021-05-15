using RPG.Core;
using RPG.Stats;
using System;
using UnityEngine;
namespace RPG.Resources
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float healthPoints = 100f;
        bool isDead = false;

        private void Start()
        {
            healthPoints = GetComponent<BaseStats>().GetHealth();   
        }

        public bool IsDead()
        {
            return isDead;
        }

        public void TakeDamage(GameObject player,float damage)
        {
            healthPoints = Mathf.Max(healthPoints - damage,0);
            if (healthPoints == 0)
            {
                Die();
                AwardXP(player);
            }
        }

        private void AwardXP(GameObject player)
        {
            Experience experience = player.GetComponent<Experience>();
            if (experience == null)
            {
                return;
            }
            experience.GainExperience(GetComponent<BaseStats>().GetXPReward());
        }

        public float GetPercentageHealth()
        {
            return 100*(healthPoints / GetComponent<BaseStats>().GetHealth());
        }

        private void Die()
        {
            if (isDead) return;
            isDead = true;
            GetComponent<Animator>().SetTrigger("die");
            GetComponent<ActionScheduler>().CancelCurrentAction();
        }
    }
} 
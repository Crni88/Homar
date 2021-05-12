using RPG.Core;
using RPG.Stats;
using System.Collections;
using System.Collections.Generic;
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

        public void TakeDamage(float damage)
        {
            healthPoints = Mathf.Max(healthPoints - damage,0);
            if (healthPoints == 0)
            {
                Die();
            }
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
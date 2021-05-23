using RPG.Core;
using RPG.Stats;
using System;
using System.Collections;
using UnityEngine;
namespace RPG.Resources
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float healthPoints = 100f;

        bool isDead = false;
        public GameObject player;
        private void Start()
        {
            healthPoints = GetComponent<BaseStats>().GetStat(Stats.Stats.Health); 
           // StartCoroutine(addHealth());

        }
        public IEnumerator addHealth()
        {
            while (true)
            { // loops forever...
                if (healthPoints < 100)
                { // if health < 100...
                    healthPoints += 1; // increase health and wait the specified time
                    yield return new WaitForSeconds(1);
                }
                else
                { // if health >= 100, just yield 
                    yield return null;
                }
            }
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
            experience.GainExperience(GetComponent<BaseStats>().GetStat(Stats.Stats.XPReward));
        } 

        public float GetPercentageHealth()
        {
            return 50*(healthPoints / GetComponent<BaseStats>().GetStat(Stats.Stats.Health));
        }

        private void Die()
        {
            if (isDead) return;
            isDead = true;
            GetComponent<Animator>().SetTrigger("die");
            GetComponent<ActionScheduler>().CancelCurrentAction();
            GetComponent<Movement.Mover>().enabled = false;
            StopCoroutine(addHealth());
        }
    }
} 
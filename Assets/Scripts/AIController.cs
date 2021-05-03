using RPG.Combat;
using RPG.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 5f;
        Fighter enemy;
        GameObject player;
        Health health; 
        private void Start()
        {
            enemy = GetComponent<Fighter>();
            player = GameObject.FindWithTag("Player");
            health = GetComponent<Health>();
        }

        private void Update()
        {
            if (health.IsDead())
            {
                return;
            }
            if (InRange() && enemy.CanAttack(player))
            {
                enemy.Attack(player);
            } 
        }
        private bool InRange()
        { 
            float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
            return distanceToPlayer < chaseDistance;
        }
    }
}
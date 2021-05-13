using RPG.Resources;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
    public class Projectile : MonoBehaviour
    {

        [SerializeField] float speed = 1f;
        [SerializeField] GameObject hitEffect = null;
        [SerializeField] float maxLifeTime = 10;
        Health target = null;
        float damage = 0;
        // Update is called once per frame
        void Update()
        {
            if (target == null)
            {
                return;
            }
            transform.LookAt(target.transform.position);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        public void SetTarget(Health target, float damage)
        {
            this.target = target;
            this.damage = damage;

            Destroy(gameObject, maxLifeTime);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Health>() != target)
            {
                return;
            }
            target.TakeDamage(damage);

            if (hitEffect != null)
            {
                Instantiate(hitEffect, target.transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
    }

}
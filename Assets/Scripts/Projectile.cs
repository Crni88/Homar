using RPG.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] float speed = 1f;
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
    public void SetTarget(Health target,float damage)
    {
        this.target = target;
        this.damage = damage;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Health>() != target) 
        {
            return;
        }
        target.TakeDamage(damage);
        Destroy(gameObject);
    }
}

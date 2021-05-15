using RPG.Core;
using RPG.Movement;
using UnityEngine;
using RPG.Resources;
using RPG.Stats;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        Resources.Health target;

        [SerializeField] float timeBetweenAttacks=1f;
        [SerializeField] Transform rightHandTransfrom=null;
        [SerializeField] Transform leftHandTransfrom=null;
        [SerializeField] Weapon defaultWeapon = null; 
          
        float timeSinceLastAttack = Mathf.Infinity;

        Weapon currentWeapon=null; 

        // Start is called before the first frame update
        void Start()
        {
            EquipWeapon(defaultWeapon);
        }

        // Update is called once per frame
        void Update()
        {
            timeSinceLastAttack += Time.deltaTime;
            if (target == null) return;
            if (target.IsDead()) return;
            
            if (!GetIsInRange())
            {
                GetComponent<Mover>().MoveTo(target.transform.position);
            }
            else
            {
                GetComponent<Mover>().Cancel();
                AttackBehaviour();
            }
        }
        public void EquipWeapon(Weapon weapon)
        {

            currentWeapon = weapon;
            Animator animator = GetComponent<Animator>();
            weapon.Spawn(rightHandTransfrom, leftHandTransfrom, animator);
        }

        public Health GetTarget()
        {
            return target;
        } 

        private void AttackBehaviour()
        {
            transform.LookAt(target.transform);
            if (timeSinceLastAttack > timeBetweenAttacks)
            {
                //Pokreni Hit() metodu/Event
                TriggerAttack();
                timeSinceLastAttack = 0;
            }
        }

        private void TriggerAttack()
        {
            GetComponent<Animator>().ResetTrigger("stopAttack");
            GetComponent<Animator>().SetTrigger("attack");
        }

        //Animation Event / Tacka udara
        void Hit()
        {
            if (target == null)
            {
                return;
            }
            if (currentWeapon.HasProjectile())
            {
                currentWeapon.LaunchProjectile(rightHandTransfrom, leftHandTransfrom, target, gameObject);
            }
            else
            {
                target.TakeDamage(gameObject, currentWeapon.GetDamage());
            }
        }
        //Animation Event / Za luk i strijelu

        void Shoot()
        {
            Hit();
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.transform.position) < currentWeapon.GetRange();
        }

        public bool CanAttack(GameObject combatTarget)
        {
            if (combatTarget == null)
            {
                return false;
            }
            Resources.Health targetTest = combatTarget.GetComponent<Resources.Health>();
            return targetTest != null && !targetTest.IsDead();
        }

        public void Attack(GameObject combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.GetComponent<Resources.Health>();
        }
        public void Cancel()
        {
            StopAttack(); 
            target = null;
        }

        private void StopAttack()
        {
            GetComponent<Animator>().ResetTrigger("Attack");
            GetComponent<Animator>().SetTrigger("stopAttack");
        }
    }
}


using UnityEngine;

namespace RPG.Combat
{
    [CreateAssetMenu(fileName = "Wepon", menuName = "Weapons/Make New Weapon", order = 0)]
    public class Weapon : ScriptableObject
    {
        [SerializeField] AnimatorOverrideController animatorOverride = null;
        [SerializeField] GameObject equippedPrefab = null;
        [SerializeField] float weaponDamage = 5f;
        [SerializeField] float weaponRange = 2f;
        [SerializeField] bool isRightHanded = true;


        public void Spawn(Transform rightHandTransfrom,Transform leftHandTransform,Animator animator) {
            if (equippedPrefab != null)
            {
                Transform handTransform;
                if (isRightHanded)
                {
                    handTransform = rightHandTransfrom;
                }
                else
                {
                    handTransform = leftHandTransform;
                }
                Instantiate(equippedPrefab, handTransform);
            } 
            if (animatorOverride != null)
            {
                animator.runtimeAnimatorController = animatorOverride;
            }
        }

        public float GetDamage()
        {
            return weaponDamage;
        }

        public float GetRange()
        {
            return weaponRange;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace AI_Game
{
    public class CS_MeleeWeapon : MonoBehaviour
    {
        [SerializeField] List<Collider> hitObjects= new List<Collider>();
        [SerializeField] SM_MeleeCharacter charManager;
        [SerializeField] float damage;


        // Start is called before the first frame update
        void Start()
        {
            charManager = GetComponentInParent<SM_MeleeCharacter>();
            gameObject.layer= charManager.gameObject.layer;
            this.enabled = false;
        }

        // Update is called once per frame
        private void OnEnable()
        {
            hitObjects.Clear();
            GetComponent<AudioSource>().Play();

        }

        public void OnTriggerEnter(Collider other)
        {
            ApplyDamage(other);
        }

        public void ApplyDamage(Collider other)
        {
            if (!hitObjects.Contains(other) && charManager.Anim && this.enabled)
            {
                if(other.TryGetComponent<CS_StatsManager>(out CS_StatsManager statsManager))
                statsManager.Damage(damage);
            }
        }
    }
}

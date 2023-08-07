using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI_Game
{
    public class CS_MagicBall : MonoBehaviour
    {

        [SerializeField] float damage;
        private void OnEnable()
        {
            GetComponent<AudioSource>().Play();
        }
        public void OnTriggerEnter(Collider other)
        {
            ApplyDamage(other);
        
        }

        public void ApplyDamage(Collider other)
        {
            if (other.TryGetComponent<CS_StatsManager>(out CS_StatsManager statsManager))
            {
                statsManager.Damage(damage);
                gameObject.SetActive(false);
            }

        }
    }
}

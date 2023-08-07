using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI_Game
{
    public class CS_DetectionSphere : MonoBehaviour
    {
        [SerializeField] List<Collider> colliders = new List<Collider>();

        public List<Collider> Colliders { get => colliders; }

        private void OnTriggerEnter(Collider collider)
        {
            if (!colliders.Contains(collider))
            {
                colliders.Add(collider);
            }
        }

        private void OnTriggerExit(Collider collider)
        {
            if (colliders.Contains(collider))
            {
                colliders.Remove(collider);
            }
        }
    }
}

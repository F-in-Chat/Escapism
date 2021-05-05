using InGame.Characters.Core.Scripts;
using Parents;
using SoundEffects;
using UnityEngine;

namespace InGame.Collectibles.Scripts
{
    public class Collectible : MonoBehaviour
    {
        [SerializeField] private SoundEffect collectSound;
        [SerializeField] private GameObject collectParticles;
        private Transform item;

        private void Awake()
        {
            item = Parent.GetComponent<Transform>(this);
        }

        private void OnTriggerEnter(Collider other)
        {
            var collector = other.GetComponent<Collector>();
            if (!collector) return;
            collector.Collect(this);
            if (collectSound) collectSound.Play(transform.position);
            SpawnParticles();
            Destroy(item.gameObject);
        }

        private void SpawnParticles()
        {
            if (!collectParticles) return;
            var particles = Instantiate(collectParticles);
            particles.transform.position = transform.position;
        }
    }
}

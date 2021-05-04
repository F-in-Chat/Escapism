using UnityEngine;

namespace InGame.Characters.Core.Scripts
{
    public class DealDamage : MonoBehaviour
    {
        public void SendDamage(int damage) {
            PlayerHealth playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damage);
        }
    }
}

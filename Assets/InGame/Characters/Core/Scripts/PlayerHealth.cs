using UnityEngine;

namespace InGame.Characters.Core.Scripts
{
    public class PlayerHealth : MonoBehaviour
    {
        public int health;

        public void TakeDamage(int damage) {
            health -= damage;
            Debug.Log("Health = " + health.ToString());
        }
    }
}

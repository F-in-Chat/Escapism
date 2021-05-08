using InGame.Characters.Core.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace UI.HUD.Scripts
{
    public class LifeBar : MonoBehaviour
    {
        public Slider lifeBar;
        PlayerHealth playerHealth;

        void Start()
        {
            playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        }

        void Update()
        {
            lifeBar.value = playerHealth.health;
        }
    }
}

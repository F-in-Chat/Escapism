using UnityEngine;

namespace UI.HUD.Scripts
{
    public class WeaponIcon : MonoBehaviour
    {
        public TMPro.TMP_Text weapon_label;
        // Start is called before the first frame update
        void Start()
        {
            if (weapon_label)
                weapon_label.text = "Axe";
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}

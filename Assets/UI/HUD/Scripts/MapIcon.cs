using UnityEngine;

namespace UI.HUD.Scripts
{
    public class MapIcon : MonoBehaviour
    {
        public TMPro.TMP_Text map_label;
        // Start is called before the first frame update
        void Start()
        {
            map_label.text = "Power Room";
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}

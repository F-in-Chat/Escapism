using UnityEngine;

namespace InGame.Weapons.Gun.Scripts
{
    public class GunFire : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            if(Input.GetButtonDown("Fire1"))
            {
                GetComponent<Animation>().Play("GunShot");
            }
        }
    }
}

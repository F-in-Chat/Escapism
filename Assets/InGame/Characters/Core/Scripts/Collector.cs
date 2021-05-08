using InGame.Collectibles.Scripts;
using UnityEngine;

namespace InGame.Characters.Core.Scripts
{
    public class Collector : MonoBehaviour
    {
        //public UnityEvent<Collectible> onCollect = new UnityEvent<Collectible>();

        public void Collect(Collectible collectible)
        {
            //onCollect.Invoke(collectible);
        }
    }
}
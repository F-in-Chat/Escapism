using System;
using InGame.Items.Scripts;
using UnityEngine;
using UnityEngine.Events;

namespace InGame.Characters.Core.Scripts
{
    public class Collector : MonoBehaviour
    {
        [Serializable] public class UnityEventCollectible : UnityEvent<Collectible> { }
        
        public UnityEventCollectible onCollect = new UnityEventCollectible();

        public void Collect(Collectible collectible)
        {
            onCollect.Invoke(collectible);
        }
    }
}
using System;
using InGame.Characters.Core.Scripts;
using UnityEngine;
using UnityEngine.Events;

namespace InGame.PassiveInteractables
{
    public class Trigger : MonoBehaviour
    {
        [Serializable] public class TriggerEvent : UnityEvent<Collider> { }

        public TriggerEvent triggerEnterEvent = new TriggerEvent();
        public TriggerEvent triggerExitEvent = new TriggerEvent();

        private void OnTriggerEnter(Collider other)
        {
            var triggerer = other.GetComponent<Triggerer>();
            if (!triggerer) return;
            triggerEnterEvent.Invoke(other);
        }

        private void OnTriggerExit(Collider other)
        {
            var triggerer = other.GetComponent<Triggerer>();
            if (!triggerer) return;
            triggerExitEvent.Invoke(other);
        }
    }
}

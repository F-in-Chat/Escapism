using System;
using InGame.Characters.Core.Scripts;
using UnityEngine;

namespace InGame.AI.Scripts
{
    public class FootStepListener : MonoBehaviour
    {
        [SerializeField] private HearFootsteps hearFootsteps;

        private void OnDisable()
        {
            hearFootsteps.Remove(this);
        }

        private void OnTriggerEnter(Collider other)
        {
            var footsteps = other.GetComponent<CharacterFootSteps>();
            if (!footsteps) return;
            hearFootsteps.Add(this);
        }

        private void OnTriggerExit(Collider other)
        {
            var footsteps = other.GetComponent<CharacterFootSteps>();
            if (!footsteps) return;
            hearFootsteps.Remove(this);
        }
    }
}
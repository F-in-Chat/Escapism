using System;
using Extensions;
using Parents;
using SoundEffects;
using UnityEngine;

namespace InGame.Characters.Core.Scripts
{
    public class CharacterFootSteps : MonoBehaviour
    {
        // We will loop the footstep SFX with a playback speed linked to the player's movement speed.
        // Need to speak with design about camera movement in the case that we will need to link foot steps with head bobbing / camera tilt
        [SerializeField] private SoundEffect[] footsteps = new SoundEffect[0];
        private int footstepIndex;
        private PlayerMovement playerMovement;
        private float lastFootstepTaken = -9999;
        [SerializeField] private float footstepDuration = 0.1f;
        [SerializeField] private float debugVelocity;
        
        private float PlayerVelocity => playerMovement ? playerMovement.Velocity.XZ().magnitude : 0;
        private float DurationUntilNextFootstep => footstepDuration / PlayerVelocity;
        private bool CanPlayNextFootstepSound => Time.time >= lastFootstepTaken + footstepDuration;

        private void Awake()
        {
            playerMovement = Parent.GetComponent<PlayerMovement>(this);
        }

        private void Update()
        {
            debugVelocity = PlayerVelocity;
            if (PlayerVelocity > 0.1f)
                if (CanPlayNextFootstepSound)
                    PlayFootsteps();
        }

        private void PlayFootsteps()
        {
            if (footsteps.Length == 0) return;
            footsteps[footstepIndex].Play(transform.position);
            footstepIndex = (footstepIndex + 1) % footsteps.Length;
            lastFootstepTaken = Time.time;
        }
    }
}

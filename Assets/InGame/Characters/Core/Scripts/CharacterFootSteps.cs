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
        [SerializeField] private float footstepRadius = 10;
        [SerializeField] private float crouchFootstepRadius = 2;
        [SerializeField] private float footstepDuration = 0.1f;
        [SerializeField] private float volumeReducer = 0.5f;
        private SphereCollider sphereCollider;
        private Crouch crouch;

        private bool IsCrouching => crouch && crouch.IsCrouching;
        private float PlayerVelocity => playerMovement ? playerMovement.Velocity.XZ().magnitude : 0;
        private float DurationUntilNextFootstep => footstepDuration / PlayerVelocity;
        private bool CanPlayNextFootstepSound => Time.time >= lastFootstepTaken + DurationUntilNextFootstep;

        private void Awake()
        {
            playerMovement = Parent.GetComponent<PlayerMovement>(this);
            sphereCollider = GetComponent<SphereCollider>();
            crouch = Parent.GetComponent<Crouch>(this);
        }

        private void Update()
        {
            if (PlayerVelocity > 0.1f)
            {
                sphereCollider.radius = IsCrouching ? crouchFootstepRadius : footstepRadius;
                if (CanPlayNextFootstepSound)
                    PlayFootsteps();
            }
            else
            {
                sphereCollider.radius = 0;
            }
        }

        private void PlayFootsteps()
        {
            if (footsteps.Length == 0) return;
            var volumeMultiplier = IsCrouching ? volumeReducer : 1;
            footsteps[footstepIndex].Play(transform.position, volumeMultiplier);
            footstepIndex = (footstepIndex + 1) % footsteps.Length;
            lastFootstepTaken = Time.time;
        }
    }
}

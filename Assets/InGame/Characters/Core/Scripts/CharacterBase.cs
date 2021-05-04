using UnityEngine;

namespace InGame.Characters.Core.Scripts
{
    [RequireComponent(typeof(Animator))]
    public class CharacterBase : MonoBehaviour
    {
        #region Character Stats
        [Header("Stats")]
        public int health;
        public int energy;
        public int infection;
        public float moveSpeed;
        public float acceleration;
        public float turnSpeed;
        #endregion
    
        #region Components
        protected Animator myAnimator;
        #endregion

        #region State Tracking
        private MovementState movementState = MovementState.Idle;
        private InteractionState interactionState = InteractionState.Neutral;
        private PositionState positionState = PositionState.Stand;
        #endregion

        public enum MovementState
        {
            Idle,
            Walk,
            Run,
            Crawling,
        }

        public enum InteractionState
        {
            Neutral,
            Interacting,
            Attack,
            Ability,
            Venting,
        }

        public enum PositionState
        {
            Stand,
            Prone,
            Crouch,
            Vent,
        }

        public MovementState GetMovementState()
        {
            return movementState;
        }
        public InteractionState GetInteractionState()
        {
            return interactionState;
        }
        public PositionState GetPositionState()
        {
            return positionState;
        }




        /* 
        Should we break this into two Bases? Player and AI?

        What do we need for this Character Base script
        1. Movement
            a. Math
            b. External Input (Player or AI)
        2. Stats
            a. Health
            b. Energy
            c. Infection
            d. Movement Speed
            e. Holding Item (Prevent running if object is heavy or 2 handed)
        3. Animations
            a. Link animations with actions
            b. Hook character states with animation states
            c. Animations + Held Object Interactions
        4. Basic World Interactions (This can be put on the Interactable Base Class)
            a. Open Doors
            b. World Objects (Alarms, terminals, Lights, etc )
                We just need to prevent the NPCs from triggering any worldspace UI.
                That can be coded within the PlayerController. 
            c. This can all be handled in the interaction base? It will simply check if the player is in proximity, is looking at the object, and is pressing the interact button/key
        ?. States
            a. We will need an Enum, Coroutine, or Switch Statement system?
            b. Link Animations
            c. How will we handle states and animations when they are spread between multiple scripts?
            This script will be inherited by PlayerController and AIBase / AIController.
            Will states be here? Or will they be in the higher level scripts?
    */

        // Enums are going to be used for communication a simple logic checks.
    }
}

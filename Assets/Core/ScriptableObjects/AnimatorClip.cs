using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Animator Clip")]
    public class AnimatorClip : ScriptableObject
    {
        public int hash;

        private void OnValidate()
        {
            hash = Animator.StringToHash(name);
        }

        public static void Play(Animator animator, AnimatorClip animatorClip)
        {
            if (!animator) return;
            if (!animatorClip) return;
            animator.Play(animatorClip.hash, -1, 0);
        }
    }
}
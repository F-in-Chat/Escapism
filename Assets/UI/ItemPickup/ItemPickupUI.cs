using ScriptableObjects;
using TMPro;
using UnityEngine;

namespace UI.ItemPickup
{
    public class ItemPickupUI : MonoBehaviour
    {
        [SerializeField] private ItemPickupPopup itemPickupPopup;
        [SerializeField] private AnimatorClip animatorClip;
        private Animator _animator;
        private TextMeshProUGUI _textMesh;

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
            _textMesh = GetComponentInChildren<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            itemPickupPopup.itemPickupUI = this;
        }

        private void OnDisable()
        {
            if (itemPickupPopup.itemPickupUI == this)
                itemPickupPopup.itemPickupUI = null;
        }

        public void Display(string text)
        {
            AnimatorClip.Play(_animator, animatorClip);
            _textMesh.text = text;
        }
    }
}

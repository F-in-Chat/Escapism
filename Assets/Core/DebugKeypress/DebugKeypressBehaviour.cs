using UnityEngine;
using UnityEngine.Events;

namespace DebugKeypress
{
    public class DebugKeypressBehaviour : MonoBehaviour
    {
        [SerializeField] private KeyCode keyCode;
        [SerializeField] private UnityEvent onKeyPress;
        
        private void Update()
        {
            if (Input.GetKeyDown(keyCode))
                onKeyPress.Invoke();
        }
    }
}

using UnityEngine;

namespace InGame.Cameras
{
    public class RegisterMainCamera : MonoBehaviour
    {
        [SerializeField] private MainCamera mainCamera;
        private Camera _camera;

        private void Awake()
        {
            _camera = GetComponent<Camera>();
        }

        private void OnEnable()
        {
            mainCamera.value = _camera;
        }

        private void OnDisable()
        {
            if (mainCamera.value == _camera) 
                mainCamera.value = null;
        }
    }
}

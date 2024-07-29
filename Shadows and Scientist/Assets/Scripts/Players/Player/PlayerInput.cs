using UnityEngine;

namespace PlayerNamespace
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private Camera _camera;

        public static PlayerInput Instance { get; private set; }
        public void Init()
        {
            if(Instance == null)
            {
                Instance = this;
                return;
            }
            Destroy(gameObject);
        }

        public bool GetMouseDown() => Input.GetMouseButtonDown(0);
        public bool GetMouseUp() => Input.GetMouseButtonUp(0);

        public Ray GetScreenPointRay() => _camera.ScreenPointToRay(Input.mousePosition);
        public Vector2 GetMouseLocalPos() => _camera.ScreenToWorldPoint(Input.mousePosition) - _camera.transform.position;
        public Vector2 GetMouseGlobalPos() => _camera.ScreenToWorldPoint(Input.mousePosition);

        private void OnValidate()
        {
            _camera = Camera.main;
        }
    }
}
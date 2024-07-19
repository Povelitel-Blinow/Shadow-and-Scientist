using UnityEngine;

namespace PlayerNamespace
{
    public class PlayerRaycast : MonoBehaviour
    {
        public static PlayerRaycast Instance { get; private set; }

        public void Init()
        {
            if (Instance == null)
            {
                Instance = this;
                return;
            }
            Destroy(gameObject);
        }

        /// <summary>
        /// Casts a ray from the main camera
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>An object with the required class or null</returns>
        public T RayCast<T>()
        {
            Ray ray = PlayerInput.Instance.GetScreenPointRay();

            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            T required = default;

            hit.collider?.TryGetComponent(out required);

            return required;
        }
    }
}
using UnityEngine;

namespace GadgetNamespace
{
    public class GadgetWindow : MonoBehaviour
    {
        public bool IsActive { get; private set; } = false;

        public void Hide()
        {
            gameObject.SetActive(false);
            IsActive = false;
        }

        
        public void ShowUp()
        {
            gameObject.SetActive(true);
            IsActive = true;
        }
    }
}
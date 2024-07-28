using UnityEngine;

namespace GadgetNamespace
{
    public class GadgetWindow : MonoBehaviour
    {
        public void Hide()
        {
            gameObject.SetActive(false);
        }

        
        public void ShowUp()
        {
            gameObject.SetActive(true);
        }
    }
}
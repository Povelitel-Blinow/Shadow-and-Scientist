using UnityEngine;

namespace WindowNamespace
{
    public class TipWindow : MonoBehaviour
    {
        public void ShowUp()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
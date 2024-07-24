using UnityEngine;

namespace WindowNamespace
{
    public abstract class CraftBlockWindow : MonoBehaviour
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
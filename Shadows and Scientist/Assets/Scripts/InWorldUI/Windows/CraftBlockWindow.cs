using UnityEngine;

namespace WindowNamespace
{
    public abstract class CraftBlockWindow : MonoBehaviour
    {
        public void Init()
        {
            gameObject.SetActive(false);
        }

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
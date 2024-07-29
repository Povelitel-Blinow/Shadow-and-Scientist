using UnityEngine;

namespace BuildingNameSpace
{
    [RequireComponent(typeof(FadeController))]
    public class Roof : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private FadeController _fadeController;

        public void HideRoof()
        {
            _fadeController.FadeOut();
            //gameObject.SetActive(false);
        }

        public void ShowRoof()
        {
           // gameObject.SetActive(true);
            _fadeController.FadeIn();
        }

        private void OnValidate()
        {
            _fadeController ??= GetComponent<FadeController>();
        }
    }
}
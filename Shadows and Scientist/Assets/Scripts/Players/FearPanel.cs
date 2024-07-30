using UnityEngine;
using UnityEngine.UI;

namespace PlayerNamespace
{
    public class FearPanel : MonoBehaviour
    {
        [SerializeField] private Image _image;

        [SerializeField] private float _colorChangeSpeed;

        private float _currentRatio = 0;

        public void SetFear(float ratio)
        {
            float color = Mathf.Lerp(0, ratio - _currentRatio, Time.deltaTime*_colorChangeSpeed);

            _currentRatio += color;

            _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, _currentRatio);
        }
    }
}
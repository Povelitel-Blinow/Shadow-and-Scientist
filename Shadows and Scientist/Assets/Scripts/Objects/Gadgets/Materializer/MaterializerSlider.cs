using DG.Tweening;
using MaterialNamespace;
using UnityEngine;

namespace GadgetNamespace
{
    public class MaterializerSlider : MonoBehaviour, IClickable
    {
        [SerializeField] private Transform _slider;
        [SerializeField] private Transform[] _positions;
        [SerializeField] private float _moveTime;

        private int _currentPos;

        public void Click()
        {
            _currentPos++;

            if( _currentPos >= _positions.Length )
                _currentPos = 0;

            _slider.DOLocalMove(_positions[_currentPos].localPosition, _moveTime);
        }

        public MaterialType GetMaterialType()
        {
            switch( _currentPos )
            {
                case 0:
                    return MaterialType.Glass;
                case 1:
                    return MaterialType.Metall;
                case 2:
                    return MaterialType.Gold;
            }

            return MaterialType.Metall;
        }

        private void OnDestroy()
        {
            _slider.DOKill();
        }
    }
}
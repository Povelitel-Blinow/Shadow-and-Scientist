using DG.Tweening;
using GameDesign;
using InWorldUINamespace;
using UnityEngine;

namespace WindowNamespace
{
    public abstract class SelectableButton : Button, ISelectable
    {
        [Header("Select Settings")]
        [SerializeField] private SelectButtonSettings _selectButtonsettings;

        public void Select()
        {
            transform.DOScale(_selectButtonsettings.SelectScaleRatio, _selectButtonsettings.SelectScaleTime);
        }

        public void Deselect()
        {
            transform.DOScale(1, _selectButtonsettings.SelectScaleTime);
        }

        private void OnDestroy()
        {
            transform.DOKill();
        }
    }
}

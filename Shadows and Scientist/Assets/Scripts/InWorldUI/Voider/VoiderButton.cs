using UnityEngine;
using InWorldUINamespace;
namespace VoiderNamespace
{
    public class VoiderButton : Button
    {
        [SerializeField] private Voider _voider;
        protected override void OnClick()
        {
            _voider.VoidSlot();
        }
    }
}
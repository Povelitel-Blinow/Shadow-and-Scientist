using UnityEngine;

namespace MaterialNamespace
{
    [RequireComponent(typeof(InSlotPutable))]
    public class TheMaterial : MonoBehaviour
    {
        [SerializeField] private MaterialType _type;

        [SerializeField] private InSlotPutable _inSlotPutable;

        public MaterialType MaterialType => _type;

        public InSlotPutable InSlotPutable => _inSlotPutable;

        private void OnValidate()
        {
            _inSlotPutable ??= GetComponent<InSlotPutable>();
        }
    }

    public enum MaterialType
    {
        Energy,
        Metall,
        Gold,
        Glass,
        Capsule,
        EnergyCapsule,
        Steel,
        Coin
    }
}

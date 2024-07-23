using ObjectsNamespace;
using UnityEngine;

namespace MaterialNamespace
{
    public class TheMaterial : MonoBehaviour
    {
        [SerializeField] private MaterialType _type;

        public MaterialType MaterialType => _type;
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
    }
}

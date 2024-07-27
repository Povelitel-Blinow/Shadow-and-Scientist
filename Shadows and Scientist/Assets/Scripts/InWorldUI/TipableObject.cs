using UnityEngine;

namespace InWorldUINamespace
{
    public class TipableObject : MonoBehaviour, ITipable
    {
        [SerializeField] private TipableObjectNames _name;
        public TipableObjectNames GetTipableType()
        {
            return _name;
        }
    }
}
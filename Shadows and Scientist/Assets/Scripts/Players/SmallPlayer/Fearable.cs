using UnityEngine;

namespace SmallPlayerNamespace
{
    public class Fearable : MonoBehaviour
    {
        public void RegisterScary(IScary scary)
        {
            PlayerManager.Instance.RegisterScare(scary);
        }

        public void DeregisterScary(IScary scary)
        {
            PlayerManager.Instance.DeRegisterScare(scary);
        }
    }
}
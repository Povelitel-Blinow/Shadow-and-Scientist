using PlayerNamespace;
using UnityEngine;

namespace GadgetNamespace
{
    public class BackPack : MonoBehaviour
    {
        private void OnEnable()
        {
            PlayerTips.Instance.ShowBackPackTip();
        }
    }
}
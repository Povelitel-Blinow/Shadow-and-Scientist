using UnityEngine;

namespace GadgetNamespace
{
    public class MaterializerButton : MonoBehaviour, IClickable
    {
        [SerializeField] private Materializer _materializer;

        public void Click()
        {
            _materializer.TryMaterialize();    
        }
    }
}
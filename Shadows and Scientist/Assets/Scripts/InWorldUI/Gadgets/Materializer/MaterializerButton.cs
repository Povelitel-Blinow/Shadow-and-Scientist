using UnityEngine;
using InWorldUINamespace;

namespace GadgetNamespace
{
    public class MaterializerButton : Button
    {
        [SerializeField] private Materializer _materializer;

        protected override void OnClick()
        {
            _materializer.TryMaterialize();    
        }
    }
}
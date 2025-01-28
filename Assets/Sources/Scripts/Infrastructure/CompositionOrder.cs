using System.Collections.Generic;
using UnityEngine;

namespace MerJame.Infrastructure
{
    public class CompositionOrder : MonoBehaviour
    {
        [SerializeField] private List<CompositeRoot> _orders;

        public void Init()
        {
            foreach (var compositionRoot in _orders)
                compositionRoot.Init();
        }
    }
}
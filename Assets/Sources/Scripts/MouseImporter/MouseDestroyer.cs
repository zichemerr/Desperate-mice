using MerJame.PlayerSystem;
using System;
using System.Collections;
using UnityEngine;

namespace MerJame.Importer
{
    public class MouseDestroyer
    {
        private MonoBehaviour _monoBehaviour;
        private WaitForSeconds _delay;

        public bool IsDestroyed { get; private set; }

        public event Action AllDestroyed;

        public MouseDestroyer(MonoBehaviour monoBehaviour, float destroyDelay = 0.5f)
        {
            _monoBehaviour = monoBehaviour;
            _delay = new WaitForSeconds(destroyDelay);
        }

        public void Destroy(Mouse[] mouses)
        {
            _monoBehaviour.StartCoroutine(DestroyRoutine(mouses));
        }

        private IEnumerator DestroyRoutine(Mouse[] mouses)
        {
            IsDestroyed = true;

            foreach (var mouse in mouses)
            {
                yield return _delay;
                mouse.Destroy();
            }

            AllDestroyed?.Invoke();
        }
    }
}
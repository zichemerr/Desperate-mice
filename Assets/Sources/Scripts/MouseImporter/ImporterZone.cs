using MerJame.PlayerSystem;
using System;
using UnityEngine;

namespace MerJame.Importer
{
    public class ImporterZone : MonoBehaviour
    {
        public event Action<Mouse> Entered;
        public event Action<Mouse> Exited;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Mouse mouse))
            {
                Entered?.Invoke(mouse);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Mouse mouse))
            {
                Exited?.Invoke(mouse);
            }
        }
    }
}
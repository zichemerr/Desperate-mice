using UnityEngine;
using MerJame.PlayerSystem;
using System;
using System.Collections.Generic;

namespace MerJame.Importer
{
    public class ImporterController : MonoBehaviour
    {
        [SerializeField] private ImporterZone _zone;
        [SerializeField] private ImporterView _view;
        [SerializeField] private int _importCount;

        private List<Mouse> _mouseImported;
        private MouseDestroyer _mouseDestroyer;

        public event Action Assembled;

        public void Init()
        {
            _mouseDestroyer = new MouseDestroyer();
            _mouseImported = new List<Mouse>();

            _zone.Entered += OnEntered;
            _zone.Exited += OnExited;
        }

        private void OnDisable()
        {
            _zone.Entered -= OnEntered;
            _zone.Exited -= OnExited;
        }

        private void OnEntered(Mouse mouse)
        {
            if (_mouseDestroyer.IsDestroyed)
                return;

            _mouseImported.Add(mouse);
            _view.ShowValue(_mouseImported.Count);

            if (_mouseImported.Count == _importCount)
            {
                _mouseDestroyer.Destroy(_mouseImported.ToArray());
                Assembled?.Invoke();
            }
        }

        private void OnExited(Mouse mouse)
        {
            if (_mouseImported.Count == _importCount)
                return;

            _mouseImported.Remove(mouse);
            _view.ShowValue(_mouseImported.Count);
        }
    }
}
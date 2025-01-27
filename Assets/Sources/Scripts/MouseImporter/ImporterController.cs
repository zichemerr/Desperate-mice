using UnityEngine;
using MerJame.PlayerSystem;
using System;
using System.Collections.Generic;
using MerJame.SoundsSystem;
using Unity.VisualScripting;

namespace MerJame.Importer
{
    public class ImporterController : MonoBehaviour
    {
        [SerializeField] private ImporterZone _zone;
        [SerializeField] private ImporterView _view;
        [SerializeField] private int _importCount;
        [SerializeField] private float _importSpeed;
        [SerializeField] private SoundSource _sound;

        private List<Mouse> _mouseImported;

        public MouseDestroyer MouseDestroyer { get; private set; }

        public event Action Assembled;

        public void Init()
        {
            MouseDestroyer = new MouseDestroyer(this, _importSpeed);
            _mouseImported = new List<Mouse>();
            _view.Init(_importCount);

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
            if (MouseDestroyer.IsDestroyed)
                return;

            _mouseImported.Add(mouse);
            _sound.Play(0.5f);
            _view.ShowValue(_mouseImported.Count);

            if (_mouseImported.Count == _importCount)
            {
                MouseDestroyer.Destroy(_mouseImported.ToArray());
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
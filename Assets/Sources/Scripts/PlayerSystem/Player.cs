using UnityEngine;
using MerJame.EventSystem;
using System.Collections.Generic;
using MerJame.Spawning;
using System;

namespace MerJame.PlayerSystem
{
    public class Player : MonoBehaviour
    {
        private PlayerMovement _playerMovement;
        private LosingGame _losingGame;
        private MouseSpawnerController _mouseSpawner;
        private List<Mouse> _mouses;

        public event Action MouseAlived;

        public void Init(PlayerMovement playerMovement, LosingGame losingGame, MouseSpawnerController mouseSpawner)
        {
            _playerMovement = playerMovement;
            _losingGame = losingGame;
            _mouseSpawner = mouseSpawner;
            _mouseSpawner.Spawned += OnSpawned;

            _mouses = new List<Mouse>();

            for (int i = 0; i < _playerMovement.MouseCount; i++)
            {
                OnSpawned(_playerMovement.GetMouse(i));
            }
        }

        private void OnDisable()
        {
            _mouseSpawner.Spawned -= OnSpawned;

            foreach (var mouse in _mouses)
                mouse.Destroyed -= OnDestroyed;
        }

        private void OnSpawned(Mouse mouse)
        {
            mouse.Destroyed += OnDestroyed;
            _mouses.Add(mouse);
        }

        private void OnDestroyed(Mouse mouse)
        {
            if (_playerMovement.MouseCount > 0)
            {
                MouseAlived?.Invoke();
                return;
            }

            _losingGame.Lose();
        }
    }
}
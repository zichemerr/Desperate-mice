using UnityEngine;
using MerJame.PlayerSystem;
using MerJame.Obstacle;
using System;

namespace MerJame.Spawning
{
    public class MouseSpawnerController : MonoBehaviour
    {
        [SerializeField] private PointSpawner[] _pointSpawner;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Mouse _mousePrefab;

        private MouseSpawner _spawner;
        private Box _box;

        public event Action<Mouse> Spawned;

        public void Init(Box box)
        {
            _spawner = new MouseSpawner(_mousePrefab);
            _box = box;
            Spawn(_spawner.Spawn(), _spawnPoint.position);

            foreach (var pointSpawner in _pointSpawner)
                pointSpawner.Entered += OnEntered;

        }

        private void OnDisable()
        {
            foreach (var pointSpawner in _pointSpawner)
                pointSpawner.Entered -= OnEntered;
        }

        private void OnEntered(Vector2 position, int spawnCount, PointSpawner pointSpawner)
        {
            Mouse[] mouses = _spawner.Spawn(spawnCount);

            foreach (var mouse in mouses)
            {
                Spawn(mouse, position);
            }

            pointSpawner.Entered -= OnEntered;
            _box.Enable();
        }

        private void Spawn(Mouse mouse, Vector2 position)
        {
            mouse.Init();
            mouse.SetPosition(position);
            Spawned?.Invoke(mouse);
        }
    }
}
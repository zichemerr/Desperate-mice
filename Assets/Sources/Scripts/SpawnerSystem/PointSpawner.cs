using MerJame.PlayerSystem;
using System;
using UnityEngine;

namespace MerJame.Spawning
{
    public class PointSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _point;
        [SerializeField] private int _spawnCount;

        public event Action<Vector2, int, PointSpawner> Entered;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<Mouse>())
            {
                Entered?.Invoke(_point.position, _spawnCount, this);
                Destroy(gameObject);
            }
        }
    }
}
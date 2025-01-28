using MerJame.Spawning;
using UnityEngine;

namespace MerJame.Obstacle
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Box : MonoBehaviour
    {
        [SerializeField] private PointSpawner _spawner;

        private Rigidbody2D _rigidbody;

        public void Init()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _spawner.Entered += OnEntered;
            _rigidbody.isKinematic = true;
        }

        private void OnDisable()
        {
            _spawner.Entered -= OnEntered;
        }

        private void OnEntered(Vector2 arg1, int arg2, PointSpawner arg3)
        {
            Disable();
        }

        public void Disable()
        {
            _rigidbody.isKinematic = false;
        }
    }
}
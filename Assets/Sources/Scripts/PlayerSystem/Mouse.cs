using UnityEngine.AI;
using UnityEngine;
using System;

namespace MerJame.PlayerSystem
{
    public class Mouse : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private float _speed;

        private NavMeshAgent _agent;
        private Vector2 Position => transform.position;

        public event Action<Mouse> Destroyed;

        public void Init()
        {
            _agent = GetComponent<NavMeshAgent>();
            _agent.updateRotation = false;
            _agent.updateUpAxis = false;
            _agent.speed = _speed;
        }

        public void Move(Vector2 target)
        {
            _agent.SetDestination(target);
            Vector2 direction = target - Position;

            if (direction.x > 0)
                _spriteRenderer.flipX = false;
            else
                _spriteRenderer.flipX = true;
        }

        public void SetPosition(Vector2 position)
        {
            transform.position = position;
        }

        public void Destroy()
        {
            Destroyed?.Invoke(this);
        }
    }
}
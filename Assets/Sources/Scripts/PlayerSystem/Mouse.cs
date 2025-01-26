using UnityEngine.AI;
using UnityEngine;
using System;

namespace MerJame.PlayerSystem
{
    public class Mouse : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private float _speed;

        public event Action<Mouse> Destroyed;

        public void Init()
        {
            _agent.updateRotation = false;
            _agent.updateUpAxis = false;
            _agent.speed = _speed;
        }

        internal void Move(Vector2 position)
        {
            _agent.SetDestination(position);
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
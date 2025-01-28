using DG.Tweening;
using MerJame.PlayerSystem;
using MerJame.SoundsSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MerJame.Ghost
{
    public class CatGhost : MonoBehaviour
    {
        [SerializeField] private Transform[] _pointsArray;
        [SerializeField] private Transform _circleSprite;
        [SerializeField] private SoundSource _soundSource;
        [SerializeField] private float _radius;
        [SerializeField] private float _time;

        private Queue<Transform> _points;

        public void Init()
        {
            InitQueue();
            StartCoroutine(PotrolRoutine());
        }

        private void InitQueue()
        {
            _points = new Queue<Transform>();

            foreach (var point in _pointsArray)
            {
                _points.Enqueue(point);
            }
        }

        private IEnumerator PotrolRoutine()
        {
            while (true)
            {
                Vector2 positon = Point().position;
                yield return transform.DOMove(positon, _time).WaitForCompletion();
                yield return _circleSprite.DOScale(3f, 0.2f).WaitForCompletion();
                _soundSource.Play();
                Attack(positon);
                yield return _circleSprite.DOScale(0, 0.2f).WaitForCompletion();
            }
        }

        private void Attack(Vector2 position)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(position, _radius);

            foreach (var collider in colliders)
            {
                if (collider.TryGetComponent(out Mouse mouse))
                {
                    mouse.Destroy();
                }
            }
        }

        private Transform Point()
        {
            if (_points.Count > 0)
            {
                return _points.Dequeue();
            }

            InitQueue();
            return _points.Dequeue();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, _radius);
        }
    }
}
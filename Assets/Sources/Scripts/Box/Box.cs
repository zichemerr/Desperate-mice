using UnityEngine;

namespace MerJame.Obstacle
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Box : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;

        public void Enable()
        {
            _rigidbody.isKinematic = false;
        }

        public void Disable()
        {
            _rigidbody.isKinematic = true;
        }
    }
}
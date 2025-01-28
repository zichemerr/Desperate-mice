using UnityEngine;

namespace MerJame.Obstacle
{
    public class BoxController : MonoBehaviour
    {
        [SerializeField] private Box[] _boxes;

        public void Init()
        {
            foreach (var box in _boxes)
            {
                box.Init();
            }
        }
    }
}
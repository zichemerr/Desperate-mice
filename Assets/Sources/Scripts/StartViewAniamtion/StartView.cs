using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace MerJame.StaringView
{
    public class StartView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private float _duration;

        private void Awake()
        {
            _image.color = Color.black;
        }

        public void Init()
        {
            _image.DOFade(0, _duration).onComplete += OnCompleted;
        }

        private void OnCompleted()
        {
            _image.gameObject.SetActive(false);
        }
    }
}
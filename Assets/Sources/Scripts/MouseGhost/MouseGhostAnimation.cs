using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace MerJame.Ghost
{
    public class MouseGhostAnimation : MonoBehaviour
    {
        [SerializeField] private Image _image;

        public void PlayAniamtion()
        {
            _image.DOFade(1, 0);
            _image.DOFade(0, 2f);
        }
    }
}
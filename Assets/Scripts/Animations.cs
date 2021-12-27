using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class Animations : MonoBehaviour
{
    [SerializeField] private float _fadeOutTextDuration;
    [SerializeField] private float _fadeInTextDuration;
    [SerializeField] private Ease _animBounceEase;
    [SerializeField] private float _animBounceDuration;
    [SerializeField] private Ease _animCorrectEase;
    [SerializeField] private float _errorDuration;
    [SerializeField] private GameObject _particleStars;




    public void FadeInText(Text text)
    {
        text.DOFade(1, _fadeInTextDuration);
    }
    
    public void FadeInImage(Image image)
    {
        image.gameObject.SetActive(true);
        image.DOFade(1, _fadeInTextDuration);
    }

    public void FadeOutImage(Image image)
    {
        image.DOFade(0, _fadeOutTextDuration);
    }

    public void BounceEffect(Transform transform)
    {
        transform.DOScale(0, 0);
        transform.DOScale(2, _animBounceDuration).SetEase(_animBounceEase);
    }

    public void ChooseFalseCard(Transform transform)
    {
        Sequence errorSequence = DOTween.Sequence();
        errorSequence.Append
            (transform.DOShakePosition(_errorDuration, strength: new Vector3(0.1f, 0, 0), vibrato: 8, randomness: 1, snapping: false, fadeOut: true))
            .Append(transform.DOLocalMoveX(0,_errorDuration));
    }

    public void ChooseCorrectCard(Transform transform)
    {
        transform.DOScale(0, _animBounceDuration).SetEase(_animCorrectEase);
        Instantiate(_particleStars, new Vector3(transform.position.x, transform.position.y, -5f), Quaternion.identity);
    }    
}

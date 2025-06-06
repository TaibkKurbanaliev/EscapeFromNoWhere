using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Slider _progressSlider;
    [SerializeField] private TMP_Text _completeText;
    [SerializeField] private float _fadeTime;
    [SerializeField] private float _fadeValue;

    public void SetProgress(float progress)
    {
        _progressSlider.value = progress;
    }

    public void ShowCompleteButton()
    {
        _progressSlider.gameObject.SetActive(false);
        _completeText.gameObject.SetActive(true);
        _completeText.DOColor(new Color(_completeText.color.r, _completeText.color.g, _completeText.color.b, _fadeValue), _fadeTime).SetLoops(-1, LoopType.Yoyo);
    }
}

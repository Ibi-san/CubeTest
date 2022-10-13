using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI
{
  public class HidePanelButton : MonoBehaviour
  {
    [SerializeField] private Button _hideButton;
    [SerializeField] private Button _showButton;
    [SerializeField] private RectTransform _panel;
    [SerializeField] private RectTransform _showButtonRect;
    [SerializeField] private float _duration = 1;
    [SerializeField] private float _showButtonOffset = 20;

    private void Start() => 
      _hideButton.onClick.AddListener(HidePanel);

    private void HidePanel()
    {
      _hideButton.interactable = false;
      StartCoroutine(Hide());
    }

    private IEnumerator Hide()
    {
      float timeElapsed = 0;
      Vector2 startPosition = _panel.anchoredPosition;
      Vector2 panelEndPosition = startPosition + Vector2.left * _panel.sizeDelta.x;
      while (timeElapsed < _duration)
      {
        _panel.anchoredPosition = Vector2.Lerp(startPosition, panelEndPosition, timeElapsed / _duration);
        timeElapsed += Time.deltaTime;
        yield return null;
      }
      _panel.anchoredPosition = panelEndPosition;

      StartCoroutine(ShowButton());
    }

    private IEnumerator ShowButton()
    {
      float timeElapsed = 0;
      Vector2 startPosition = _showButtonRect.anchoredPosition;
      Vector2 buttonEndPosition = startPosition + Vector2.down * (_showButtonRect.sizeDelta.y + _showButtonOffset);
      while (timeElapsed < _duration)
      {
        _showButtonRect.anchoredPosition = Vector2.Lerp(startPosition, buttonEndPosition, timeElapsed / _duration);
        timeElapsed += Time.deltaTime;
        yield return null;
      }
      _showButtonRect.anchoredPosition = buttonEndPosition;
      _showButton.interactable = true;
    }
  }
}
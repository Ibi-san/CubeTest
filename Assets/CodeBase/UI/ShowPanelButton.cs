using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI
{
  public class ShowPanelButton : MonoBehaviour
  {
    [SerializeField] private Button _showButton;
    [SerializeField] private Button _hideButton;
    [SerializeField] private RectTransform _showButtonRect;
    [SerializeField] private RectTransform _panel;
    [SerializeField] private float _duration = 1;
    [SerializeField] private float _showButtonOffset = 20;

    private void Start() => 
      _showButton.onClick.AddListener(ShowPanel);

    private void ShowPanel()
    {
      _showButton.interactable = false;
      StartCoroutine(HideButton());
    }

    private IEnumerator HideButton()
    {
      float timeElapsed = 0;
      Vector2 startPosition = _showButtonRect.anchoredPosition;
      Vector2 buttonEndPosition = startPosition + Vector2.up * (_showButtonRect.sizeDelta.y + _showButtonOffset);
      
      while (timeElapsed < _duration)
      {
        _showButtonRect.anchoredPosition = Vector2.Lerp(startPosition, buttonEndPosition, timeElapsed / _duration);
        timeElapsed += Time.deltaTime;
        yield return null;
      }
      
      _showButtonRect.anchoredPosition = buttonEndPosition;
      
      StartCoroutine(PanelAppear());
    }

    private IEnumerator PanelAppear()
    {
      float timeElapsed = 0;
      Vector2 startPosition = _panel.anchoredPosition;
      Vector2 panelEndPosition = startPosition + Vector2.right * _panel.sizeDelta.x;
      while (timeElapsed < _duration)
      {
        _panel.anchoredPosition = Vector2.Lerp(startPosition, panelEndPosition, timeElapsed / _duration);
        timeElapsed += Time.deltaTime;
        yield return null;
      }
      _panel.anchoredPosition = panelEndPosition;
      _hideButton.interactable = true;
    }
  }
}
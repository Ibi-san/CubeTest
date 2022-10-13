using CodeBase.GameLogic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI
{
  public class SpawnButton : MonoBehaviour
  {
    [SerializeField] private Button _button;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private TMP_InputField _distanceInput;
    [SerializeField] private TMP_InputField _speedInput;
    [SerializeField] private TMP_InputField _intervalInput;
    [SerializeField] private GameObject _errorText;
    private int _distance;
    private int _speed;
    private int _interval;

    private bool _dataIsCorrect;
    private void Start() => 
      _button.onClick.AddListener(CallSpawner);

    private void ParseInput()
    {
      if (_distanceInput.text.Length < 1 || _speedInput.text.Length < 1 || _intervalInput.text.Length < 1)
      {
        _dataIsCorrect = false;
        _errorText.SetActive(true);
        return;
      }
      _distance = int.Parse(_distanceInput.text);
      _speed = int.Parse(_speedInput.text);
      _interval = int.Parse(_intervalInput.text);
      _dataIsCorrect = true;
      _errorText.SetActive(false);
    }

    private void CallSpawner()
    {
      ParseInput();
      if (!_dataIsCorrect) return;
      _spawner.StopAllCoroutines();
      _spawner.StartSpawner(_spawnPoint.position, _distance, _speed, _interval);
    }
  }
}
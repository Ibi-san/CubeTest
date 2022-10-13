using CodeBase.GameLogic;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI
{
  public class StopSpawnerButton : MonoBehaviour
  {
    [SerializeField] private Button _button;
    [SerializeField] private Spawner _spawner;

    private void Start() => 
      _button.onClick.AddListener(StopSpawner);

    private void StopSpawner() => 
      _spawner.StopAllCoroutines();
  }
}
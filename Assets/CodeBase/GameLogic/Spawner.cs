using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

namespace CodeBase.GameLogic
{
  public class Spawner : MonoBehaviour
  {
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private bool _usePool;
    [SerializeField] private int _defaultCapacity = 10;
    [SerializeField] private int _maxSize = 20;
    [SerializeField] private int _spawnAmount;
    private ObjectPool<Cube> _pool;

    private void Start() => 
      CreatePool();

    private void CreatePool()
    {
      _pool = new ObjectPool<Cube>(() => Instantiate(_cubePrefab),
        cube => cube.gameObject.SetActive(true),
        cube => cube.gameObject.SetActive(false),
        cube => Destroy(cube.gameObject),
        false,
        _defaultCapacity,
        _maxSize);
    }

    public void StartSpawner(Vector3 at, int distance, int speed, int spawnInterval)
    {
      StartCoroutine(Spawn(at, distance, speed, spawnInterval));
    }

    private IEnumerator Spawn(Vector3 at, int distance, int speed, int spawnInterval)
    {
      while (true)
      {
        var cube = _usePool ? _pool.Get() : Instantiate(_cubePrefab);
        cube.transform.position = at;
        cube.Initialize(KillCube, distance, speed, out var cubeMovement);
        cubeMovement.Initialize(cube);
        yield return new WaitForSeconds(spawnInterval);
      }
    }

    private void KillCube(Cube cube)
    {
      if (_usePool) 
        _pool.Release(cube);
      else 
        Destroy(cube.gameObject);
    }
  }
}
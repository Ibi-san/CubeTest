using UnityEngine;

namespace CodeBase.GameLogic
{
  public class CubeMovement : MonoBehaviour
  {
    private Vector3 _targetPosition;
    private Cube _cube;

    private void Update() => 
      MoveCube();

    public void Initialize(Cube cube)
    {
      _cube = cube;
      InitializeTarget();
    }

    private void InitializeTarget()
    {
      var position = transform.position;
      _targetPosition = new Vector3(_cube.Distance, position.y, position.z);
    }

    private void MoveCube()
    {
      transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _cube.Speed * Time.deltaTime);

      if (transform.position == _targetPosition) 
        _cube.Kill();

    }
  }
}
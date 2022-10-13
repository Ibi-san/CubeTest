using System;
using UnityEngine;

namespace CodeBase.GameLogic
{
  [RequireComponent(typeof(CubeMovement))]
  public class Cube : MonoBehaviour
  {
    private const string BorderTag = "Border";

    public int Speed;
    public int Distance;

    private Action<Cube> _killAction;

    public void Initialize(Action<Cube> killAction, int distance, int speed, out CubeMovement cubeMovement)
    {
      _killAction = killAction;
      Speed = speed;
      Distance = distance;
      cubeMovement = GetComponent<CubeMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
      if (other.transform.CompareTag(BorderTag))
        Kill();
    }

    public void Kill() => 
      _killAction(this);
  }
}
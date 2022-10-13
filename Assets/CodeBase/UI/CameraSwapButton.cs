using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI
{
    public class CameraSwapButton : MonoBehaviour
    {
        [SerializeField] private Button _swapButton;
        [SerializeField] private Transform _pos1;
        [SerializeField] private Transform _pos2;
        [SerializeField] private Transform _camera;
        private bool _mainPos = true;
        private void Start() => 
            _swapButton.onClick.AddListener(SwapCamera);

        private void SwapCamera()
        {
            if (_mainPos)
            {
                _mainPos = false;
                _camera.position = _pos2.position;
                _camera.rotation = _pos2.rotation;
            }
            else
            {
                _mainPos = true;
                _camera.position = _pos1.position;
                _camera.rotation = _pos1.rotation;
            }
        
        }
    }
}

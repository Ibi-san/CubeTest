using TMPro;
using UnityEngine;

namespace CodeBase.UI
{
    [RequireComponent(typeof(TMP_InputField))]
    public class InputHandler : MonoBehaviour
    {
        private TMP_InputField _inputField;
        // Start is called before the first frame update
        private void Start()
        {
            _inputField = GetComponent<TMP_InputField>();
            _inputField.onValueChanged.AddListener(ValidateInput);
        }

        private void ValidateInput(string input)
        {
            if (input.Contains('-'))
                _inputField.text = input.Replace("-", "");
        }
    }
}

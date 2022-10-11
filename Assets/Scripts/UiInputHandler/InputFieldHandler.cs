using TMPro;
using UnityEngine;

namespace UiInputHandler
{
    public class InputFieldHandler : MonoBehaviour
    {
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private TextMeshProUGUI textFIeld;
        
        public int InputData { get; set; }
        public bool ValideData { get; private set; }

        private string defaultText;
        
        private void OnEnable()
        {
            inputField.onValueChanged.AddListener(ParseString);
        }

        private void OnDisable()
        {
            inputField.onValueChanged.RemoveListener(ParseString);
        }

        private void Awake()
        {
            defaultText = textFIeld.text;
        }

        private void ParseString(string inputString)
        {
            if (int.TryParse(inputString, out int result))
            {
                InputData = result;
                ValideData = true;
                SetText(defaultText);
            }
            else
                FailedToParse();
        }

        private void FailedToParse()
        {
            SetText("Введите данные в корректном формате");
            ValideData = false;
        }

        private void SetText(string text)
        {
            textFIeld.text = text;
        }
    }
}
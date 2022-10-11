using UnityEngine;

namespace UiInputHandler
{
    public class InputHandler : MonoBehaviour
    {
        [Header("Input Fields")]
        [SerializeField] private InputFieldHandler timeValue;
        [SerializeField] private InputFieldHandler speedValue;
        [SerializeField] private InputFieldHandler distanceValue;

        [Space(5)] 
        [SerializeField] private FactoryData factoryData;

        public void TryStartScene()
        {
            if (InputDataIsValid())
            {
                SaveInputData();
            }
        }

        private bool InputDataIsValid()
        {
            return timeValue.ValideData && speedValue.ValideData && distanceValue.ValideData;
        }

        private void SaveInputData()
        {
            factoryData.SaveNewData(timeValue.InputData, speedValue.InputData, distanceValue.InputData);
        }
    }
}
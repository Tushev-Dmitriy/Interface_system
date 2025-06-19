using UnityEngine;
using TMPro;

public class DynamicHintLabel : MonoBehaviour
{
    public ActionName actionName;
    public ControlSchemeHints hintData;
    public TextMeshProUGUI label;

    private void OnEnable()
    {
        UpdateText(InputDeviceDetector.currentDevice);
        InputDeviceDetector.OnDeviceChanged += UpdateText;
    }

    private void OnDisable()
    {
        InputDeviceDetector.OnDeviceChanged -= UpdateText;
    }

    void UpdateText(InputDeviceDetector.DeviceType device)
    {
        if (label != null && hintData != null) label.text = hintData.GetHint(actionName, device);
    }
}

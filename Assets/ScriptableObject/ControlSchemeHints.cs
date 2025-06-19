using UnityEngine;

[CreateAssetMenu(menuName = "UI/ControlSchemeHints")]
public class ControlSchemeHints : ScriptableObject
{
    [Header("Submit")]
    public string submitHintKeyboard = "Enter";
    public string submitHintXbox = "A";
    public string submitHintPlayStation = "X";

    [Header("Cancel")]
    public string cancelHintKeyboard = "Esc";
    public string cancelHintXbox = "B";
    public string cancelHintPlayStation = "O";

    [Header("Past Action")]
    public string pastHintKeyboard = "Q";
    public string pastHintXbox = "LB";
    public string pastHintPlayStation = "L1";

    public string GetHint(ActionName actionName, InputDeviceDetector.DeviceType device)
    {
        return actionName switch
        {
            ActionName.Submit => device switch
            {
                InputDeviceDetector.DeviceType.XboxGamepad => submitHintXbox,
                InputDeviceDetector.DeviceType.PlayStationGamepad => submitHintPlayStation,
                _ => submitHintKeyboard
            },
            ActionName.Cancel => device switch
            {
                InputDeviceDetector.DeviceType.XboxGamepad => cancelHintXbox,
                InputDeviceDetector.DeviceType.PlayStationGamepad => cancelHintPlayStation,
                _ => cancelHintKeyboard
            },
            ActionName.Past => device switch
            {
                InputDeviceDetector.DeviceType.XboxGamepad => pastHintXbox,
                InputDeviceDetector.DeviceType.PlayStationGamepad => pastHintPlayStation,
                _ => pastHintKeyboard
            },
            _ => "?"
        };
    }
}

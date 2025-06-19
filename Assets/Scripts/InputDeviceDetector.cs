using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.InputSystem.Utilities;

public class InputDeviceDetector : MonoBehaviour
{
    public enum DeviceType { KeyboardMouse, XboxGamepad, PlayStationGamepad }
    public static DeviceType currentDevice { get; private set; }
    public static event Action<DeviceType> OnDeviceChanged;

    private void OnEnable()
    {
        DetectInitialDevice();

        InputSystem.onAnyButtonPress.CallOnce(ctrl =>
        {
            DetectDevice(ctrl.device);
        });
    }

    private static void DetectInitialDevice()
    {
        foreach (var device in InputSystem.devices)
        {
            if (device is Gamepad gamepad)
            {
                DetectDevice(gamepad);
                return;
            }
        }

        SwitchDevice(DeviceType.KeyboardMouse);
    }

    private static void DetectDevice(InputDevice device)
    {
        if (device is Gamepad)
        {
            string deviceName = device.name.ToLower();
            if (deviceName.Contains("xinput"))
            {
                SwitchDevice(DeviceType.XboxGamepad);
            } else if (deviceName.Contains("dualshock") || deviceName.Contains("dualsense"))
            {
                SwitchDevice(DeviceType.PlayStationGamepad);
            }
        }
        else
        {
            SwitchDevice(DeviceType.KeyboardMouse);
        }
    }

    private static void SwitchDevice(DeviceType device)
    {
        currentDevice = device;
        OnDeviceChanged?.Invoke(device);
        Debug.Log("Текущий девайс: " + currentDevice);
    }
}

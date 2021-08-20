using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    public List<GameObject> controllerPrefabs;
    private InputDevice targetDevice;

    private GameObject spawnedController;
    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics rightControllerCharacteristics =
            InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics,devices);

        foreach (var device in devices)
        {
            Debug.Log(device.name + device.characteristics);
        }

        if (devices.Count > 0)
        {
            targetDevice = devices[0];
            GameObject prefab = controllerPrefabs.Find(
                controller => controller.name == targetDevice.name);
            if (prefab)
            {
                spawnedController = Instantiate(prefab, transform);
            }
            else
            {
                Debug.LogError("Did not find matched controller model.");
                spawnedController = Instantiate(controllerPrefabs[0], transform);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton,out bool primaryButtonValue);
        if(primaryButtonValue)
            Debug.Log("Pressing Primary Button");
        targetDevice.TryGetFeatureValue(CommonUsages.trigger,out float triggerValue);
        if(triggerValue > 0.1f)
            Debug.Log("Trigger Pressed" + triggerValue);
        targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis,out Vector2 primary2DAxisValue);
        if(primary2DAxisValue != Vector2.zero)
            Debug.Log("Primary Touchpad " + primary2DAxisValue);
    }
}

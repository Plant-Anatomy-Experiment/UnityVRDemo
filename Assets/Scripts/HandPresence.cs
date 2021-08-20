using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    public bool showController = false;
    
    public List<GameObject> controllerPrefabs;
    private InputDevice targetDevice;

    private GameObject spawnedController;

    public GameObject handModelPrefab;

    private GameObject spawnedHandModel;
    
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
            
            spawnedHandModel = Instantiate(handModelPrefab, transform);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (showController)
        {
            spawnedController.SetActive(true);
            spawnedHandModel.SetActive(false);
        }
        else
        {
            spawnedController.SetActive(false);
            spawnedHandModel.SetActive(true);
        }
    }
}

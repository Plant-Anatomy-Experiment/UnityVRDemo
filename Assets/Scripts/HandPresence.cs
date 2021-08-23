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
    
    private Animator HandAnimator;
    
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
            HandAnimator = spawnedHandModel.GetComponent<Animator>();
        }

    }

    void UpdateHandAnimation()
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            HandAnimator.SetFloat("Trigger",triggerValue);
        }
        else
        {
            HandAnimator.SetFloat("Trigger",0f);
        }
        
        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            HandAnimator.SetFloat("Grip",gripValue);
        }
        else
        {
            HandAnimator.SetFloat("Grip",0f);
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
            UpdateHandAnimation();
        }
    }
}

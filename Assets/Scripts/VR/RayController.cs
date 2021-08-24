using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class RayController : MonoBehaviour
{
    public XRController leftRay;
    
    public XRController rightRay;
    
    public InputHelpers.Button rayActivationButton;

    public float activationThreshold = 0.1f;
    
    // Update is called once per frame
    void Update()
    {
        leftRay.gameObject.SetActive(CheckIfActivated(leftRay));
        rightRay.gameObject.SetActive(CheckIfActivated(rightRay));
    }

    public bool CheckIfActivated(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, rayActivationButton, out bool isActivated, activationThreshold);
        return isActivated;
    }
}

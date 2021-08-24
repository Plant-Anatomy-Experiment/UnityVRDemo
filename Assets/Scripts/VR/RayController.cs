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

    public InputHelpers.Button rayDeactivationButton;

    public bool isLeftActive;

    public bool isRightActive;

    public float activationThreshold = 0.1f;
    
    // Update is called once per frame
    void Update()
    {
        InputHelpers.IsPressed(leftRay.inputDevice, rayActivationButton, out bool leftActivePressed, activationThreshold);
        if(leftActivePressed)
        {
            isLeftActive = true;
        }
        InputHelpers.IsPressed(leftRay.inputDevice, rayDeactivationButton, out bool leftDeactivePressed, activationThreshold);
        if (leftDeactivePressed)
        {
            isLeftActive = false;
        }
        InputHelpers.IsPressed(rightRay.inputDevice, rayActivationButton, out bool rightActivePressed, activationThreshold);
        if (rightActivePressed)
        {
            isRightActive = true;
        }
        InputHelpers.IsPressed(rightRay.inputDevice, rayDeactivationButton, out bool righDeactivePressed, activationThreshold);
        if (righDeactivePressed)
        {
            isRightActive = false;
        }
        leftRay.gameObject.SetActive(isLeftActive);
        rightRay.gameObject.SetActive(isRightActive);
    }

    public void SetLeftInactive()
    {
        isLeftActive = false;
    }

    public void SetRightInactive()
    {
        isRightActive = false;
    }
}

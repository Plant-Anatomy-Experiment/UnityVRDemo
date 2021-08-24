using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class TweezersVRInteraction : MonoBehaviour
{
    public GameObject downHandle;
    public GameObject downEdge;
    public GameObject upHandle;
    public GameObject upEdge;
    
    public GameObject upHandleNotUse;
    public GameObject upEdgeNotUse;
    public GameObject upHandleUse;
    public GameObject upEdgeUse;

    private List<MeshRenderer> meshs;
    
    public Material selectedMat;

    public Material originalMat;

    private void Start()
    {
        meshs = new List<MeshRenderer>();
        meshs.Add(downHandle.GetComponent<MeshRenderer>());
        meshs.Add(downEdge.GetComponent<MeshRenderer>());
        meshs.Add(upHandle.GetComponent<MeshRenderer>());
        meshs.Add(upEdge.GetComponent<MeshRenderer>());
    }

    public void OnXRHoverEnter()
    {
        foreach (var mesh in meshs)
        {
            mesh.material = selectedMat;
        }
    }
    
    public void OnXRHoverExit()
    {
        foreach (var mesh in meshs)
        {
            mesh.material = originalMat;
        }
    }

    public void OnXRActivate()
    {
        upHandle.transform.position = upHandleUse.transform.position;
        upHandle.transform.rotation = upHandleUse.transform.rotation;
        upEdge.transform.position = upEdgeUse.transform.position;
        upEdge.transform.rotation = upEdgeUse.transform.rotation;
    }
    
    public void OnXRDeactivate()
    {
        upHandle.transform.position = upHandleNotUse.transform.position;
        upHandle.transform.rotation = upHandleNotUse.transform.rotation;
        upEdge.transform.position = upEdgeNotUse.transform.position;
        upEdge.transform.rotation = upEdgeNotUse.transform.rotation;
    }
}

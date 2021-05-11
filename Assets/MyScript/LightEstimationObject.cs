using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class LightEstimationObject : MonoBehaviour
{
    [SerializeField]
    ARCameraManager m_CameraManager;

    private Renderer[] renderers;

    void OnEnable()
    {
        renderers = GetComponentsInChildren<Renderer>();

        if (m_CameraManager != null)
            m_CameraManager.frameReceived += FrameChanged;
    }

    void OnDisable()
    {
        renderers = null;

        if (m_CameraManager != null)
            m_CameraManager.frameReceived -= FrameChanged;
    }

    void FrameChanged(ARCameraFrameEventArgs args)
    {
        foreach (Renderer renderer in renderers)
        {
            renderer.material.SetFloat(
                                    "_Brightness",
                                    args.lightEstimation.averageBrightness.Value
                                    );
        }
    }
}

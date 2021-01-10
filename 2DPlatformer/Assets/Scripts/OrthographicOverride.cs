using Cinemachine;
using UnityEngine;
using UnityEngine.U2D;
using System.Reflection;

/// <summary>
/// Add this component to a camera that has PixelPerfectCamera and CinemachineBrain
/// components to prevent the active CinemachineVirtualCamera from overwriting the
/// correct orthographic size as calculated by the PixelPerfectCamera.
/// </summary>
[RequireComponent(typeof(PixelPerfectCamera), typeof(CinemachineBrain))]
internal class OrthographicOverride : MonoBehaviour
{
    private CinemachineBrain _cb;
    private object _internal; // PixelPerfectCameraInternal
    private FieldInfo _orthoInfo;

    private void Start()
    {
        _cb = GetComponent<CinemachineBrain>();
        // ReSharper disable once PossibleNullReferenceException
        _internal = typeof(PixelPerfectCamera)
            .GetField("m_Internal", BindingFlags.NonPublic | BindingFlags.Instance)
            .GetValue(GetComponent<PixelPerfectCamera>());
        _orthoInfo = _internal.GetType().GetField("orthoSize", BindingFlags.NonPublic | BindingFlags.Instance);
    }

    private void LateUpdate()
    {
        var cam = _cb.ActiveVirtualCamera as CinemachineVirtualCamera;
        if (cam)
            cam.m_Lens.OrthographicSize = (float)_orthoInfo.GetValue(_internal);
    }
}

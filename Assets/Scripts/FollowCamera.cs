using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform follow;
    public float cameraHeight = 15f;
    public Vector2 CameraOffset;

    private Vector3 focus;

    void Start()
    {
        focus = follow.position;
    }

    private void LateUpdate()
    {
        Vector3 offset = new Vector3(CameraOffset.x, 0f, CameraOffset.y);
        transform.position = focus + Vector3.up * cameraHeight + offset;
        transform.LookAt(focus);

        FocusUpdate();
    }

    private Vector3 velocity;
    private void FocusUpdate()
    {
        focus = Vector3.SmoothDamp(focus, follow.position, ref velocity , 1f);
    }

}

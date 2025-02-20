using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float followingSpeed = 1f;

    [SerializeField] protected Vector2 MinCam;
    [SerializeField] protected Vector2 MaxCam;

    private void Start()
    {
        if (target == null)
            return;
    }
    //카메라가 자연스럽게 따라가도록 Lerp. 그리고 이동 반경 제한을 위한 Clamp
    private void FixedUpdate()
    {
        if(target == null) return;

        Vector3 pos = Vector3.Lerp(transform.position, target.position, followingSpeed * Time.deltaTime);

        transform.position = new Vector3(
            Mathf.Clamp(pos.x,MinCam.x,MaxCam.x)
            , Mathf.Clamp(pos.y, MinCam.y, MaxCam.y),
            - 10);
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class VehicleController : BaseController
{
    public bool Turn = false;
    [SerializeField] private Transform ridePos;
    public Transform RidePos { get { return ridePos; } }
    private Camera camera;

    private void Start()
    {
        camera = Camera.main;
        ridePos = transform.Find("RidePos");
    }

    void OnMove(InputValue inputValue)
    {
        if (Turn)
        {
            movementDirection = !UIManager.instance.IsAction ? inputValue.Get<Vector2>() : Vector2.zero;
            movementDirection = movementDirection.normalized;
        }
    }

    void OnLook(InputValue inputValue)
    {
        if (Turn)
        {
            Vector2 mousePosition = inputValue.Get<Vector2>();
            Vector2 worldPos = camera.ScreenToWorldPoint(mousePosition);
            lookDirection = (worldPos - (Vector2)transform.position);

            if (lookDirection.magnitude < .9f)
            {
                lookDirection = Vector2.zero;
            }
            else
            {
                lookDirection = lookDirection.normalized;
            }
        }
    }

    protected override void Rotate(Vector2 direction)
    {
        if (Turn)
        {
            base.Rotate(direction);
        }
    }
}

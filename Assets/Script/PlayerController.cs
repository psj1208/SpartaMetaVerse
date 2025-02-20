using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : BaseController
{
    // Start is called before the first frame update
    private bool CanMove = true;
    private Camera camera;
    [SerializeField] private PlayerEquip pEquip;
    [SerializeField] float detectionRadius = 5.0f;
    [SerializeField] private LayerMask Interaction;

    private void Start()
    {
        if (CanMove)
        {
            camera = Camera.main;
            pEquip = GetComponent<PlayerEquip>();
        }
    }

    protected override void Update()
    {
        base.Update();
        /*
        Collider2D col = Physics2D.OverlapCircle(transform.position, detectionRadius, Interaction);
        if (col != null)
        {
            if (Input.GetKey(KeyCode.E))
            {
                Ride(col.gameObject);
            }
        }
        */
    }
    void OnMove(InputValue inputValue)
    {
        if (CanMove)
        {
            movementDirection = !UIManager.instance.IsAction ? inputValue.Get<Vector2>() : Vector2.zero;
            movementDirection = movementDirection.normalized;
        }
    }

    void OnLook(InputValue inputValue)
    {
        if (CanMove)
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
        base.Rotate(direction);
        pEquip.flipAcc(IsLeft);
    }

    public void ChangeAccessory(Sprite sprite)
    {
        pEquip.Accessory = sprite;
    }

    public void Interact(GameObject obj)
    {
        
    }
    
    /*
    private void Ride(GameObject ride)
    {
        if (pEquip.isBoard == false)
        {
            pEquip.isBoard = true;
            
        }
        else
        {
            pEquip.isBoard = false;
        }
    }
    */

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}

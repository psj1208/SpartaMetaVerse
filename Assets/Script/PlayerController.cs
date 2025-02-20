using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : BaseController
{
    // Start is called before the first frame update
    private bool canMove = true;
    private Camera camera;
    [SerializeField] private PlayerEquip pEquip;
    [SerializeField] float detectionRadius = 5.0f;
    [SerializeField] private LayerMask Interaction;
    [Header("Å¾½Â °ü·Ã")]
    [SerializeField] private GameObject riding;
    [SerializeField] private StatHandler originalStat;
    [SerializeField] private AnimationHandler originalAnim;
    bool isRiding = false;

    private void Start()
    {
        camera = Camera.main;
        pEquip = GetComponent<PlayerEquip>();
    }

    protected override void Update()
    {
        canMove = !UIManager.instance.IsSelecting && !UIManager.instance.IsAction;
        base.Update();
        Collider2D col = Physics2D.OverlapCircle(transform.position, detectionRadius, Interaction);
        if (col != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!UIManager.instance.IsSelecting && isRiding == false)
                    col.gameObject.GetComponent<BaseInteract>().Interact();
                else if (isRiding == true)
                    Ride();
            }
        }
    }
    void OnMove(InputValue inputValue)
    {
        if (canMove)
        {
            movementDirection = !UIManager.instance.IsAction ? inputValue.Get<Vector2>() : Vector2.zero;
            movementDirection = movementDirection.normalized;
        }
        else
            movementDirection = Vector2.zero;
    }

    void OnLook(InputValue inputValue)
    {
        if (canMove)
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
        if (canMove)
        {
            base.Rotate(direction);
            pEquip.flipAcc(IsLeft);
            if (riding == true)
                statHandler.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = IsLeft;
        }
    }

    public void ChangeAccessory(Sprite sprite)
    {
        pEquip.Accessory = sprite;
    }

    public void Ride(StatHandler stat = null, AnimationHandler animation = null)
    {
        animationHandler.StopAnim();
        if (isRiding == false)
        {
            isRiding = true;
            stat.transform.SetParent(riding.transform, false);
            stat.transform.localPosition = Vector2.zero;
            characterSprite.transform.position = new Vector2(characterSprite.transform.position.x, characterSprite.transform.position.y + 0.3f);
            originalStat = statHandler;
            originalAnim = animationHandler;
            statHandler = stat;
            animationHandler = animation;
        }
        else
        {
            isRiding = false;
            riding.transform.GetChild(0).SetParent(null);
            characterSprite.transform.position = new Vector2(characterSprite.transform.position.x, characterSprite.transform.position.y - 0.3f);
            statHandler = originalStat;
            animationHandler = originalAnim;
            originalStat = null;
            originalAnim = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}

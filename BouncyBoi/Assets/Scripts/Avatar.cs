using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Idle,
    Move,
    Jump,
    Compact
}

public class Avatar : MonoBehaviour
{
    //FSM
    public PlayerState CurrentState { get; private set; }

    //References
    private PlayerInputHandler playerInputHandler;
    public AvatarData avatarData;
    private Rigidbody2D avatarRB;
    private SpriteRenderer avatarSpriteRenderer;
    private BoxCollider2D avatarCollider;

    private void Awake()
    {
        
    }

    private void Start()
    {
        //Instances Acquirement
        playerInputHandler = this.GetComponent<PlayerInputHandler>();
        avatarRB = this.GetComponent<Rigidbody2D>();
        avatarSpriteRenderer = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
        avatarCollider = this.GetComponent<BoxCollider2D>();


        InitializeAvatar();
    }

    private void Update()
    {
        LogicUpdate();
    }

    private void FixedUpdate()
    {
        PhysicsUpdate();
    }

    private void LogicUpdate()
    {
        switch (CurrentState)
        {
            case PlayerState.Idle:

                IdleStateBehavior();
                IdleStateTransitions();

                break;
            case PlayerState.Move:

                MoveStateBehavior();
                MoveStateTransitions();

                break;
            case PlayerState.Jump:
                break;
            case PlayerState.Compact:

                CompactStateBehavior();
                CompactStateTransitions();

                break;
            default:
                break;
        }
    }

    private void PhysicsUpdate()
    {
        Docheck();
    }

    private void Docheck()
    {
        Debug.Log("is grounded : " + IsGrounded());
    }

    private void IdleStateBehavior()
    {

    }

    private void IdleStateTransitions()
    {
        if (playerInputHandler.MovementInput.x != 0f)
        {
            CurrentState = PlayerState.Move;
        }
        else if (playerInputHandler.CompactInput)
        {
            CurrentState = PlayerState.Compact;
        }
    }

    private void MoveStateBehavior()
    {
        avatarRB.AddForce(Vector2.right * playerInputHandler.MovementInput.x * avatarData.moveSpeed, ForceMode2D.Force);
    }

    private void MoveStateTransitions()
    {
        if (playerInputHandler.MovementInput.x == 0f)
        {
            CurrentState = PlayerState.Idle;

        }
        else if (playerInputHandler.CompactInput)
        {
            CurrentState = PlayerState.Compact;
        }
    }

    private void CompactStateBehavior()
    {
        avatarSpriteRenderer.color = Color.red;
    }

    private void CompactStateTransitions()
    {
        if (!playerInputHandler.CompactInput)
        {
            avatarSpriteRenderer.color = Color.white;

            if (playerInputHandler.MovementInput.x == 0f)
            {
                CurrentState = PlayerState.Idle;
            }
            else
            {
                CurrentState = PlayerState.Move;
            }
        }
    }

    private void InitializeAvatar()
    {
        //Initialize FSM
        CurrentState = PlayerState.Idle;
    }

    public bool IsGrounded()
    {
        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, avatarCollider.size * 1.1f, 0f);

        foreach (Collider2D hit in hits)
        {
            if (hit == avatarCollider)
            {
                continue;
            }

            ColliderDistance2D colliderDistance = hit.Distance(avatarCollider);

            if (Vector2.Angle(colliderDistance.normal, Vector2.up) == 0f)
            {
                return true;
            }
        }

        return false;
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avatar : MonoBehaviour
{
    //FSM
    public PlayerState CurrentState { get; private set; }

    //References
    private PlayerInputHandler playerInputHandler;
    public AvatarData avatarData;

    private void Awake()
    {
        
    }

    private void Start()
    {
        playerInputHandler = this.GetComponent<PlayerInputHandler>();


        InitializeAvatar();
    }

    private void Update()
    {
        switch (CurrentState)
        {
            case PlayerState.Idle:
                break;
            case PlayerState.Move:
                break;
            case PlayerState.Jump:
                break;
            case PlayerState.Compact:
                break;
            default:
                break;
        }


    }

    private void InitializeAvatar()
    {
        CurrentState = PlayerState.Idle;
    }
}

public enum PlayerState
{
    Idle,
    Move,
    Jump,
    Compact
}

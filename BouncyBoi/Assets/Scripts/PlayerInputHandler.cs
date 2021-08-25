using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    #region Variables

    public Vector2 MovementInput { get; private set; }
    public bool JumpInput { get; private set; }
    public bool CompactInput { get; private set; }

    #endregion

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        MovementInput = context.ReadValue<Vector2>();
    }

    public void OnCompactInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            CompactInput = true;
        }
        else
        {
            CompactInput = false;
        }
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (context.started)
            {
                JumpInput = true;
            }
        }
    }

    /// <summary>
    /// Call this to set JumpInput back to false after using it.
    /// </summary>
    public void UseJumpInput() => JumpInput = false;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameInput gameInput;


    private bool isWalking;

    private void Update()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        if ((inputVector.x > 0f && transform.position.x < 4f) ||
            (inputVector.x < 0f && transform.position.x > -4f))
        {
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        isWalking = moveDir != Vector3.zero;
        }
        else
        {
            
        }

    }


    public bool IsWalking()
    {
        return isWalking;
    }
}

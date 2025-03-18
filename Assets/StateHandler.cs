using System;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class StateAPI
{
    public enum StateType
    {
        Still,
        Walking,
        Jumping,
        Falling
    }

    public static StateType CheckState(GameObject gameObject)
    {
        StateType returnState = StateType.Still;
        try
        {
            if (gameObject.GetComponent<MovementHandler>().OnGround && gameObject.GetComponent<Rigidbody2D>().velocity.x != 0f)
            {
                returnState = StateType.Walking;
            }
            if (gameObject.GetComponent<MovementHandler>().OnGround && gameObject.GetComponent<Rigidbody2D>().velocity.x == 0f)
            {
                returnState = StateType.Still;
            }

            if (!gameObject.GetComponent<MovementHandler>().OnGround && gameObject.GetComponent<Rigidbody2D>().velocity.y > 0)
            {
                returnState = StateType.Jumping;
            }
            if (!gameObject.GetComponent<MovementHandler>().OnGround && gameObject.GetComponent<Rigidbody2D>().velocity.y < 0)
            {
                returnState = StateType.Falling;
            }
        }

        catch (Exception e)
        {
            return StateType.Still;
        }

        return returnState;
    }
}

public class StateHandler : MonoBehaviour
    {
    public StateAPI.StateType State { get; set; } = StateAPI.StateType.Still;
    public string StateName;

    public void Update()
        {
            State = StateAPI.CheckState(gameObject);
            StateName = State.ToString();
        }
    }


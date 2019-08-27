using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickPlayerExample : MonoBehaviour
{
    private float speed;
    public VariableJoystick variableJoystick;
    public Rigidbody2D rb;

    public Animator animator;

    public Transform MC;

    int mode = 0;
    float characterCorner = 0.0f;

    bool movingFlag = true;

    private CharacterBehaviour cb;

    public void ModeChanged(int index)
    {
        switch (index)
        {
            case 0:
                variableJoystick.SetMode(JoystickType.Fixed);
                break;
            case 1:
                variableJoystick.SetMode(JoystickType.Floating);
                break;
            default:
                break;
        }
    }

    public void ChangeMode()
    {
        if (mode == 0)
            mode = 1;
        else
            mode = 0;
        ModeChanged(mode);
    }
    private void Start()
    {
        ModeChanged(mode);
    }

    private void FixedUpdate()
    {
        if (movingFlag == true && animator.GetBool("DeathFlag") == false)
        {
            cb = GameObject.FindGameObjectWithTag("MC").GetComponent<CharacterBehaviour>();
            speed = cb.MCSpeed;

            this.transform.position = new Vector2(this.transform.position.x + variableJoystick.Horizontal / 1000 * speed,
            this.transform.position.y + variableJoystick.Vertical / 1000 * speed); /*Change MC postion folow the change of joystick*/
            float corner = 0.0f;
            float tan = 0.0f;
            if (variableJoystick.Horizontal == 0 && variableJoystick.Vertical == 0) /*Stop animation moving of MC when joystick stop change*/
            {
                animator.SetFloat("Speed", variableJoystick.Vertical);
                if (animator.GetBool("DeathFlag") == false)
                {
                    animator.Rebind();
                }

            }

            if (variableJoystick.Horizontal != 0 || variableJoystick.Vertical != 0)
            {
                if (Mathf.Abs(variableJoystick.Horizontal) > Mathf.Abs(variableJoystick.Vertical))
                    animator.SetFloat("Speed", Mathf.Abs(variableJoystick.Horizontal));
                else
                    animator.SetFloat("Speed", Mathf.Abs(variableJoystick.Vertical));
            }

            if (variableJoystick.Horizontal != 0 && variableJoystick.Vertical != 0)
            {
                tan = variableJoystick.Horizontal / variableJoystick.Vertical;


                corner = Mathf.Atan(tan) * 180 / Mathf.PI;


                if (variableJoystick.Vertical < 0)
                {
                    corner -= 180;
                }
                characterCorner = corner;
                MC.transform.rotation = Quaternion.Euler(Vector3.forward * -corner);
            }
        }


    }

    public float GetCharacterCorner()
    {
        return this.characterCorner;
    }

    public void StopMCMoving()
    {
        movingFlag = false;
        animator.Rebind();
    }

    public void SetMCMoving()
    {
        movingFlag = true;
    }
}
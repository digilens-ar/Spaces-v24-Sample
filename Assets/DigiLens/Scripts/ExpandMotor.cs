using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


public class ExpandMotor : MonoBehaviour
{
    public static ExpandMotor Instance { get; private set; }
    Animator motorAnim;
    float scrollInput;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        motorAnim = GetComponent<Animator>();
        motorAnim.speed = 0;
    }

    //if user input is recieved, scroll through animation
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GetScrollVal(true);
            ScrollClip();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GetScrollVal(false);
            ScrollClip();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            OpenAnimation(false);
        }

    }

    /// <summary>
    /// Traverses animation clip 
    /// </summary>
    void ScrollClip()
    {
        motorAnim.Play("MotorExpansion", 0, scrollInput);
    }

    /// <summary>
    /// Stores scrollwheel input
    /// </summary>
    void GetScrollVal(bool inc)
    {
        if (inc)
            scrollInput += (Time.deltaTime);
        else
            scrollInput -= (Time.deltaTime);

        scrollInput = Mathf.Clamp01(scrollInput);

    }

    public void OpenAnimation(bool open)
    {
        float currentTime = motorAnim.GetCurrentAnimatorStateInfo(0).normalizedTime;

        motorAnim.speed = 1;



        if (open)
        {
            motorAnim.SetFloat("Direction", 1);
            motorAnim.Play("MotorExpansion", 0, currentTime);
            scrollInput = 1;
        }
        else
        {
            motorAnim.SetFloat("Direction", -1);
            motorAnim.Play("MotorExpansion", 0, currentTime);
            scrollInput = 0;
        }

        StartCoroutine(ResetAnim(open));

    }


    IEnumerator ResetAnim(bool open)
    {
        if (open) //wait until opening animation is completed
        {
            Debug.Log("Resetting opening animation");
            yield return new WaitUntil(() => motorAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1);
        }
        else //wait until closing animation is completed
        {
            Debug.Log("Resetting closing animation");
            yield return new WaitUntil(() => motorAnim.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0);
        }

        motorAnim.SetFloat("Direction", 1);
        motorAnim.speed = 0;
        Debug.Log("Resetting animation");

    }


}

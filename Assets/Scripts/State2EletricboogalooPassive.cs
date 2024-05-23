using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State2EletricboogalooPassive : MonoBehaviour
{
    public Material black;
    private RandomColour randomColour;
    public Transform player;
    public enum States
    {
        Patrol,
        Run,
        Idle,
    }

    public States state = States.Patrol;

    private void Start()
    {
        randomColour = GetComponent<RandomColour>();
        NextState();
    }

    void NextState()
    {
        switch (state)
        {
            case States.Patrol:
                StartCoroutine(PatrolState());
                break;
            case States.Run:
                StartCoroutine(RunState());
                break;
            case States.Idle:
                StartCoroutine(IdleState());
                break;
        }
    }
    IEnumerator IdleState()
    {
        float startTime = Time.time;
        while (state == States.Idle)
        {
            //change to random colours
            randomColour.SlideColour();
            if (Time.time - startTime > 3f)
            {
                state = States.Patrol;
            }
            yield return null; 
        }
        NextState();
    }
    IEnumerator PatrolState()
    {
        Debug.Log("Entering Patrol State");
        while (state == States.Patrol)
        {
            Wobble();
            transform.rotation *= Quaternion.Euler(0f, 50f * Time.deltaTime, 0f);
            
            Vector3 directionToPlayer = player.position - transform.position;
            directionToPlayer.Normalize();
            directionToPlayer *= -1;

            float result = Vector3.Dot (transform.right, directionToPlayer);

            if (result > 0.95f)
            {
                state = States.Run;
            }

            yield return null;
        }
        Debug.Log("Exiting Patrol State...");
        NextState();
    }


    IEnumerator RunState()
    {
        Debug.Log("Entering Run State");
        float startTime = Time.time;
        while (state == States.Run)
        {
            randomColour.PickBlack();
            Wobble();
            float shimmy = Mathf.Sin(Time.time * 30f) * 0.9f + 0.3f;
            transform.position += transform.right * 1f * Time.deltaTime * 5f;
            if (Time.time - startTime > 3f)
            {
                state = States.Idle;
            }
            yield return null;
        }
        Debug.Log("Exiting Run State...");
        NextState();
    }

    private void Wobble()
    {
        float wave = Mathf.Sin(Time.time * 30f) * 0.1f + 1f;
        float wave2 = Mathf.Cos(Time.time * 30f) * 0.1f + 1f;
        transform.localScale = new Vector3(wave, wave2, wave);
    }
}

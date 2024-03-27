using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public enum States
    {
        Patrol,
        Attack,
        Run,
    }

    public States state = States.Patrol;

    public void Start()
    {
        NextState();
    }

    void NextState()
    {
        switch (state)
        {
            case States.Patrol:
                StartCoroutine (PatrolState());
                break;
            case States.Attack:
                StartCoroutine (AttackState());
                break;
            case States.Run:
                StartCoroutine (RunState());
                break;
        }
    }

    IEnumerator PatrolState()
    {
        Debug.Log("Entering Patrol State");

        //this works kind of like a update
        while (state == States.Patrol)
        {
            //Any code in here will run once per frame
            
            yield return null;//waits a single frame
        }
        Debug.Log("Exiting PAtrol State...");
        NextState();
    }

    IEnumerator AttackState()
    {
        Debug.Log("Entering Attack State");        
        while (state == States.Attack)
        {
            

            yield return null;
        }
        Debug.Log("Exiting Attack State...");
        NextState();
    }

    IEnumerator RunState()
    {
        Debug.Log("Entering Run State");        
        while (state == States.Run)
        {
            yield return null;
        }
        Debug.Log("Exiting Run State...");
        NextState();
    }
}

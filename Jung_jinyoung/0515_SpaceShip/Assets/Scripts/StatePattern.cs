using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePattern : MonoBehaviour {

    public enum BaseState
    {
        Idle, Dead, Skill
    }
    public BaseState BS;

    public bool IdleCheck = false;
    public bool DeadCheck = false;
    //Pause_test pt = new Pause_test();

    // Use this for initialization
    void Start () {
        
        BS = BaseState.Idle;
        IdleCheck = true;
        DeadCheck = false;
        Debug.Log(IdleCheck);
        Debug.Log(DeadCheck);
        StartCoroutine(BaseUpdate());
    }

    private IEnumerator BaseUpdate()
    {
        Debug.Log("BaseUpdate");
        //while (true)
        //{
        //    Debug.Log(BS.ToString());
        //    yield return StartCoroutine(BS.ToString());
        //}
        Debug.Log(BS.ToString());
        yield return StartCoroutine(BS.ToString());
    }
    IEnumerator Idle()
    {
        Debug.Log("In Idle");
        while (IdleCheck)
        {
            Debug.Log("IdleCheck");
            GameObject.Find("Player").GetComponent<PlayerController>().enabled = IdleCheck;
            if (DeadCheck)
            {
                Debug.Log("DeadCheck in Idle");
                IdleCheck = false;
                //GameObject.Find("Player").GetComponent<PlayerController>().enabled = IdleCheck;
                yield return new WaitForSeconds(1f);
            }
        }
        yield return new WaitForSeconds(1f);
        BS = BaseState.Dead;
        Debug.Log("out Idle");
    }
    IEnumerator Dead()
    {
        Debug.Log("Dead");
        while (DeadCheck)
        {
            Debug.Log("in");
            yield return new WaitForSeconds(1f);
            
            
            Debug.Log("pt.paused = true;");
            //GameObject.Find("Game Controller").SetActive(true);
        }
    }
    //IEnumerator Skill()
    //{
    //    Debug.Log("Skill");

    //}

    // Update is called once per frame
}

﻿using DG.Tweening.Plugins.Core.PathCore;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public class Burglar : MonoBehaviour
{
    // Start is called before the first frame update
    public int m_value;
    // public GameObject endPoint;
    NavMeshAgent navAgent;
    Animator anim;
    Transform startPoint, end_Point;
    [SerializeField]
    Points[] groupofPoints;
    [SerializeField]
    int pathNo = 0;
    bool inCoroutine = false,setCourse=false;
  
    void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();

        anim = GetComponent<Animator>();
        navAgent.updatePosition = true;
        navAgent.updateRotation = true;

    }
    private void Start()
    {

    }
    public void setPoints(Points[] points){
        groupofPoints = points;
        
        gameObject.transform.position = groupofPoints[pathNo].startPoint.transform.position;
    }
    // Update is called once per frame
    void Update()
    {if(navAgent.isActiveAndEnabled)
        if (inCoroutine==false) {
            if (navAgent.remainingDistance <= .1f /*|| navAgent.isStopped*/)
            {
                    inCoroutine = true;
                    StartCoroutine(SetPathCoroutine());
            }
        }
            
    }
    IEnumerator SetPathCoroutine() {
        navAgent.isStopped = true;
        anim.SetTrigger("Crouch");
        
        yield return new WaitForSeconds(1f);
        if (setCourse == true)
        setNewPath();
    }
    public int getValue()
    {
        return m_value;
    }
   public IEnumerator SetDestination(bool set_course=false)
    {
        if (!navAgent.isOnNavMesh) {
            print(gameObject.name);
        }

        if (navAgent.isActiveAndEnabled) {
            navAgent.destination = groupofPoints[pathNo].endPoints[0].transform.position;
            navAgent.isStopped = false;
        }
        
        // end_Point = endPoint;
        anim.SetTrigger("Run");
        if (set_course == true) {
            setCourse = true;
        }
        yield return new WaitForSeconds(2.5f);
        inCoroutine = false;
    }
    public void SetStartPosition(Transform startPosition)
    {
        startPoint = startPosition;

    }
   
    public void setNewPath()
    {
        pathNo++;
        if (pathNo > 3) {
            pathNo = 0;
        }
        navAgent.enabled = false;
        gameObject.transform.position = groupofPoints[pathNo].startPoint.transform.position;
        navAgent.enabled = true;
        StartCoroutine(SetDestination());
    }

    public void NoneAnimation()
    {
        navAgent.isStopped = true;
        anim.SetTrigger("Idle");
    }
    public void DieAnimation()
    {
        navAgent.isStopped = true;
        anim.SetTrigger("Die");
        ManagerHandler.managerHandler.audioManager.PlayAudio(AudioSourceType.ANIMEF, AudioCLips.AC_Die, false);
    }
    public void setSpeed(float speed) {
        navAgent.speed = speed;
        anim.speed = speed>1?1f:speed;
    }
    public void stopCoursing() {
        setCourse = false;
    }
}

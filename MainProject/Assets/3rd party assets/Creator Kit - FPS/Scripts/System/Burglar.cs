using DG.Tweening.Plugins.Core.PathCore;
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
    Points[] groupofPoints;
    int pathNo = 0;
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
    {
    }
    public int getValue()
    {
        return m_value;
    }
    public void SetDestination()
    {
        navAgent.destination = groupofPoints[pathNo].endPoints[0].transform.position;

        navAgent.isStopped = false;
        
       // end_Point = endPoint;
        anim.SetTrigger("Run");
        StartCoroutine(StopRunning());
    }
    public void SetStartPosition(Transform startPosition)
    {
        startPoint = startPosition;

    }
    IEnumerator StopRunning()
    {
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => navAgent.remainingDistance <= 2f || navAgent.isStopped);
        //  navAgent.destination = startPoint.position;
        navAgent.isStopped = true;
        anim.SetTrigger("Crouch");
        yield return new WaitForSeconds(2f);
        setNewPath();

    }
    public void setNewPath()
    {
        pathNo++;
        if (pathNo > 3) {
            pathNo = 0;
        }
        gameObject.transform.position = groupofPoints[pathNo].startPoint.transform.position;
        SetDestination();
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

    }
}

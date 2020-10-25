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
    Transform startPoint;
    void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
       
        anim = GetComponent<Animator>();
        navAgent.updatePosition = true;
        
    }
    private void Start()
    {
        navAgent.updateRotation = true;
    }
    // Update is called once per frame
    void Update()
    {
    }
    public int getValue() {
        return m_value;
    }
    public void SetDestination(Transform endPoint) {
        navAgent.isStopped = false;
        navAgent.destination = endPoint.position;
         anim.SetTrigger("Run");
        StartCoroutine(StopRunning());
    }
    public void SetStartPosition(Transform startPosition) {
        startPoint = startPosition;
    
    }
    IEnumerator StopRunning()
    {
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => navAgent.remainingDistance <= 0.1f|| navAgent.isStopped);
        navAgent.destination = startPoint.position;
        //  navAgent.isStopped = true;
        //  anim.SetTrigger("ShootPosition");
    }
    public void DieAnimation() {
        navAgent.isStopped = true;
        anim.SetTrigger("Die");
    }

    public void NoneAnimation() {
        navAgent.isStopped = true;
        anim.SetTrigger("Idle");
    }


}

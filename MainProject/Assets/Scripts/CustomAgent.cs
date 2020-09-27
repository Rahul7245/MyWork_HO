using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class CustomAgent : MonoBehaviour
{
    /// <summary>
    /// Spawn single prefab with multiple properties 
    /// </summary>
    private NavMeshAgent PlayerAgent;

    /// <summary>
    /// List of transforms for character to move
    /// </summary>
    public Transform[] GoalPoints;

    /// <summary>
    /// Temporary List for random movement
    /// </summary>
    List<int> NumberPool;

    /// <summary>
    /// Variable to store Previous Index value to stop repeating random number
    /// </summary>
    private int PrevIndex = 0;

    /// <summary>
    /// Variable to store Current random number 
    /// </summary>
    private int CurrRandomIndex = 0;

    /// <summary>
    /// Animator attached to this character
    /// </summary>  
    private Animator anim;

    /// <summary>
    /// bool value if it matches the given burgler name in Spawn enemies
    /// </summary>
    public bool isWalkable = false;

    /// <summary>
    /// Bool value if character reached to it's next destination point 
    /// </summary>
    private bool isReached = false;

    /// <summary>
    /// current index value
    /// </summary>
    public int indexvalue = 0;

    /// <summary>
    /// bool variable to check if character is dead
    /// </summary>
    private bool isDead = false;

    private void Awake()
    {
        PlayerAgent = this.GetComponent<NavMeshAgent>();
        PlayerAgent.updateRotation = false; // Making this false as to rotate it manually
        anim = this.GetComponent<Animator>();
    }

    void Start()
    {
        Check();
    }

    public void Check()
    {
        transform.LookAt(Camera.main.transform);
        if (isWalkable)
            AnimateCharacter();
    }

    private void Update()
    {
        if (!isWalkable)
            return;

        if (!PlayerAgent.pathPending && PlayerAgent.remainingDistance < 0.1f && !isReached)
        {
            GotoNextPoint();
        }
    }

    private void GotoNextPoint()
    {
        isReached = true;
        if (indexvalue < GoalPoints.Length)
        {
            PlayerAgent.updateRotation = false;
            anim.Play("Stand");
            AnimateCharacter();
        }
        else
        {
            transform.LookAt(Camera.main.transform);
            anim.Play("Shooting");
        }
    }

    private void RotateTowards(Transform target) // Method to turn the navmesh agent manually in place
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 90);
        PlayerAgent.updateRotation = true;
    }

    //Random number generation without repeating in loop 
    public void RestartRandom()
    {
        NumberPool = new List<int>();
        for (int i = 0; i < GoalPoints.Length; i++)
        {
            NumberPool.Add(i);
        }
    }
    public void AnimateCharacter()
    {
        isDead = false;
        indexvalue++;
        isReached = false;
        if (indexvalue < GoalPoints.Length && !isDead)
            StartCoroutine(ManageAnimations());
    }

    IEnumerator ManageAnimations()
    {
        PlayerAgent.speed = 1f;
        PlayerAgent.destination = GoalPoints[indexvalue].position;
        RotateTowards(GoalPoints[indexvalue]);
        anim.Play("Walk");

        yield return new WaitForSeconds(1f);
        PlayerAgent.speed = 0f;

        yield return new WaitForSeconds(2f);
        PlayerAgent.speed = 1.5f;
        Debug.Log("With speed of 1.5");
    }

    public void DieEffect()
    {
        isDead = true;
        anim.Play("Dying");
        PlayerAgent.isStopped = true;
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Transform visualTransform;

    private Transform hitTransform;
    private bool isEnemyShot;
    private float shootingForce;
    private Vector3 direction;
    private Vector3 hitPoint;
    CapsuleCollider collider;
    Collider boxCollider;
    private Vector3 startPoint;
    float totalDistance=0f;
    

    public void Launch(float shootingForce, Transform hitTransform, Vector3 hitPoint)
    {
        direction = (hitPoint - transform.position).normalized;
        isEnemyShot = false;
        this.hitTransform = hitTransform;
        this.shootingForce = shootingForce;
        this.hitPoint = hitPoint;
        if(hitTransform.gameObject.tag== "Burgler")
        this.collider = hitTransform.GetComponent<CapsuleCollider>();
        else
        boxCollider = hitTransform.GetComponent<Collider>();
    }
    public void setStartingPoint(Vector3 st_pt) {
        this.startPoint = st_pt;
        totalDistance = Vector3.Distance(this.hitPoint, this.startPoint);
    }
   float totalTrackTime=1f;
    float elapsedTime =0f;
    private void Update()
    {
        if (collider)
        {
            if (elapsedTime < totalTrackTime)
            {
                elapsedTime += Time.fixedDeltaTime;
                Move();
            }
            else
            {
                Move1();
            }
        }
        if (boxCollider) {
            Move1();

        }
        Rotate();
        CheckDistanceToEnemy();
        //checkDistanceToStartPoint();
    }

    private void Move()
    {
        Vector3 finalPos = new Vector3(collider.bounds.center.x, hitPoint.y, collider.bounds.center.z);
        Vector3 translate =(finalPos -gameObject.transform.position).normalized;
        ImpactManager.Instance.ChangePosition(finalPos);
        direction = translate;
        transform.Translate(translate * shootingForce * Time.deltaTime, Space.World);
    }
    private void Move1()
    {
        transform.Translate(direction * shootingForce * Time.deltaTime, Space.World);
    }

    private void CheckDistanceToEnemy()
    {
        float distance = Vector3.Distance(transform.position, hitPoint);
        if(distance <= 0.3 && !isEnemyShot)
        {
            EnemyController enemy = hitTransform.GetComponentInParent<EnemyController>();
            if (enemy)
            {
                ShootEnemy(hitTransform, enemy);
            }
        }
    }
    public bool checkDistanceToStartPoint(float minDistance) {
      float currDis=  Vector3.Distance(gameObject.transform.position, startPoint);
        print("currDis::" + currDis + "totalDis" + totalDistance);
        return ((totalDistance-minDistance) < currDis);
    }
    private void Rotate()
    {
        visualTransform.Rotate(Vector3.forward, 1200 * Time.deltaTime, Space.Self);
    }

    private void ShootEnemy(Transform hitTransform, EnemyController enemy)
    {
        isEnemyShot = true;
        Rigidbody shotRB = hitTransform.GetComponent<Rigidbody>();
        enemy.OnEnemyShot(transform.forward, shotRB);
    }

    public float GetBulletSpeed()
    {
        return shootingForce;
    }

	internal Transform GetHitEnemyTransform()
	{
        return hitTransform;
	}
}
﻿using System;
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
    }

    private void Move()
    {
        Vector3 translate =(new Vector3(collider.bounds.center.x, hitPoint.y, collider.bounds.center.z) -gameObject.transform.position).normalized;
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
        if(distance <= 0.1 && !isEnemyShot)
        {
            EnemyController enemy = hitTransform.GetComponentInParent<EnemyController>();
            if (enemy)
            {
                ShootEnemy(hitTransform, enemy);
            }
        }
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
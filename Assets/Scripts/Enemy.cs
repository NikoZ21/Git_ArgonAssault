using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] int points = 10;
    [SerializeField] int HitPoints = 3;
    [SerializeField] ParticleSystem explosionVFX;
    [SerializeField] Transform parent;
    ScoreBoard scoreBoard;

    private void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        AddRigidBody();
    }

    private void AddRigidBody()
    {
        var rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProccessHit();
        if (HitPoints <= 0)
        {
            KillEnemy();
        }
    }

    private void ProccessHit()
    {
        HitPoints--;
        scoreBoard.IncreaseScore(points);
    }

    private void KillEnemy()
    {
        Instantiate(explosionVFX, transform.position, Quaternion.identity, parent);
        Destroy(gameObject);
    }
}

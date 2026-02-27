using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public GameObject bullet;
    public Transform shootPoint;

    float shootCooldown = 0f;

    void Update()
    {
    }

    public override State RunCurrentState()
    {
        shootCooldown -= Time.deltaTime;
        if (shootCooldown <= 0f) {
            Shoot();
        }
        return this;
    }

    void Shoot()
    {
        Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        shootCooldown = 1f;
    }
}

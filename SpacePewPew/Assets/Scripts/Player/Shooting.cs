using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public GameObject Projectile;
    private float FireRate=0.5f;
    private bool IsFiring=false;
    private float LastFireTime = 0f;
    private PlayerMovement PlayerMovement;
    private Rigidbody ProjectileRB;
    private float ShootForce=10f;
    private Collider SpawnPoint;
    void Start()
    {
        PlayerMovement=GetComponentInParent<PlayerMovement>();
        SpawnPoint=GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
if (Input.GetKey(KeyCode.LeftControl))
    {
        if (!IsFiring)
        {
            IsFiring = true;
            LastFireTime = Time.time;
        }
        if (Time.time - LastFireTime >= FireRate)
        {
            SpawnProjectile();
            LastFireTime = Time.time;
        }
    }
        else
    {
        IsFiring = false;
    }

    }

    private void SpawnProjectile()
    {
        var spawnedProjectile = Instantiate(Projectile, SpawnPoint.transform.position + PlayerMovement.GetDirectionToMouse(), SpawnPoint.transform.rotation);
        ProjectileRB = spawnedProjectile.GetComponent<Rigidbody>();
        //ProjectileRB.AddForce(PlayerMovement.GetDirectionToMouse()*ShootForce*Time.deltaTime,ForceMode.Impulse);
        ProjectileRB.velocity = PlayerMovement.GetDirectionToMouse() * ShootForce;
        Destroy(spawnedProjectile, 2f);
    }
}

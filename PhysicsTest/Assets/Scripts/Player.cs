using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private AntiGhostBullet antiGhostBulletGO;

    [SerializeField]
    private AntiHumanBullet antiHumanBulletGO;

    [SerializeField]
    private float shootCooldown = 3F;

    private bool canShoot = true;

    private Ray ray;
    private RaycastHit raycastHit;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetAxis("Fire1") > 0)
        {
            if (canShoot)
            {
                print("Fiyah!");
                InstanceBullet(antiHumanBulletGO);
                canShoot = false;
                StartCoroutine(ResetBulletTimer());
            }
            //else
            //{
            //    print("Awaiting cooldown");
            //}
        }
        else if (Input.GetAxis("Fire2") > 0)
        {
            if (canShoot)
            {
                print("Fiyewr!");
                InstanceBullet(antiGhostBulletGO);
                canShoot = false;
                StartCoroutine(ResetBulletTimer());
            }
            //else
            //{
            //    print("Awaiting cooldown");
            //}
        }
    }

    private void InstanceBullet(Projectile targetProjectile)
    {
        if (targetProjectile != null)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out raycastHit))
            {
                Vector3 spawnLocation = raycastHit.point;
                Instantiate(targetProjectile.gameObject, spawnLocation + new Vector3(0F, 0.5F, 0F), Quaternion.identity);
            }
        }
    }

    private IEnumerator ResetBulletTimer()
    {
        yield return new WaitForSeconds(shootCooldown);
        canShoot = true;
    }
}
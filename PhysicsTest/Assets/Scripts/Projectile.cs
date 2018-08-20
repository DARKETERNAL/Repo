using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float maxDamage = 1;

    [SerializeField]
    private float launchSpeed = 10F;

    [SerializeField]
    private ForceMode forceMode;

    [SerializeField]
    private float destroyTime = 5F;

    private Collider myCollider;
    private Rigidbody myRigidbody;

    // Use this for initialization
    private void Start()
    {
        myCollider = GetComponent<Collider>();
        myRigidbody = GetComponent<Rigidbody>();

        Launch();
        Invoke("AutoDestroy", destroyTime);
    }

    protected virtual void Launch()
    {
        myRigidbody.AddForce(transform.forward * launchSpeed, forceMode);
    }

    protected virtual void AutoDestroy()
    {
        Destroy(gameObject);
    }

    protected void CancelAutoDestroy()
    {
        CancelInvoke("AutoDestroy");
    }
}
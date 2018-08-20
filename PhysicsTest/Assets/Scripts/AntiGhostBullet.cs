public class AntiGhostBullet : Projectile
{
    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        print("Collided with something");

        Ghost ghost = other.gameObject.GetComponent<Ghost>();

        if (ghost != null)
        {
            print("collided with ghost");
            ghost.OnDamageTakenDelegate();
        }

        CancelAutoDestroy();
        Destroy(gameObject);
    }
}
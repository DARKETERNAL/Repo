public class AntiHumanBullet : Projectile
{
    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        Soldier soldier = other.gameObject.GetComponent<Soldier>();

        if (soldier)
        {
            soldier.OnDamageTakenDelegate();
        }

        Destroy(gameObject);
    }
}
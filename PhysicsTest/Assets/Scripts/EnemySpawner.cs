using UnityEngine;

public static class SpawnerExtensions
{
    public static Vector3 GetPointInVolume(this Collider collider)
    {
        Vector3 result = Vector3.zero;
        result = new Vector3(Random.Range(-1f, 1f), 0.5F, Random.Range(-1f, 1f));
        result = collider.transform.TransformPoint(result * .5f);

        return result;
    }
}

[RequireComponent(typeof(Collider))]
public class EnemySpawner : MonoBehaviour
{
    private const float MIN_WAVE_TIME = 3F;

    [SerializeField]
    private Enemy[] enemies;

    [SerializeField]
    private float waveTime = 3F;

    private Collider myCollider;

    // Use this for initialization
    private void Start()
    {
        if (enemies.Length > 0 && AllEnemiesValid())
        {
            myCollider = GetComponent<Collider>();
            InvokeRepeating("SpawnEnemy", 0.2F, Mathf.Max(MIN_WAVE_TIME, waveTime));
            //SpawnEnemy();
        }
    }

    private bool AllEnemiesValid()
    {
        bool result = true;

        for (int i = 0; i < enemies.Length; i++)
        {
            result = result && enemies[i] != null;

            if (!result)
            {
                break;
            }
        }

        return result;
    }

    private void SpawnEnemy()
    {
        Instantiate(enemies[Random.Range(0, enemies.Length)], myCollider.GetPointInVolume(), transform.rotation);
    }
}
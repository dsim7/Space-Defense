using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class Wave : ScriptableObject
{
    public float initialDelayTime;
    public float spawnTimeInterval;
    public bool spawnPositionRandom;

    public List<GameObject> enemies;

    public IEnumerator Spawn(SpawnZone spawnZone, Transform enemiesTransform, UnityAction then)
    {
        yield return new WaitForSeconds(initialDelayTime);
        foreach (GameObject enemy in enemies)
        {
            if (enemy != null)
            {
                GameObject newEnemy = Instantiate(enemy, GetSpawnPosition(spawnZone.transform, enemy), Quaternion.identity);
                newEnemy.transform.SetParent(enemiesTransform);
                newEnemy.GetComponent<EnemyLife>().spawner = spawnZone;
            }
            yield return new WaitForSeconds(spawnTimeInterval);
        }
        then.Invoke();
    }

    Vector2 GetSpawnPosition(Transform spawnPoint, GameObject spawnedObj)
    {
        if (!spawnPositionRandom)
        {
            return spawnPoint.position;
        }
        else
        {
            Collider2D objCollider = spawnedObj.GetComponent<Collider2D>();
            float halfObjectHeight = objCollider.bounds.size.y;
            Vector2 center = spawnPoint.position;
            Collider2D col = spawnPoint.GetComponent<Collider2D>();
            Vector2 bounds = col.bounds.size;

            float xPos = center.x + (bounds.x * Random.Range(-0.5f, 0.5f));
            float yPos = center.y + ((bounds.y - halfObjectHeight) * Random.Range(-0.5f, 0.5f));
            return new Vector2(xPos, yPos);
        }
    }
}

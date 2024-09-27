using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class RockCreator : MonoBehaviour
{
    public GameObject rockPrefab;
    public float spawnInterval = 2f;
    public float returnDelay = 5f;
    private ObjectPool<GameObject> rockPool; // 內建的 Object Pool

    private void Start()
    {

        rockPool = new ObjectPool<GameObject>(
            createFunc: () => Instantiate(rockPrefab),
            actionOnGet: obj => obj.SetActive(true),
            actionOnRelease: obj => obj.SetActive(false),
            actionOnDestroy: obj => Destroy(obj),
            defaultCapacity: 4,
            maxSize: 8
        );

        StartCoroutine(SpawnRocks());
    }

    private IEnumerator SpawnRocks()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            GameObject rock = rockPool.Get();
            rock.transform.position = transform.position;
            rock.transform.rotation = Random.rotation;
            StartCoroutine(ReturnRockToPool(rock, returnDelay));
        }
    }


    private IEnumerator ReturnRockToPool(GameObject rock, float delay)
    {
        yield return new WaitForSeconds(delay);
        rockPool.Release(rock);
    }
}

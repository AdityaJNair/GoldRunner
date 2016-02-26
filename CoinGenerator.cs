using UnityEngine;
using System.Collections;

public class CoinGenerator : MonoBehaviour {

    public ObjectPool coinPool;
    public float coinSpread;

    public void coinSpawner(Vector3 position)
    {
        GameObject coin_1 = coinPool.GetPooledObject();
        coin_1.transform.position = position;
        coin_1.SetActive(true);

        GameObject coin_2 = coinPool.GetPooledObject();
        coin_2.transform.position = new Vector3(position.x - coinSpread, position.y,position.z);
        coin_2.SetActive(true);

        GameObject coin_3 = coinPool.GetPooledObject();
        coin_3.transform.position = new Vector3(position.x + coinSpread, position.y, position.z); ;
        coin_3.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingManager : MonoBehaviour{

    public static ObjectPoolingManager m_oInstance;

    public List<Pool> m_lstPools;
    public Dictionary<string, Queue<GameObject>> m_dictPool;

    private void Awake() {
        m_oInstance = this;
    }

    private void Start() {
        m_dictPool = new Dictionary<string, Queue<GameObject>>();

        foreach(Pool pool in m_lstPools) {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++) {
                GameObject obj = Instantiate(pool.prefab,gameObject.transform);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            m_dictPool.Add(pool.tag,objectPool);
        }
    }

    public GameObject oSpawnFromPool(string tag, Vector3 position, Quaternion rotation) {
        if (!m_dictPool.ContainsKey(tag)) {
            Debug.Log("Pool tag(" + tag +") doesn't exist in Pool Dictionary");
            return null;
        }

        GameObject objToSpawn = m_dictPool[tag].Dequeue();
        objToSpawn.SetActive(true);
        objToSpawn.transform.position = position;
        objToSpawn.transform.rotation = rotation;
        m_dictPool[tag].Enqueue(objToSpawn);
        return objToSpawn;
    }

}

[System.Serializable]
public class Pool {

    public string tag;
    public GameObject prefab;
    public int size;

}

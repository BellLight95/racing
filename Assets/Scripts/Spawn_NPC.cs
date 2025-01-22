using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject spawnArea;
    public GameObject car;
    private BoxCollider spawnCollider;
    
    Vector3 spawnPos()
    {
        Vector3 pos = spawnArea.transform.position;
        float range_x = spawnCollider.bounds.size.x;
        float range_z = spawnCollider.bounds.size.z;
        
        range_x = Random.Range(-range_x/2, range_x/2);
        range_z = Random.Range(-range_z/2, range_z/2);
        Vector3 Pos = new Vector3(range_x, pos.y+0.5f, range_z);
        Vector3 SpawnPos = pos + Pos;
        return SpawnPos;
    }
    // Start is called before the first frame update
    void Start()
    {
        spawnCollider = spawnArea.GetComponent<BoxCollider>();
        StartCoroutine(RandomSpawn());
    }

    IEnumerator RandomSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            GameObject Car = Instantiate(car, spawnPos(), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

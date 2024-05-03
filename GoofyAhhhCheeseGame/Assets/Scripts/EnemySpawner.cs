using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    // In seconds
    [SerializeField]private float interval = 2f;
    private float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= interval){
            timer = 0f;
            Instantiate(enemyPrefab, transform.position,transform.rotation);
        }
    }
}

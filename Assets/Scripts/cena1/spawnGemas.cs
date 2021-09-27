using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnGemas : MonoBehaviour {
    public GameObject gema;
    [HideInInspector] public int qtdGemas = 0;
    public GameObject[] spawnPoints = new GameObject[6];

    private void Update() {
        if (qtdGemas < 3) {

            Instantiate(gema, spawnPoints[Random.Range(0, 6)].transform.position, transform.rotation);
            qtdGemas++;

        }
    }
}

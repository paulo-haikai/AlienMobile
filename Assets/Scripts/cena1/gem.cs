using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gem : MonoBehaviour
{

    private GameObject spawner;
    private GameObject player;

    private void Start() {

        player = GameObject.Find("player");
        spawner = GameObject.Find("SpawnManager");
        StartCoroutine(DestroyGems());
    }
        private void OnTriggerEnter(Collider other) {
            if (other.gameObject.CompareTag("Player")) {
            player.GetComponent<PlayerMoviment>().pontos += 10;
            spawner.GetComponent<spawnGemas>().qtdGemas--;
            Destroy(gameObject);

            }
    }

    private IEnumerator DestroyGems() {

        yield return new WaitForSeconds(Random.Range(3, 8));
        spawner.GetComponent<spawnGemas>().qtdGemas--;
        Destroy(gameObject);


    }

}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class espinhos : armadilha {
    private PlayerController3D player;
    public bool noEspinho;
    public bool podeDano = true;


    public espinhos() {
        dano = 20;
        cooldown = 2;

    }
    private void update() {

        if (noEspinho && podeDano)

            podeDano = false;
        StartCoroutine("dealDamage");
    }


    private void OnTriggerEnter(Collider other) 
        {
        if (other.gameObject.CompareTag("Player")) {

            player = other.gameObject.GetComponent<PlayerController3D>();
        }
    }
    public override IEnumerator dealDamage() {

        player.Dano(dano);
        yield return new WaitForSeconds(cooldown);
        podeDano = true;

    }
}



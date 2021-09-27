using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lava : armadilha { 
 
    private PlayerController3D player;
    public bool naLava;
    public bool podeDano = true;


public lava() {
    dano = 20;
    cooldown = 2;

}
private void update() {

    if (naLava && podeDano)

        podeDano = false;
    StartCoroutine("dealDamage");
}


private void OnTriggerEnter(Collider other) {
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class armadilha : MonoBehaviour
{
    public int dano;
    public float cooldown;

    public abstract IEnumerator dealDamage();
}

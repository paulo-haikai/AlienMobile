﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class voltarButton : MonoBehaviour
{
   public void loadScene (string nome) {
        SceneManager.LoadScene(nome);

    }
}

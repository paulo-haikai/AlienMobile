using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonMenu : MonoBehaviour
{
    public void loadScene (string menu) {
        SceneManager.LoadScene(menu);
    }

}

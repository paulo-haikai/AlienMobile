using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMoviment : MonoBehaviour {
    private Touch touch;
    private Vector2 posTouch;
    private Vector3 posPlayer;
    private bool touchingPlayer;
    [HideInInspector] public int pontos;

    public Text colete;
    public Text points;

    private void Start() {
        colete.text = "";
    }
    private void Update() {

        points.text = "Pontuação " + pontos;

        if (Input.touchCount > 0) {

            touch = Input.GetTouch(0);
        }

        if (touch.phase == TouchPhase.Began) {
            posTouch = Camera.main.ScreenToWorldPoint(touch.position);
            posPlayer = transform.position;

            if (posTouch.x > posPlayer.x - 1f && posTouch.x < posPlayer.x + 1f && posTouch.y > posPlayer.y - 1.5f && posTouch.y < posPlayer.y + 1.5f) ;
            {
                touchingPlayer = true;
                colete.text = "Colete as gemas!";
            }

            if (touch.phase == TouchPhase.Ended) {
                touchingPlayer = false;
                colete.text = " ";

            }
            if (touchingPlayer) {
                posTouch = Camera.main.ScreenToWorldPoint(touch.position);
                transform.position = posTouch;

            }
        }
    }

}

    
       




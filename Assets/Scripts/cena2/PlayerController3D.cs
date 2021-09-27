using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController3D : MonoBehaviour {

	//Movimentação
	public float moveSpeed;
	public float rotationSpeed;

	//Componente
	CharacterController cc;

	//Animator
	private Animator anim;

	//Joystick
	public Joystick joystick;

	//Pulo
	protected Vector3 gravidade = Vector3.zero;
	protected Vector3 move = Vector3.zero;
	private bool jump = false;

	//HUD e UI
	public Button botao;
	public Slider hb;

	//Vidas
	private int playerLife = 100;
	public int actualLife;
	static public int hearts = 3;
	public GameObject[] coracao = new GameObject[3];

	void Start() {
		
		cc = GetComponent<CharacterController>();
		anim = GetComponent<Animator>();
		anim.SetTrigger("Parado");
		botao.onClick.AddListener(Pulo);

		//Variáveis que controlam o HUD e a vida
		actualLife = playerLife;
		hb.value = actualLife;
	}

	void Update(){
		Vector3 move = joystick.Vertical * transform.TransformDirection(Vector3.forward) * moveSpeed;
		transform.Rotate(new Vector3(0, joystick.Horizontal * rotationSpeed * Time.deltaTime, 0));

		if (!cc.isGrounded)	{
			gravidade += Physics.gravity * Time.deltaTime;
		}

		else{
			gravidade = Vector3.zero;
			if (jump){
				gravidade.y = 6f;
				jump = false;
			}
		}

		move += gravidade;
		cc.Move(move * Time.deltaTime);

		Anima();

		for (int i = 0; i < hearts; i++) {
			coracao[i].SetActive(true);
        }

		if (actualLife == 0) {
			SceneManager.LoadScene("Teste02_MovBasica");
			hearts--;
		}

		if (hearts == 0) {
			SceneManager.LoadScene("Terminou");
        }
	}
	private void Pulo() {
		anim.SetTrigger("Pula");
		jump = true;
	}

	public void Dano(int damage) {
	#if UNITY_ANDROID
		Handheld.Vibrate();
	#endif
		actualLife -= damage;
		hb.value = actualLife;
	}

	void Anima() { 
		if (joystick.Horizontal == 0 && joystick.Vertical == 0)	{
			anim.SetTrigger("Parado");
		}
		else{
			if (jump){
				anim.SetTrigger("Pula");
			}else{
				anim.SetTrigger("Corre");
			}
		}
	}

    private void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Finish")){
			SceneManager.LoadScene("Terminou");
        }
    }
}

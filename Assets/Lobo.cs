using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lobo : MonoBehaviour {

    //Ação que esta realizando
    public int acao = 0;
    //Tempo para voltar a estado anterior
    private int tempo;
    //tempo maximo
    public int tempo_max = 100;
    public int vida = 10;


    private Animator LoboAnim;
    public GameObject destino;
    public bool indo = true;
    public Vector3 Origem;
    public GameObject Heroi;
	// Use this for initialization
	void Start () {
        LoboAnim = GetComponent<Animator>();
        Heroi = GameObject.FindGameObjectWithTag("Player");
        Origem = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        tempo++;
        if (Heroi.GetComponent<Samurai>().vivo == true)
        {
            Distancia_Proximo();
        }

        switch (acao)
        {
            case 0:
                //fazendo nada
                if(tempo > 10)
                {
                    acao = 1;
                    LoboAnim.SetBool("walk", true);
                    LoboAnim.SetBool("idle01", false);
                    tempo = 0;
                }
                break;
            case 1:
                //andando
                if (indo == true)
                {
                    transform.LookAt(destino.transform.position);
                    transform.position = Vector3.MoveTowards(transform.position, destino.transform.position, 0.1f);
                    if(Vector3.Distance(transform.position, destino.transform.position) < 5)
                    {
                        indo = false;
                    }
                }else
                {
                    transform.LookAt(Origem);
                    transform.position = Vector3.MoveTowards(transform.position, Origem, 0.1f);
                    if (Vector3.Distance(transform.position, Origem) < 5)
                    {
                        indo = true;
                    }
                }
                if (tempo > 1000)
                {
                    acao = 0;
                    LoboAnim.SetBool("walk", false);
                    LoboAnim.SetBool("idle01", true);
                    tempo = 0;
                }
                break;
            case 2:
                transform.LookAt(Heroi.transform.position);
                transform.position = Vector3.MoveTowards(transform.position, Heroi.transform.position, 0.2f);
                break;
            case 3:
                if (Heroi.GetComponent<Samurai>().vivo == false)
                {
                    acao = 1;
                    LoboAnim.SetBool("walk", true);
                    LoboAnim.SetBool("idle01", false);
                    LoboAnim.SetBool("run", false);
                    LoboAnim.SetBool("attack01", false);
                    tempo = 0;
                }
                break;

        }
	}

   void Distancia_Proximo()
    {

        if (Vector3.Distance(transform.position, Heroi.transform.position) < 5)
        {
            if (acao == 2)
            {
                acao = 3;
                LoboAnim.SetBool("walk", false);
                LoboAnim.SetBool("idle01", false);
                LoboAnim.SetBool("run", false);
                LoboAnim.SetBool("attack01", true);
            }
        }
        else if (Vector3.Distance(transform.position, Heroi.transform.position) < 15)
        {
            if (acao == 1 || acao == 3)
            {
                acao = 2;
                LoboAnim.SetBool("walk", false);
                LoboAnim.SetBool("idle01", false);
                LoboAnim.SetBool("run", true);
                LoboAnim.SetBool("attack01", false);
            }
        }
        else
        {
            if (acao == 2 || acao == 3)
            {
                acao = 1;
                LoboAnim.SetBool("walk", true);
                LoboAnim.SetBool("idle01", false);
                LoboAnim.SetBool("run", false);
                LoboAnim.SetBool("attack01", false);
                tempo = 0;
            }
        }
    }

void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Espada")
        {
            vida--;
            Debug.Log("LOBO VIDA:" + vida);
            if(vida <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}

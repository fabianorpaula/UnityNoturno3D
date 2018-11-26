using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lobo : MonoBehaviour {


    public int acao = 0;
    public int tempo;
    private Animator LoboAnim;
    public GameObject destino;
    public GameObject Heroi;
	// Use this for initialization
	void Start () {
        LoboAnim = GetComponent<Animator>();
        Heroi = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        tempo++;
        Distancia_Proximo();
        switch (acao)
        {
            case 0:
                //fazendo nada
                if(tempo > 100)
                {
                    acao = 1;
                    LoboAnim.SetBool("walk", true);
                    LoboAnim.SetBool("idle", false);
                    tempo = 0;
                }
                break;
            case 1:
                //andando
                transform.LookAt(destino.transform.position);
                transform.position = Vector3.MoveTowards(transform.position, destino.transform.position, 0.1f);
                if (tempo > 100)
                {
                    acao = 0;
                    LoboAnim.SetBool("walk", false);
                    LoboAnim.SetBool("idle", true);
                    tempo = 0;
                }
                break;
            case 2:
                transform.LookAt(destino.transform.position);
                transform.position = Vector3.MoveTowards(transform.position, Heroi.transform.position, 0.2f);
                break;

        }
	}

   void Distancia_Proximo()
    {

        if (Vector3.Distance(transform.position, Heroi.transform.position) < 2)
        { 
            if(acao == 2)
            {
                acao = 3;
            }
            

        }else if (Vector3.Distance(transform.position, Heroi.transform.position) < 15)
        {
            if (acao == 1)
            {
                acao = 2;
                LoboAnim.SetBool("walk", true);
                LoboAnim.SetBool("idle", false);
                LoboAnim.SetBool("run", true);
            }
        }
        else
        {
            if (acao == 2)
            {
                acao = 1;
                LoboAnim.SetBool("walk", true);
                LoboAnim.SetBool("idle", false);
                LoboAnim.SetBool("run", false);
                tempo = 0;
            }
        }
    }


}

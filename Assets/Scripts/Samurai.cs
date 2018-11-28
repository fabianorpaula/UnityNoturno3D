using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Samurai : MonoBehaviour {


    //Variavel De Fisica
    private Rigidbody Corpo;
    private Animator Animar;
    public GameObject Ataque;

    public int Vida = 10;
    public bool vivo = true;
    
    //private SpriteRenderer Spritemario;
    private float velocidade=0;
	private float moveHorizontal;
	private float moveVertical;
    public float acel = -1;
    public float forcapulo=0;
    private bool nochao = false;

    //public GameObject Casco;
    //public GameObject Foguinho;
	
	void Start () {
        //Recebe o componete de Fisica
        Corpo = GetComponent<Rigidbody>();
        Animar = GetComponent<Animator>();
        //Spritemario = GetComponent<SpriteRenderer>();
    
	}
	
	
	void Update () {
        //Chama a função de andar
        if (vivo == true)
        {
            Andar();
        }
        
        //Chao();
        Foguear();
        

    }
    void Pular()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Animar.SetInteger("Mover", 8);
            if (nochao == false)
            {
                
                forcapulo = 13;
                nochao = true;
               
               // Animar.SetBool("Pulo", true);
               
            }
        }
        if(nochao == true )
        {
            if (forcapulo < 0)
            {
                forcapulo = forcapulo + (acel / 2);
                
                
            }
            else
            {
                forcapulo = forcapulo + acel;

            }
        }
    }
    //Função de Andar
    void Andar()
    {
        if (Input.GetKey(KeyCode.X))
        {
            Animar.SetInteger("Mover", 5);
            //Instantiate(Ataque, PontoFocal, Quaternion.identity);
        }
        else
        {
            
			
			
			
			
			float moveVertical = Input.GetAxis("Horizontal");
            velocidade = Input.GetAxis("Vertical");
            Corpo.velocity = new Vector3(moveVertical*4, forcapulo, velocidade * 4);
           float heading = Mathf.Atan2(moveVertical, velocidade) * Mathf.Rad2Deg;
		    


            if (velocidade != 0 || moveVertical !=0)
            {
                Animar.SetInteger("Mover", 1);
                Corpo.rotation = Quaternion.Euler(0, heading, 0);

                
            }
            else
            {
                Animar.SetInteger("Mover", 0);
				
				
            }
            Pular();
        }

        
        

    }

    
    void Foguear()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Animar.SetInteger("Mover", 5);
        }
    }
    

    


    void OnTriggerEnter(Collider col)
    {

        if (vivo == true)
        {
            if (col.gameObject.tag == "danoLobo")
            {
                Vida--;
                if (Vida <= 0)
                {
                    vivo = false;
                    Animar.SetInteger("Mover", 20);
                }
            }
        }

    }

        void OnCollisionEnter(Collision col)
    {

       
        if (col.gameObject.tag == "Chao")
        {
            if (nochao == true)
            {
                nochao = false;
                forcapulo = 0;
            }
        }

        if (col.gameObject.tag == "Inimigo")
        {
            //GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControl>().GameOver();
            

        }
        if (col.gameObject.tag == "Moeda")
        {

            Destroy(col.gameObject);
           // Debug.Log("MOEDASSS");
           // GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControl>().Pontuar(1);

        }
       

    }
}

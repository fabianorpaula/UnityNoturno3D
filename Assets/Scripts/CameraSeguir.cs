using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSeguir : MonoBehaviour {
    public GameObject Personagem;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = new Vector3(Personagem.transform.position.x, 5, Personagem.transform.position.z-5);
        
	}
}

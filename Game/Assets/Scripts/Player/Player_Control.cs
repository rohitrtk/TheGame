using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour {

    private AbstractPlayer_Movement _playerMovementScript;
    private AbstractPlayer_Attack _playerAttackScript;

	// Use this for initialization
	void Start ()
    {
        _playerMovementScript = GetComponent<AbstractPlayer_Movement>();
        _playerAttackScript = GetComponent<AbstractPlayer_Attack>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}

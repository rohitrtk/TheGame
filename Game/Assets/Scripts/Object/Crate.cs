using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : ObjectParent
{
	// Use this for initialization
	public void Start ()
    {
        Health = 20;
    }

    public override void Update()
    {
        base.Update();
    }
}
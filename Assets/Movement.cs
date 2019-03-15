using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
		
			this.transform.position = new Vector2(this.transform.position.x+ (float).1,this.transform.position.y);
		}
		else if(Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.LeftArrow))
		{
			this.transform.position = new Vector2(this.transform.position.x- (float).1,this.transform.position.y);
		}
		else if(Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.UpArrow))
		{
			this.transform.position = new Vector2(this.transform.position.x,this.transform.position.y+(float).1);
		}
		
	}
}

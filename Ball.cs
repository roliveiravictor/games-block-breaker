/**********************************************************************/
/*                                                                    */
/*                         Block Breaker   							  */
/*																	  */
/*		This is the code from a game created to practice my           */
/*      Unity and Game Development skills. Most of this was           */
/*      made watching Ben Tristem's tutorial at Udemy.                */
/*                                                                    */
/*      For more information please visit:                            */
/*      https://www.udemy.com/unitycourse/                            */
/*                                                                    */
/*                                                                    */
/**********************************************************************/

using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
 {
	private Paddle paddle;
	private Vector3 paddleToBall;
	private bool hasStarted = false;
	private PlayMode playMode;

	void Start () 
	{
		paddle = GameObject.FindObjectOfType<Paddle>();
		playMode = GameObject.FindObjectOfType<PlayMode>();
		paddleToBall = this.transform.position - paddle.transform.position;
	}
	
	void Update () 
	{
		//Lock ball relative to the paddle
		if(!hasStarted)
			this.transform.position = paddle.transform.position + paddleToBall;
		
		//Launch ball
		if(Input.GetMouseButton(0) && !hasStarted)
			InitializeGame();
		else if (playMode.isAuto && !hasStarted)
			InitializeGame();
	}
	
	void OnCollisionEnter2D(Collision2D collision) 
	{
		Vector2 tweak = new Vector2 (Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
	
		if(hasStarted)
		{
			audio.Play();	
			rigidbody2D.velocity += tweak;
		}
	}
	
	void InitializeGame()
	{
		hasStarted = true;
		this.rigidbody2D.velocity = new Vector2 (2f, 10f);
	}
}

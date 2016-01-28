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

public class Paddle : MonoBehaviour 
{	
	public float minX, maxX;
		
	private Ball ball;
	private PlayMode playMode;
	
	void Start () 
	{
		ball = GameObject.FindObjectOfType<Ball>();
		playMode = GameObject.FindObjectOfType<PlayMode>();
	}
	
	void Update () 
	{
		//Demo mode or single player
		if(!playMode.isAuto)
			MoveWithMosue();
		else
			AutoPlay();
	}
	
	void AutoPlay() 
	{
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		Vector3 ballPos = ball.transform.position;
		
		//Movement range to fit on the screen
		paddlePos.x = Mathf.Clamp(ballPos.x, minX, maxX);
		this.transform.position = paddlePos;
	}
	
	void MoveWithMosue()
	 {
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, minX, maxX);
		this.transform.position = paddlePos;
	}
}

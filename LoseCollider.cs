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

public class LoseCollider : MonoBehaviour 
{	
	private LevelManager levelManager;
	
	//If the ball hits the floor, the player is defeated
	void OnTriggerEnter2D(Collider2D collider)
	{
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		levelManager.LoadLevel("Lose");
	}
}

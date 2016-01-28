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

public class Brick : MonoBehaviour 
{
	public static int breakableCount = 0;
	public AudioClip crack;
	public Sprite[] hitSprites;
	public GameObject smoke;
	
	private int timesHit;
	private bool isBreakable;
	private LevelManager levelManager;
	
	void Start () 
	{
		//Keep track of breakable bricks
		isBreakable = (this.tag == "Breakable");
		
		//Each brick object calls Brick.cs which has a static count variable to increment the number of bricks in the scene
		if(isBreakable)
			breakableCount++;		
				
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{		
		if(isBreakable)
		{
			AudioSource.PlayClipAtPoint(crack, transform.position, 0.5f);
			HandleHits();
		}
	}
	
	//Check whether it's to destroy brick or not - Game Main Mech
	void HandleHits() 
	{
		int maxHits = hitSprites.Length +1;
		timesHit++;
		
		if(timesHit >= maxHits)
		{
			breakableCount--;
			levelManager.BricksDestroyed();
			PuffSmoke();
			Destroy(gameObject);
		}
		else
		{
			LoadSprites();
		}
	}
	
	//Smoke effect after brick is destroyed
	void PuffSmoke()
	{
		GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
		smokePuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
		Destroy(smokePuff, smokePuff.particleSystem.duration);
	}
	
	void LoadSprites()
	{
		int spriteIndex = timesHit - 1;
		
		if(hitSprites[spriteIndex] != null)
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		else
			Debug.Log("Brick sprite is missing!");
	}
}

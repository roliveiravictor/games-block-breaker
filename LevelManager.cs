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

public class LevelManager : MonoBehaviour 
{	
	private PlayMode playMode;
	
	void Start() 
	{
		playMode = GameObject.FindObjectOfType<PlayMode>();
	}
	
	//Load level by its name
	public void LoadLevel(string level)
	{
		Brick.breakableCount = 0;
		Application.LoadLevel(level);
	}
	
	//Load level by index sequence - Build related
	public void LoadNextLevel()
	{
		Brick.breakableCount = 0;
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	//Load level for demo mode
	public void LoadAutoPlay()
	{
		Brick.breakableCount = 0;
		playMode.isAuto = true;
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	public void QuitGame()
	{
		Application.Quit();
	}
	
	//Check if all bricks are destroyed to advance level
	public void BricksDestroyed() 
	{
		if(Brick.breakableCount <= 0)
			LoadNextLevel();
	}
}

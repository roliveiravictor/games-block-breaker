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

public class MusicManager : MonoBehaviour
{
	static MusicManager music = null;
	
	//Needs to run Destroy() on Awake() instead of Start() to make sure the object will be destroyed before the new scene is created
	void Awake()
	{
		if(music != null)
		{
			Destroy(gameObject);
		}
		else
		{
			music = this;
			GameObject.DontDestroyOnLoad(music);
		}
	}
}

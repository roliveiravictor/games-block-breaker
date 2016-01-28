using UnityEngine;
using System.Collections;

public class PlayMode : MonoBehaviour 
{
	public bool isAuto;

	void Start ()
	{
		GameObject.DontDestroyOnLoad(this);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleSceneSwitcher : MonoBehaviour
{
	public void LoadMenu()
	{
		SceneManager.LoadScene(0);
	}
}

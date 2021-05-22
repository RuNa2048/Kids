using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapMenu : MonoBehaviour
{
	[SerializeField] private UITransitionScreen _transScreen;

	public void LoadLevel(int number)
	{
		_transScreen.LightenScreen();

		StartCoroutine(ChangeScreen(number));
	}

	private IEnumerator ChangeScreen(int number)
	{
		while (_transScreen.IsChange)
			yield return null;

		SceneManager.LoadScene(number);
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}

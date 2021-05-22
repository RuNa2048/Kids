using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenuButton : MonoBehaviour
{
	[SerializeField] private UITransitionScreen _screen;

	public void OnLoadMainMenu()
	{
		_screen.LightenScreen();

		StopAllCoroutines();
		SceneManager.LoadScene(0);
	}
}

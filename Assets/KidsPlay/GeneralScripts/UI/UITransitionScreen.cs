using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITransitionScreen : MonoBehaviour
{
	[SerializeField] private float _rateOfChange;

	[HideInInspector] public bool IsChange = false;

	private const float MaxAlphaChanel = 1;
	private const float MinAlphaChanel = 0;

	Image _image;

	private void Awake()
	{
		_image = GetComponent<Image>();

		Color color = _image.color;
		color.a = MaxAlphaChanel;
		_image.color = color;

		DarkenScreen();
	}

	public void LightenScreen()
	{
		gameObject.SetActive(true);

		StartCoroutine(ToggleScreen(MaxAlphaChanel));
	}

	public void DarkenScreen()
	{
		StartCoroutine(ToggleScreen(MinAlphaChanel));
	}

	private IEnumerator ToggleScreen(float needAlphaChannel)
	{
		yield return StartCoroutine(ScreenChange(needAlphaChannel));
	}

	private IEnumerator ScreenChange(float needAlphaChannel)
	{
		gameObject.SetActive(true);
		IsChange = true;

		float alphaChanel = _image.color.a;

		while (alphaChanel != needAlphaChannel)
		{
			alphaChanel = Mathf.MoveTowards(alphaChanel, needAlphaChannel, _rateOfChange * Time.deltaTime);
			Color color = _image.color;
			color.a = alphaChanel;
			_image.color = color;

			yield return null;
		}

		IsChange = false;
		gameObject.SetActive(false);
	}
}

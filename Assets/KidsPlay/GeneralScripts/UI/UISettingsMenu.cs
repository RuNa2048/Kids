using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class UISettingsMenu : MonoBehaviour
{
	[Header("References")]
	[SerializeField] private List<Button> _buttons;
	[SerializeField] private AudioMixerGroup _mixer;

	[Header("Additions")]
	[SerializeField] private AudioMixerSnapshot _normal;
	[SerializeField] private AudioMixerSnapshot _inMenu;

	private void OnEnable()
	{
		foreach (Button button in _buttons)
		{
			button.interactable = false;
		}

		_inMenu.TransitionTo(0.5f);

		Time.timeScale = 0f;
	}

	private void OnDisable()
	{
		foreach (Button button in _buttons)
		{
			button.interactable = true;
		}

		_normal.TransitionTo(0.5f);

		Time.timeScale = 1f;
	}

	//public void ToogleMusic(bool enabled)
	//{
	//	if (!enabled)
	//	{
	//		_mixer.audioMixer.SetFloat("BackgroundMusicVolume", 0f);
	//	}
	//	else
	//	{
	//		_mixer.audioMixer.SetFloat("BackgroundMusicVolume", -80f);
	//	}
	//}

	public void ChangeMusicVolume(float volume)
	{
		_mixer.audioMixer.SetFloat("BackgroundMusicVolume", Mathf.Lerp(-80f, 0, volume));
	}

	public void ChangeEffectsVolume(float volume)
	{
		_mixer.audioMixer.SetFloat("EffectsVolume", Mathf.Lerp(-80f, 0, volume));
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum DragAndDropSoundEffect
{
	Click,
	Correct,
	Wrong,
}

public class DragAndDropSoundReproducer : MonoBehaviour
{
	[Header("Sounds")]
	[SerializeField] private AudioClip _clickClip;
	[SerializeField] private AudioClip _correctClip;
	[SerializeField] private AudioClip _wrongClip;

	Dictionary<DragAndDropSoundEffect, AudioClip> _soundEffects;

	AudioSource _audioSource;

	private void Awake()
	{
		_audioSource = GetComponent<AudioSource>();

		_soundEffects = new Dictionary<DragAndDropSoundEffect, AudioClip>();
		_soundEffects.Add(DragAndDropSoundEffect.Click, _clickClip);
		_soundEffects.Add(DragAndDropSoundEffect.Correct, _correctClip);
		_soundEffects.Add(DragAndDropSoundEffect.Wrong, _wrongClip);
	}

	public void PlaySoundEffect(DragAndDropSoundEffect effectType)
	{
		if (_soundEffects.ContainsKey(effectType))
		{
			_audioSource.clip = _soundEffects[effectType];
			_audioSource.Play();
		}
		else
		{
			Debug.Log($"Sound effect: {effectType} is not play");
		}
	}
}

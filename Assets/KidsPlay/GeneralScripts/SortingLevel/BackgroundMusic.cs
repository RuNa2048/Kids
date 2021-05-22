using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BackgroundMusic : MonoBehaviour
{
	[SerializeField] private AudioClip _standartMusic;
	[SerializeField] private AudioClip _victoriousMusic;

	[Header("Additions")]
	[SerializeField] private AudioMixerSnapshot _normal;
	[SerializeField] private AudioMixerSnapshot _transition;

	AudioSource _audioSource;

	private void Awake()
	{
		_audioSource = GetComponent<AudioSource>();

		_audioSource.clip = _standartMusic;
		_audioSource.Play();
	}

	public void ChangeMelody()
	{
		StartCoroutine(Toggle());
	}

	private IEnumerator Toggle()
	{
		_transition.TransitionTo(1);

		yield return new WaitForSeconds(1.2f);

		_audioSource.clip = _victoriousMusic;
		_audioSource.Play();
		_normal.TransitionTo(1);
	}

}

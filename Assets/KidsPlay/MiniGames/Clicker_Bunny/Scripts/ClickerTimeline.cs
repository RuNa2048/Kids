using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class ClickerTimeline : MonoBehaviour
{
	[Header("References")]
	[SerializeField] private InsectSpawner _insectSpawner;

	[SerializeField]
	private List<TimelineAsset> _timelineAssets;

	PlayableDirector _playableDirector;

	int _numTimeline = 0;

	private void Start()
	{
		_playableDirector = GetComponent<PlayableDirector>();
		_playableDirector.stopped += OnPlayableDirecotStopped;

		//PlayTimeline();
	}

	public void PlayTimeline()
	{
		_playableDirector.Play(_timelineAssets[_numTimeline]);
		_numTimeline++;
	}

	public void OnPlayableDirecotStopped(PlayableDirector playableDirector)
	{
		if (_numTimeline == 1)
		{
			StartCoroutine(WaitTouchOnSceen());
		}
		else if (_numTimeline == 2)
		{
			_insectSpawner.SpawningWave();
		}
		else if (_numTimeline == 3)
		{
			LoadMainMenu.LoadMenuScene();
		}
	}

	private IEnumerator WaitTouchOnSceen()
	{
		while (Input.touchCount == 0 && !Input.GetMouseButtonDown(0))
		{
			yield return null;
		}

		PlayTimeline();
	}
}

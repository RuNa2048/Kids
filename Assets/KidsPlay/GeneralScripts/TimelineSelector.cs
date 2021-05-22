using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TimelineSelector : MonoBehaviour
{
	[Header("References")]
	[SerializeField]
	private LevelManager _levelManager;

	[SerializeField]
	private List<TimelineAsset> _timelineAssets;

	PlayableDirector _playableDirector;

	int _numTimeline;

	private void Awake()
	{
		_playableDirector = GetComponent<PlayableDirector>();
		_playableDirector.stopped += OnPlayableDirecotStopped;

		if (_levelManager)
			_levelManager.ChangedTimeline += PlayTimeline;
	}

	public void OnPlayableDirecotStopped(PlayableDirector playableDirector)
	{
		if (_numTimeline == 2)
		{
			_levelManager.StartGame();
		}
		else if (_numTimeline == 3)
		{
			_levelManager.LoadMenu();
		}
	}

	public void PlayTimeline()
	{
		_playableDirector.Play(_timelineAssets[_numTimeline]);
		_numTimeline++;
	}
}

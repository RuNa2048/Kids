using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class PuzzleTimeline : MonoBehaviour
{
	[Header("References")]
	[SerializeField]
	private PuzzleContainer _puzzleController;
	[SerializeField]
	private PuzzleSceneSwitcher _puzzleSceneSwitcher;

	[SerializeField]
	private List<TimelineAsset> _timelineAssets;

	public event Action LauchedDecorationEvent;
	public event Action GameInitEvent;
	public event Action EndedGameEvent;

	PlayableDirector _playableDirector;

	int _numTimeline = -1;

	private void Awake()
	{
		_playableDirector = GetComponent<PlayableDirector>();
		_playableDirector.stopped += OnPlayableDirecotStopped;
	}

	public void Start	()
	{
		LauchedDecorationEvent?.Invoke();
		StartTimeline();
	}

	public void StartTimeline()
	{
		_numTimeline++;
		_playableDirector.Play(_timelineAssets[_numTimeline]);
	}

	public void CompleteGame()
	{
		EndedGameEvent?.Invoke();
		StartTimeline();
	}

	private IEnumerator WaitTouchOnSceen()
	{
		while (Input.touchCount == 0 && !Input.GetMouseButtonDown(0))
		{
			yield return null;
		}

		StartTimeline();
	}

	public void OnPlayableDirecotStopped(PlayableDirector playableDirector)
	{
		if (_numTimeline == 0)
		{
			StartCoroutine(WaitTouchOnSceen());
		}
		else if (_numTimeline == 1)
		{
			_puzzleController.SwapCells();
			GameInitEvent?.Invoke();
		}
		else if (_numTimeline == 2)
		{
			_puzzleSceneSwitcher.LoadMenu();
		}
	}
}

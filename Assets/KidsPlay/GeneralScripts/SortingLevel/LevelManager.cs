using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	[Header("References")]
	[SerializeField]
	private TrainingPanel _trainingPanel;
	[SerializeField]
	private TimelineSelector _timelineSelector;
	[SerializeField]
	private GameStage _gameStage;

	//[SerializeField]
	//private float _delay;

	//public event Action CompletingCutSceneEvent;
	public event Action StartingLevelEvent;
	public event Action ChangedTimeline;
	//public event Action CompletingLevelEvent;

	bool _gameIsStart = false;

	public void CompleteGame()
	{
		ChangeTimeline();
	}

	public void Start()
	{
		ChangeTimeline();
	}

	public void ChangeTimeline()
	{
		_timelineSelector.PlayTimeline();
		//ChangedTimeline?.Invoke();
	}

	public void StartGame()
	{
		_gameStage.StartFirstStage();
		//StartingLevelEvent.Invoke();
	}

	public void LoadMenu()
	{
		SceneManager.LoadScene(0);
	}

	public void RestartLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}

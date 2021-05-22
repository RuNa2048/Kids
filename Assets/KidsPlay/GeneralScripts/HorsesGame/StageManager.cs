using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Bunch
{
	public Horse Horse;
	public Sleigh Sleigh;
}

[Serializable]
public struct Bunches
{
	public List<Bunch> bunches;
}

public class StageManager : MonoBehaviour
{
	[Header("Data")]
	[SerializeField]
	private List<Bunches> _pullBunches;

	[Header("References")]
	[SerializeField]
	private Spawner _spawner;

	int _currentStage;
	int _quantityCorrectBunches = 0;

	private void Start()
	{
		StartStage();
	}

	public void StartStage()
	{
		if (_currentStage > _pullBunches.Count)
		{
			Debug.Log("End Game");
			return;
		}

		_spawner.Spawn(_pullBunches[_currentStage]);
		_currentStage++;
	}

	public void CheckStateProgress()
	{
		_quantityCorrectBunches++;

		if (_quantityCorrectBunches > _pullBunches[_currentStage].bunches.Count)
		{
			Debug.Log("End stage!");
			StartStage();
		}
	}
}

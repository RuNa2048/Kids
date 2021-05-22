using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Horse : Team
{
	[SerializeField]
	private Vector3 _sleighPosition;

	public RectTransform GetRectTransform { get { return rectTransform; }  }

	Animator _animator;
	StageManager _stageManager;


	public void Init(RectTransform spawnPoint, StageManager stageManager)
	{
		rectTransform = GetComponent<RectTransform>();
		_animator = GetComponent<Animator>();
		_stageManager = stageManager;

		SetMoveBehaviour(new GeneralWalkBehaviour(rectTransform, movingSpeed));

		PerformSetPosition(spawnPoint.position);
	//	PerformMoving(startPosition, waitingTime);
	}

	public bool CheckDifference(Sleigh draggin)
	{
		bool entered = rectTransform.rect.Contains(draggin.GetRectTransform.position);

		if (entered)
		{
			draggin.PerformMoving(Vector3.zero, 0f);
			PerformMoving(endPosition.position, 0.1f);

			_stageManager.CheckStateProgress();
		}

		return entered;
	}
}

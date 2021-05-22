using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Sleigh : Team, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
	public Horse RightHorse { private get; set; }
	public RectTransform GetRectTransform { get { return rectTransform; } } 

	RectTransform _horseRectTransform;
	Transform _standartParent;
	Transform _draggingArea;

	bool _isFree = false;

	public void Init(Vector3 spawnPoint, Transform draggingArea)
	{
		rectTransform = GetComponent<RectTransform>();
		_draggingArea = draggingArea;

		SetMoveBehaviour(new GeneralWalkBehaviour(rectTransform, movingSpeed));
		PerformSetPosition(spawnPoint);

		_horseRectTransform = RightHorse.GetRectTransform;
		_standartParent = transform.parent;

		PerformMoving(startPosition.position, waitingTime);

		_isFree = true;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if (_isFree)
		{
			transform.SetParent(_draggingArea);
		}
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (RightHorse.CheckDifference(this))
		{
			_isFree = false;
			transform.SetParent(_standartParent);

			return;
		}

		rectTransform.anchoredPosition += eventData.delta;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		if (_isFree)
		{
			transform.SetParent(_standartParent);

			PerformMoving(startPosition.position, 0f);
		}
	}
}

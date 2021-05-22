using System;
using UnityEngine;

public abstract class Team: MonoBehaviour
{
	[Header("Movable")]
	[SerializeField]
	protected RectTransform startPosition;
	[SerializeField]
	protected RectTransform endPosition;
	[SerializeField]
	protected float movingSpeed;
	[SerializeField]
	protected float waitingTime = 0f;

	protected RectTransform rectTransform;

	private IMoveBehaviour _moveBehaviour;

	public void SetMoveBehaviour(IMoveBehaviour moveBehaviour) => _moveBehaviour = moveBehaviour;

	public void PerformSetPosition(Vector2 point) => _moveBehaviour.SetPosition(point);

	public void PerformSetMoveSpeed() => _moveBehaviour.SetMoveSpeed(movingSpeed);

	public void PerformMoving(Vector2 point, float waitingTime) => StartCoroutine(_moveBehaviour.MovingToCurrentPoint(point, waitingTime));
}

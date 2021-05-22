using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveBehaviour
{
	float SetMoveSpeed(float speed);
	void SetPosition(Vector2 point);
	IEnumerator MovingToCurrentPoint(Vector2 point, float waitingTime);
}

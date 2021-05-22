using System.Collections;
using UnityEngine;

public class GeneralWalkBehaviour : IMoveBehaviour
{
	private RectTransform _rectTransform;
	private float _speed;

	public GeneralWalkBehaviour(RectTransform rectTransform, float speed)
	{
		_rectTransform = rectTransform;
		_speed = speed;
	}

	public float SetMoveSpeed(float speed) => _speed = speed;

	public void SetPosition(Vector2 point)
	{
		_rectTransform.localPosition = point;
		Debug.Log(point);
	}

	//public void Move(Vector3 point, float waitingTime)
	//{
	//	StartCoroutine(MovingToCurrentPoint(point, waitingTime));
	//}

	public IEnumerator MovingToCurrentPoint(Vector2 point, float waitingTime)
	{
		yield return new WaitForSeconds(waitingTime);

		float step = _speed * Time.deltaTime;

		while ((Vector2)_rectTransform.position != point)
		{
			_rectTransform.position = Vector2.MoveTowards(_rectTransform.position, point, step);

			yield return null;
		}
	}
}

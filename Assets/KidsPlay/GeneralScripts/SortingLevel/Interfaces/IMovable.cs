using System.Collections;
using UnityEngine;

public interface IMovable
{
	IEnumerator Move(RectTransform rectTransform, Vector2 point, float speed);
}

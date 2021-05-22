using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointOccurrence : MonoBehaviour
{
	private List<Insect> _insects;
	public void AddInsectInPull(Insect insect) => _insects.Add(insect);

	private void Awake()
	{
		_insects = new List<Insect>();
	}

	public bool CheckPoint(Vector2 point)
	{
		bool isEnter = false;

		foreach (Insect insect in _insects)
		{
			if (insect.ColliderBounds.Contains(point))
			{
				isEnter = true;
			}
		}

		return isEnter;
	}
}

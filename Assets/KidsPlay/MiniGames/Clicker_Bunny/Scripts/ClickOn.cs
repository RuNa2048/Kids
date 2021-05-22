using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickOn : MonoBehaviour, IPointerDownHandler
{
	Insect _insect;

	private void Start()
	{
		_insect = GetComponent<Insect>();
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		_insect.ClickOnMe();
	}
}

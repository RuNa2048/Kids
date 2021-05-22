using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerDecoration : MonoBehaviour
{
	[SerializeField] private float _delay;
	[SerializeField] private float _timeBeforeStart;

	Animator _animator;

	private void Start()
	{
		_animator = GetComponent<Animator>();

		StartCoroutine(CreateDelay());
	}

	private IEnumerator CreateDelay()
	{
		yield return new WaitForSeconds(_timeBeforeStart);

		while(true)
			yield return StartCoroutine(WaitingAndStart());
	}

	private IEnumerator WaitingAndStart()
	{
		float timer = 0f;

		while (timer < _delay)
		{
			timer += Time.deltaTime;
			yield return null;
		}

		_animator.SetTrigger("IsMove");
	}
}

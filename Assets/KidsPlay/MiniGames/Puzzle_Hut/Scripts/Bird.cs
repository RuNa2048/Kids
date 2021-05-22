using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
	[SerializeField] private float _movingSpeed;
	[SerializeField] private float _approachSpeed;
	[SerializeField] private Vector3 _minScale;
	[SerializeField] private Vector3 _maxScale;
	[SerializeField] private Vector3 _endPos;

	private Vector3 _startPos;

	private bool _isApproaching = false;

	Animator _animator;

	public void Start()
	{
		//_animator = GetComponent<Animator>();

		//_animator.SetBool("IsFly", true);

		_startPos = transform.localPosition;
		//_endPos = endPos;

		//_minScale = new Vector3(0.2f, 0.2f, 1);
		//_maxScale = Vector3.one;

		transform.localScale = _minScale;

		StartCoroutine(Move());
	}

	private IEnumerator ApproximationToScreen(Vector3 scale)
	{
		_isApproaching = true;

		while (transform.localScale != Vector3.one)
		{
			transform.localScale = Vector3.MoveTowards(transform.localScale, scale, _approachSpeed * Time.deltaTime);

			yield return null;
		}

		_isApproaching = false;
	}

	private IEnumerator Move()
	{
		yield return StartCoroutine(ApproximationToScreen(_maxScale));

		while (!_isApproaching && transform.localScale != _minScale)
		{
			transform.localPosition = Vector3.MoveTowards(transform.localPosition, _endPos, _movingSpeed * Time.deltaTime);
			transform.localScale = Vector3.MoveTowards(transform.localScale, _minScale, _approachSpeed * Time.deltaTime);

			yield return null;
		}

		ReturnToInitialState();
	}

	private void ReturnToInitialState()
	{
		transform.localPosition = _startPos;

		StartCoroutine(Move());
	}
}

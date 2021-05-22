using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandpaAnimation : MonoBehaviour
{
	[SerializeField]
	private PuzzleTimeline _puzzleTimeline;

	[SerializeField]
	[Range(0f, 5f)]
	private float _minAnimatorCooldown;
	[SerializeField]
	[Range(5f, 15f)]
	private float _maxAnimatorCooldown;

	Animator _animator;

	bool _isGaming;

	private void Awake()
	{
		_puzzleTimeline.GameInitEvent += OnInit;
		_puzzleTimeline.EndedGameEvent += GameIsEnd;
	}

	public void OnInit()
	{
		_animator = GetComponent<Animator>();

		StartCoroutine(ChangeAnimation());
	}

	public void GameIsEnd()
	{
		StopCoroutine(ChangeAnimation());
	}

	private IEnumerator ChangeAnimation()
	{
		float waitingTime = Random.Range(_minAnimatorCooldown, _maxAnimatorCooldown);
		Debug.Log(waitingTime);
		yield return new WaitForSeconds(waitingTime);
	}
}

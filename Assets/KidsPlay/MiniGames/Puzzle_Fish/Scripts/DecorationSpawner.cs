using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DecorationSpawner : MonoBehaviour
{
	[Header("References")]
	[SerializeField]
	private PuzzleTimeline _puzzleTimeline;

	[Header("Decoration settings")]
	[SerializeField] private float waitingPeriod = 0.25f;
	[Range(0.2f, 1f), SerializeField] private float _scaleSize;
	[Range(10f, 25f), SerializeField] private float _movingSpeed;

	[SerializeField]
	protected Decoration[] decorationPrefabs;

	protected RectTransform rectTransform;

	bool _spawnIsWork = false;

	protected virtual void Awake()
	{
		rectTransform = GetComponent<RectTransform>();

		_puzzleTimeline.LauchedDecorationEvent += Startup;
	}

	protected void Startup()
	{
		_spawnIsWork = true;
		StartCoroutine(Spawn());
	}

	protected void Shutdown()
	{
		_spawnIsWork = false;
		StopCoroutine(Spawn());
	}

	protected IEnumerator Spawn()
	{
		while (_spawnIsWork)
		{
			yield return new WaitForSeconds(waitingPeriod);

			int rndNumBubble = Random.Range(0, decorationPrefabs.Length);
			float rndSpeedValue = Random.Range(10f, _movingSpeed);
			float randomScale = Random.Range(0.2f, _scaleSize);

			Vector2 spawnPosition = ChangeSpawnPosition();

			Decoration decoration = CreateElement(rndNumBubble);
			decoration.Init(rndSpeedValue);
			decoration.RectTransform.anchoredPosition = spawnPosition;
			decoration.transform.localScale = new Vector3(randomScale, randomScale, 1f);
			decoration.transform.SetParent(transform, false);
		}
	}

	protected abstract Vector2 ChangeSpawnPosition();

	protected abstract Decoration CreateElement(int index);
}

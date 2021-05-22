using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : DecorationSpawner
{
	[Header("Spawn distance: CloudSpawner")]
	[SerializeField]
	private float _widthEdgeDistance;
	[SerializeField]
	private float _heightEdgeDistance;

	float _XSpawnPos;
	float _YMinSpawnPos;
	float _YMaxSpawnPos;

	protected override void Awake()
	{
		base.Awake();

		_XSpawnPos = (rectTransform.anchoredPosition.x - (rectTransform.rect.width / 2)) - _widthEdgeDistance;
		_YMinSpawnPos = (rectTransform.anchoredPosition.y - (rectTransform.rect.height / 2)) + _heightEdgeDistance;
		_YMaxSpawnPos = (rectTransform.anchoredPosition.y + (rectTransform.rect.height)) - _heightEdgeDistance;
	}

	protected override Vector2 ChangeSpawnPosition()
	{
		float rndYPos = Random.Range(_YMinSpawnPos, _YMaxSpawnPos);
		return new Vector2(_XSpawnPos, rndYPos);
	}

	protected override Decoration CreateElement(int index)
	{
		return Instantiate(decorationPrefabs[index]);
	}
}

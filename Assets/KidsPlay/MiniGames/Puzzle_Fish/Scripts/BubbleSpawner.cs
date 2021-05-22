using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : DecorationSpawner
{
	protected override Vector2 ChangeSpawnPosition()
	{
		return new Vector2(Random.Range(rectTransform.rect.xMin, rectTransform.rect.xMax), Random.Range(rectTransform.rect.yMin, rectTransform.rect.yMax));
	}

	protected override Decoration CreateElement(int index)
	{
		return Instantiate(decorationPrefabs[index]);
	}
}

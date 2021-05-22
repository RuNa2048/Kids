using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Container : MonoBehaviour
{
	[Header("References")]
	[SerializeField]
	private GameStage _gameStage;

	[Header("Cells")]
	[SerializeField]
	protected List<ContainerCell> cells;

	protected List<Item> items;
	public void AddItems(List<Item> items) => this.items = items;

	protected virtual void Awake()	
	{
		_gameStage.ChoiceEvent += Renderer;
	}

	protected void Renderer(List<DoubleItem> assetItems)
	{
		List<DoubleItem> items = new List<DoubleItem>();
		
		items = OrderRandomization(assetItems);
		
		for (int i = 0; i <= cells.Count - 1; i++)
		{
			cells[i].Renderer(items[i]);
		}
	}

	protected List<T> OrderRandomization<T>(List<T> assetItems)
	{
		List<T> items = new List<T>();
		foreach (T item in assetItems)
		{
			items.Add(item);
		}

		for (int i = items.Count - 1; i >= 1; i--)
		{
			int j = Random.Range(0, items.Count - 1);

			var tempCell = items[j];
			items[j] = items[i];
			items[i] = tempCell;
		}

		return items;
	}
}

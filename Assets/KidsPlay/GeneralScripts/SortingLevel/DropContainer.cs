using UnityEngine;

public class DropContainer : Container
{
	[SerializeField]
	private ScoreManager _scoreManager;

	RectTransformUtility _rectTransformUtility;

	public void CheckForBinding(DragContainerCell dragCell)
	{
		foreach (DropContainerCell cell in cells)
		{
			if (cell.Name == dragCell.Name)
			{
				bool entered = RectTransformUtility.RectangleContainsScreenPoint(cell.GetRectTransform(), dragCell.GetRectTransform().position);

				if (entered)
				{
					dragCell.DisableCell(cell.GetRectTransform());
					_scoreManager.UpdateScore();
				}
			}
		}
	}
}

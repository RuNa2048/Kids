using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragContainerCell : ContainerCell, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
	[Header("References: DragContainerCell")]
	[SerializeField]
	private DropContainer _dropContainer;
	[SerializeField]
	private Transform _dragginParent;
	[SerializeField]
	private Transform _standartParent;

	private Vector2 _startPosition = Vector2.zero;

	public Vector2 StartingPosition { get; private set; }

	bool _isFree = true;

	public override void Renderer(IDoubleItem item)
	{
		EnableCell();

		nameField = item.Name;
		imageField.sprite = item.UIMainIcon;

		if (_startPosition == Vector2.zero)
		{
			_startPosition = rectTransform.position;
		}

		rectTransform.position = _startPosition;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		transform.SetParent(_dragginParent);
		_isFree = true;
	}

	public void OnDrag(PointerEventData eventData)
	{
		_dropContainer.CheckForBinding(this);

		if (!_isFree)
			return;

		rectTransform.anchoredPosition += eventData.delta;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		transform.SetParent(_standartParent);

		if (_isFree)
		{
			StartCoroutine(MoveTo(_startPosition));
		}
	}

	public override void Move(Vector2 point)
	{
		imageField.raycastTarget = false;

		StartCoroutine(MoveTo(point));

		imageField.raycastTarget = true;
	}

	public void EnableCell()
	{
		StopAllCoroutines();

		enabled = true;
	}

	public void DisableCell(RectTransform dropRectTrans)
	{
		_isFree = false;
		transform.SetParent(_standartParent);

		StopAllCoroutines();
		StartCoroutine(MoveTo(dropRectTrans.position));

		Vector2 myPrevPivot = rectTransform.pivot;
		myPrevPivot = dropRectTrans.pivot;
		rectTransform.position = dropRectTrans.position;

		rectTransform.localScale = dropRectTrans.localScale;

		rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, dropRectTrans.rect.width);
		rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, dropRectTrans.rect.height);
	
		rectTransform.pivot = myPrevPivot;

		enabled = false;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PuzzleCell : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
	public int id;

	[Header("References")]
	[SerializeField] private Transform _emptyCell;
	[SerializeField] private PuzzleScore _puzzleScore;
	[SerializeField] private DragAndDropSoundReproducer _soundReproducer;

	[Header("Moving")]
	[SerializeField] private float _swapSpeed;
	[SerializeField] private float _movingSpeed;

	private Vector3 _startPosition;

	SpriteRenderer _emptyCellSprite;
	SpriteRenderer _spriteRend;
	BoxCollider2D _collider;

	float step;
	bool _isFree = true;
	bool _isMoving = true;
	bool _isInit = false;

	public bool IsMoving { get { return _isMoving; } private set { } }
	public bool IsInit { get { return _isInit; } private set { } }

	private void Awake()
	{
		_collider = GetComponent<BoxCollider2D>();
		_spriteRend = GetComponent<SpriteRenderer>();
		_emptyCellSprite = _emptyCell.gameObject.GetComponent<SpriteRenderer>();
	}

	public void Init(Vector3 point)
	{
		_startPosition = point;

		StartCoroutine(Move(_startPosition, _swapSpeed));

		_isInit = true;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if (_isFree && _isInit)
		{
			LayerTransfer(gameObject , -2);

			_soundReproducer.PlaySoundEffect(DragAndDropSoundEffect.Click);
		}
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (_isFree && _isInit)
		{
			Vector3 inputPosition = Camera.main.ScreenToWorldPoint(eventData.position);
			inputPosition.z = transform.position.z;

			transform.position = inputPosition;
		}
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		if (_isFree && _isInit)
		{
			ReturnToInitialState();
		}
	}

	private void ReturnToInitialState()
	{
		StartCoroutine(Move(_startPosition, _movingSpeed));

		LayerTransfer(gameObject, 2);
	}

	private void LayerTransfer(GameObject go ,int level)
	{
		Vector3 transfer = go.transform.position;
		transfer.z += level;

		go.transform.position = transfer;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		EmptyPuzzleCell emptyCell = collision.GetComponent<EmptyPuzzleCell>();

		if (!_isMoving && id == emptyCell.id)
		{
			_isFree = false;

			_soundReproducer.PlaySoundEffect(DragAndDropSoundEffect.Correct);

			StartCoroutine(Binding(_emptyCell.position));
		}
	}

	private IEnumerator Binding(Vector2 position)
	{
		StartCoroutine(Move(position, _movingSpeed));

		while (_isMoving)
		{
			yield return null;
		}

		_emptyCellSprite.sprite = _spriteRend.sprite;
		_emptyCellSprite.color = new Color(1, 1, 1, 1);

		LayerTransfer(_emptyCell.gameObject , 3);

		_puzzleScore.UpdateScore();

		Destroy(gameObject);
	}

	public IEnumerator Move(Vector2 position, float speed)
	{
		while ((Vector2)transform.position != position)
		{
			_isMoving = true;
			transform.localPosition = Vector2.MoveTowards(transform.localPosition, position, speed * Time.deltaTime);

			yield return null;
		}

		_isMoving = false;
	}
}

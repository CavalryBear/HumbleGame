using UnityEngine;
using System.Collections;

/// <summary>
/// This script updates the Order In Layer of the SpriteRenderer of its gameObject to reflect its position on the y-axis.
/// </summary>

[RequireComponent(typeof(SpriteRenderer))]
public class AdjustSortingLayerOrder : MonoBehaviour {

	private SpriteRenderer _spriteRenderer;

	/// <summary>
	/// Get a reference to the SpriteRenderer on Awake
	/// </summary>
	void Awake() {
		_spriteRenderer = GetComponent<SpriteRenderer>();
	}

	/// <summary>
	/// Update the Order In Layer of the SpriteRenderer every frame
	/// </summary>
	void Update () {
		_spriteRenderer.sortingOrder = (int)(-100 * _spriteRenderer.bounds.min.y);
	}
}

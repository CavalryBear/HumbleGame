using UnityEngine;
using System.Collections;

/// <summary>
/// This script updates the Order In Layer of the SpriteRenderer of its gameObject to reflect its position on the y-axis.
/// </summary>

public class AdjustSortingLayerOrder : MonoBehaviour {

	private MeshRenderer _meshRenderer;

	/// <summary>
	/// Get a reference to the SpriteRenderer on Awake
	/// </summary>
	void Awake() {
		_meshRenderer = GetComponentInChildren<MeshRenderer>();
	}

	/// <summary>
	/// Update the Order In Layer of the SpriteRenderer every frame
	/// </summary>
	void Update () {
		_meshRenderer.sortingOrder = (int)(-100 * _meshRenderer.bounds.min.y);
	}
}

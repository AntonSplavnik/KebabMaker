using UnityEngine;

public class MoveCamera : MonoBehaviour
{
	public Transform playerPosition;
	public Vector3 offset;
	void Update()
	{
		transform.position = playerPosition.position + offset;
	}
}
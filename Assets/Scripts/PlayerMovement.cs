using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private CharacterController _characterController;
	[SerializeField] private float _speed = 1.0f;
	
	private void Update()
	{
		var x = Input.GetAxis("Horizontal");
		var z = Input.GetAxis("Vertical");
		
		var move = transform.right * x + transform.forward * z;
		_characterController.Move(move * _speed * Time.deltaTime);
	}
	
}

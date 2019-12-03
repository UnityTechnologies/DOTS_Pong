using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class PlayerInputSystem : ComponentSystem
{
	protected override void OnUpdate()
	{
		Entities.ForEach((ref PlayerInputData inputData, ref PaddleMovementData moveData) => 
		{
			moveData.direction = 0;

			moveData.direction += Input.GetKey(inputData.upKey) ? 1 : 0;
			moveData.direction -= Input.GetKey(inputData.downKey) ? 1 : 0;
		});
	}
}

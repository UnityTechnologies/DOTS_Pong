using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

[AlwaysSynchronizeSystem]
public class PlayerInputSystem : JobComponentSystem
{
	protected override JobHandle OnUpdate(JobHandle inputDeps)
	{
		Entities.ForEach((ref PaddleMovementData moveData, in PaddleInputData inputData) =>
		{
			moveData.direction = 0;

			moveData.direction += Input.GetKey(inputData.upKey) ? 1 : 0;
			moveData.direction -= Input.GetKey(inputData.downKey) ? 1 : 0;
		}).Run();

		return default;
	}
}

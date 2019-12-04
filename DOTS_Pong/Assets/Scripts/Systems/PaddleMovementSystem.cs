using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class PaddleMovementSystem : JobComponentSystem
{
	protected override JobHandle OnUpdate(JobHandle inputDeps)
	{
		float deltaTime = Time.DeltaTime;
		float yBound = GameManager.main.yBound;

		JobHandle handle = Entities
			.WithBurst()
			.WithReadOnly(deltaTime)
			.WithReadOnly(yBound)
			.ForEach((ref Translation trans, in PaddleMovementData data) => 
		{
			float3 pos = trans.Value;
			pos.y += data.speed * data.direction * deltaTime;

			if (pos.y > yBound) pos.y = yBound;
			if (pos.y < -yBound) pos.y = -yBound;

			trans.Value = pos;
		}).Schedule(inputDeps);

		return handle;
	}

}

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
	public struct MoveJob : IJobForEach<PaddleMovementData, Translation>
	{
		public float deltaTime;
		public float yBound;

		public void Execute([ReadOnly] ref PaddleMovementData data, ref Translation trans)
		{
			float3 pos = trans.Value;
			pos.y += data.speed * data.direction * deltaTime;

			if (pos.y > yBound) pos.y = yBound;
			if (pos.y < -yBound) pos.y = -yBound;

			trans.Value = pos;
		}
	}

	protected override JobHandle OnUpdate(JobHandle inputDeps)
	{
		MoveJob job = new MoveJob
		{
			deltaTime = Time.DeltaTime,
			yBound = GameManager.main.yBound
		};

		return job.Schedule(this, inputDeps);
	}

}

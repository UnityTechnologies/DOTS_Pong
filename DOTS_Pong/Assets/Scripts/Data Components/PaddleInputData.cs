using Unity.Entities;
using UnityEngine;

[GenerateAuthoringComponent]
public struct PaddleInputData : IComponentData
{
	public KeyCode upKey;
	public KeyCode downKey;
}

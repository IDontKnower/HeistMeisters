using Godot;
using System;

namespace HeistMeisters.Characters
{
	public class TemplateCharacter : KinematicBody2D
	{
		public virtual int Speed { get; set; } = 20;
		public virtual int MaxSpeed { get; set; } = 100;
		public virtual float Friction { get; set; } = 0.1f;
	}
}

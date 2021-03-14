using Godot;
using System;

namespace HeistMeisters.Characters
{
	public class Player : TemplateCharacter
	{
		private Vector2 _motion;

		public override void _Ready()
		{

		}

		public override void _PhysicsProcess(float delta)
		{
			UpdateMovement();
			MoveAndSlide(_motion);
			base._PhysicsProcess(delta);
		}

		private void UpdateMovement()
		{
			LookAt(GetGlobalMousePosition());

			if(Input.IsActionPressed("move_down") & !Input.IsActionPressed("move_up"))
			{
				_motion.y = Mathf.Clamp(_motion.y + Speed, 0, MaxSpeed);
			}
			else if (Input.IsActionPressed("move_up") & !Input.IsActionPressed("move_down"))
			{
				_motion.y = Mathf.Clamp(_motion.y - Speed, -MaxSpeed, 0);
			}
			else
			{
				_motion.y = Mathf.Lerp(_motion.y, 0, Friction);
			}

			if (Input.IsActionPressed("move_left") & !Input.IsActionPressed("move_right"))
			{
				_motion.x = Mathf.Clamp(_motion.x - Speed, -MaxSpeed, 0);
			}
			else if (Input.IsActionPressed("move_right") & !Input.IsActionPressed("move_left"))
			{
				_motion.x = Mathf.Clamp(_motion.x + Speed, 0, MaxSpeed);
			}
			else
			{
				_motion.x = Mathf.Lerp(_motion.x, 0, Friction);
			}
		}
	}
}

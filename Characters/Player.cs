using Godot;
using System;

namespace HeistMeisters.Characters
{
	public class Player : TemplateCharacter
	{
		private Vector2 _motion;
		private Light2D _flashLight;

		public override void _Ready()
		{
			_flashLight = (Light2D)GetNode("Flashlight");
		}

		public override void _PhysicsProcess(float delta)
		{
			UpdateMovement();
			MoveAndSlide(_motion);
			base._PhysicsProcess(delta);
		}

		public override void _Input(InputEvent @event)
		{
			UpdateFlashLight();
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

		public void UpdateFlashLight()
		{
			if (Input.IsActionJustReleased("flashlight_toggle"))
			{
				_flashLight.Enabled = !_flashLight.Enabled;
			}
		}
	}
}

using Azimuth.GameStates;
using Azimuth.UI;

using System.Numerics;

namespace DinoRun
{
	public class MainMenuState : IGameState
	{
		public string ID => DinoRun.MAIN_MENU_STATE_ID;

		private Button playButton;
		private Vector2 buttonSize = new Vector2(200, 100);
		

		public void Load()
		{
			playButton = new Button(new Vector2(Azimuth.Config.Get<int>("Window", "width")/2 -(buttonSize.X / 2) ,Azimuth.Config.Get<int>("Window", "height")/2 - (buttonSize.Y / 2)), buttonSize, new Button.RenderSettings()
			{
				text = "Play"
			});
			
			playButton.AddListener(() =>
			{
				GameStateManager.ActivateState(DinoRun.PLAY_STATE_ID);
				GameStateManager.DeactivateState(ID);
			});
			
			UIManager.Add(playButton);
		}

		public void Update(float _deltaTime) { }

		public void Draw() { }

		public void Unload()
		{
			UIManager.Remove(playButton);
		}
	}
}
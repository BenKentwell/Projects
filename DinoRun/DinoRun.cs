using Azimuth;
using Azimuth.GameStates;

namespace DinoRun
{
	public class DinoRun : Game
	{
		public const string MAIN_MENU_STATE_ID = "Main Menu";
		public const string PLAY_STATE_ID = "Play";
		
		public override void Load()
		{ 
			GameStateManager.AddState(new MainMenuState());
			GameStateManager.AddState(new PlayState());
			
			GameStateManager.ActivateState(MAIN_MENU_STATE_ID);
		}

		public override void Unload()
		{
			
		}
	}
}
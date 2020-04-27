using UnityEngine; 

public class OfficeDayCycle : OnMessage<WorldSwapPeaked>
{
	[SerializeField] private CurrentGameState game;
	[SerializeField] private GameObject morningLight;
	[SerializeField] private GameObject afternoonLight;
	[SerializeField] private GameObject eveningLight;

	private void Awake()
	{
		afternoonLight.SetActive(false);
		eveningLight.SetActive(false);
		morningLight.SetActive(true);
	}

	protected override void Execute(WorldSwapPeaked msg)
	{
		var numBlackouts = game.GameState.BlackoutsToday;
		morningLight.SetActive(numBlackouts == 0);
		afternoonLight.SetActive(numBlackouts == 1);
		eveningLight.SetActive(numBlackouts > 1);
	}
}

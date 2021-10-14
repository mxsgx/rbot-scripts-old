using RBot;

public class Script {
	public void ScriptMain( ScriptInterface bot ){
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		bot.Options.InfiniteRange = true;
		
		bot.Skills.Add( 1, 1 );
		bot.Skills.Add( 2, 1 );
		bot.Skills.Add( 3, 1 );
		bot.Skills.Add( 4, 1 );
		bot.Skills.StartTimer();
		
		while ( ! bot.ShouldExit() ) {
			if (bot.Map.Name != "banished") {
				bot.Player.Join("banished", "r14", "Left");
			}

			bot.Player.HuntForItem("Desterrat Moya", "Apocryphal Blade Of The Truth", 1);
		}
	}
}

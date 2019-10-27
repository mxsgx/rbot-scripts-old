using RBot;

public class Script {
	public void ScriptMain( ScriptInterface bot ){
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		bot.Options.ExitCombatBeforeQuest = true;
		bot.Options.PrivateRooms = true;
		
		while ( ! bot.ShouldExit() ) {
			if ( bot.Map.Name != "armory" )
				bot.Player.Join( "armory", "r10", "Down" );
			
			bot.Quests.EnsureAccept( 3092 );
			
			if ( ! bot.Inventory.ContainsTempItem( "Chaos Army Defeated" ) )
				bot.Map.GetMapItem( 1957 );
			
			if ( bot.Quests.CanComplete( 3092 ) )
				bot.Quests.EnsureComplete( 3092 );
			
			bot.Sleep( 1000 );
		}
	}
}

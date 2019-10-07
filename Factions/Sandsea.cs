using RBot;

public class Script {
	public void ScriptMain( ScriptInterface bot ){
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		bot.Options.ExitCombatBeforeQuest = true;
		bot.Options.HuntDelay = 500;
		bot.Options.InfiniteRange = true;
		
		bot.Skills.Add( 1, 1 );
		bot.Skills.Add( 2, 1 );
		bot.Skills.Add( 3, 1 );
		bot.Skills.Add( 4, 1 );
		bot.Skills.StartTimer();
		
		while( true ) {
			for( int i = 916; i < 926; i++ ) {
				bot.Quests.EnsureAccept( i );

				if ( bot.Quests.CanComplete( i ) ) {
					bot.Quests.EnsureComplete( i );
				}
				
				bot.Quests.EnsureAccept( i );
			}
			
			if ( bot.Map.Name != "sandsea" )
				bot.Player.Join( "sandsea" );
			
			bot.Map.GetMapItem( 247 );
			bot.Map.GetMapItem( 248 );
			bot.Map.GetMapItem( 249 );
			
			bot.Player.Hunt( "Bupers Camel|Cactus Creeper|Desert Vase|Sand Monkey" );
		}
	}
}

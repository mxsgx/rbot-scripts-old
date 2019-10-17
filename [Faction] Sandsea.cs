using RBot;

public class Script {
	public void CheckQuests( ScriptInterface bot ) {
		for ( int i = 916; i < 926; i++ ) {
			if ( ! bot.Quests.IsInProgress( i ) )
				bot.Quests.EnsureAccept( i );

			if ( bot.Quests.CanComplete( i ) ) {
				bot.Quests.EnsureComplete( i );
				bot.Quests.EnsureAccept( i );
			}
		}
	}

	public void GetMapItem( ScriptInterface bot ) {
		bot.Map.GetMapItem( 247 );
		bot.Map.GetMapItem( 248 );
		bot.Map.GetMapItem( 249 );
	}

	public void ScriptMain( ScriptInterface bot ) {
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		bot.Options.ExitCombatBeforeQuest = true;
		bot.Options.InfiniteRange = true;
		
		bot.Skills.Add( 1, 1 );
		bot.Skills.Add( 2, 1 );
		bot.Skills.Add( 3, 1 );
		bot.Skills.Add( 4, 1 );
		bot.Skills.StartTimer();
		
		while ( true ) {
			if ( bot.Map.Name != "sandsea" )
				bot.Player.Join( "sandsea" );
			
			CheckQuests( bot );
			
			string[] monsters = {
				"Desert Vase",
				"Bupers Camel",
				"Sand Monkey",
				"Cactus Creeper"
			};

			foreach ( string monster in monsters ) {
				bot.Player.Hunt( monster );
				GetMapItem( bot );
				bot.Sleep( 1000 );
				CheckQuests( bot );
			}
		}
	}
}

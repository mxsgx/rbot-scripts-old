using RBot;

public class Script {
	public void CheckQuests( ScriptInterface bot ) {
		bot.Quests.EnsureAccept( 3298 );
		bot.Quests.EnsureAccept( 3050 );
		
		if ( bot.Quests.CanComplete( 3298 ) )
			bot.Quests.EnsureComplete( 3298 );
		
		if ( bot.Quests.CanComplete( 3050 ) )
			bot.Quests.EnsureComplete( 3050 );
		
		bot.Quests.EnsureAccept( 3298 );
		bot.Quests.EnsureAccept( 3050 );
	}
  
	public void ScriptMain( ScriptInterface bot ) {
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		bot.Options.ExitCombatBeforeQuest = true;
		bot.Options.InfiniteRange = true;
		bot.Options.HuntDelay = 500;
		
		bot.Skills.Add( 1, 1 );
		bot.Skills.Add( 2, 1 );
		bot.Skills.Add( 3, 1 );
		bot.Skills.Add( 4, 1 );
		bot.Skills.StartTimer();
		
		while ( true ) {
			if ( bot.Map.Name != "gilead" )
				bot.Player.Join( "gilead" );
			
			CheckQuests( bot );
			
			string[] monsters = {
				"Earth Elemental",
				"Fire Elemental",
				"Mana Elemental",
				"Water Elemental",
				"Wind Elemental"
			};
			
			foreach( string monster in monsters ) {
				bot.Player.Hunt( monster );
				CheckQuests( bot );
			}
		}
	}
}

using RBot;

public class Script {
	public ScriptInterface Bot;
	
	public void CheckQuests() {
		if ( Bot.Quests.CanComplete( 3594 ) )
			Bot.Quests.EnsureComplete( 3594, -1, false, 5 );
		
		Bot.Quests.EnsureAccept( 3594, 5 );
	}
	
	public void ScriptMain( ScriptInterface bot ){
		Bot = bot;
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		bot.Options.ExitCombatBeforeQuest = true;
		bot.Options.InfiniteRange = true;
		
		bot.Skills.Add( 1, 1 );
		bot.Skills.Add( 2, 1 );
		bot.Skills.Add( 3, 1 );
		bot.Skills.Add( 4, 1 );
		bot.Skills.StartTimer();
		
		while ( ! bot.ShouldExit() ) {
			if ( bot.Map.Name != "mountdoomskull" )
				bot.Player.Join( "mountdoomskull" );
			
			CheckQuests();
			bot.Player.HuntForItem( "Chaorrupted Healer|Chaorrupted Mage|Chaorrupted Rogue|Chaos Spider|Chaos Drow", "Chaos Power Increased", 6, true );
		}
	}
}

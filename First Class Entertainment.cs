using RBot;

public class Script {
	public ScriptInterface Bot;
	
	public void CheckItemsRequired() {
		if ( Bot.Bank.Contains( "Legion Token" ) )
			Bot.Bank.ToInventory( "Legion Token" );
	}
	
	public void CheckQuests() {
		if ( Bot.Quests.CanComplete( 6743 ) )
			Bot.Quests.EnsureComplete( 6743 );
		
		Bot.Quests.EnsureAccept( 6743 );
	}
	
	public void ScriptMain( ScriptInterface bot ){
		Bot = bot;
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		bot.Options.InfiniteRange = true;
		bot.Drops.RejectElse = true;
		
		bot.Drops.Add( "Legion Token" );
		bot.Drops.Start();
		
		bot.Skills.Add( 1, 1 );
		bot.Skills.Add( 2, 1 );
		bot.Skills.Add( 3, 1 );
		bot.Skills.Add( 4, 1 );
		bot.Skills.StartTimer();
		
		CheckItemsRequired();
		
		while ( ! bot.ShouldExit() ) {
			if ( bot.Map.Name != "legionarena" )
				bot.Player.Join( "legionarena" );
			
			CheckQuests();
			
			bot.Player.HuntForItem( "Legion Fiend Rider", "Axeros' Brooch", 1, true, false );
		}
	}
}

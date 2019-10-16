using RBot;

public class Script {
	public ScriptInterface Bot;
	
	public void CheckItemsRequired() {
		if ( Bot.Bank.Contains( "Legion Token" ) )
			Bot.Bank.ToInventory( "Legion Token" );
	}
	
	public void CheckQuests() {
		if ( Bot.Quests.CanComplete( 4849 ) )
			Bot.Quests.EnsureComplete( 4849 );
		
		Bot.Quests.EnsureAccept( 4849 );
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
			if ( bot.Map.Name != "dreadrock" )
				bot.Player.Join( "dreadrock" );
			
			CheckQuests();
			
			bot.Player.HuntForItem( "Fallen Hero|Hollow Wraith|Legion Sentinel|Shadowknight|Void Mercenary", "Dreadrock Enemy Recruited", 6, true, false );
		}
	}
}

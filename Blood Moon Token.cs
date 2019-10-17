using RBot;

public class Script {
	public ScriptInterface Bot;
	public string[] Items;
	
	public void CheckItemsRequired() {
		foreach ( string item in Items ) {
			if ( Bot.Bank.Contains( item ) )
				Bot.Bank.ToInventory( item );
		}
	}
	
	public void CheckQuests() {
		if ( Bot.Quests.CanComplete( 6059 ) )
			Bot.Quests.EnsureComplete( 6059 );
		
		Bot.Quests.EnsureAccept( 6059 );
	}
	
	public void ScriptMain( ScriptInterface bot ){
		Bot = bot;
		Items = new string[] {
			"Black Blood Vial",
			"Moon Stone",
			"Blood Moon Token"
		};
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		bot.Options.ExitCombatBeforeQuest = true;
		bot.Options.InfiniteRange = true;
		bot.Drops.RejectElse = false;
		bot.Drops.Interval = 1500;

		bot.Skills.Add( 1, 1 );
		bot.Skills.Add( 2, 1 );
		bot.Skills.Add( 3, 1 );
		bot.Skills.Add( 4, 1 );
		bot.Skills.StartTimer();
		bot.Drops.Add( "Blood Moon Token" );
		bot.Drops.Start();
		bot.Player.LoadBank();
		CheckItemsRequired();
		CheckQuests();
		
		while ( bot.Inventory.GetQuantity( "Blood Moon Token" ) < 300 ) {
			if ( bot.Map.Name != "bloodmoon" )
				bot.Player.Join( "bloodmoon", "r17", "Bottom" );
				
			bot.Player.HuntForItem( "Black Unicorn", "Black Blood Vial", 1 );
			bot.Player.HuntForItem( "Lycan Guard", "Moon Stone", 1 );
			CheckQuests();
		}
	}
}

using RBot;

public class Script {

	public void ScriptMain( ScriptInterface bot ){
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		bot.Options.ExitCombatBeforeQuest = true;
		bot.Options.InfiniteRange = true;
		
		bot.Drops.Add( "Advanced Weapon Kit" );
		bot.Drops.Start();
		bot.Skills.Add( 1, 1 );
		bot.Skills.Add( 2, 1 );
		bot.Skills.Add( 3, 1 );
		bot.Skills.Add( 4, 1 );
		bot.Skills.StartTimer();
		
		while ( ! bot.ShouldExit() ) {
			bot.Quests.EnsureAccept( 2162 );
			
			if ( ! bot.Inventory.ContainsTempItem( "Superior Blade Oil" ) ) {
				if ( bot.Map.Name != "hachiko" )
					bot.Player.Join( "hachiko" );
				
				bot.Player.HuntForItem( "Dai Tengu", "Superior Blade Oil", 1, true );
				bot.Player.Jump( "Enter", "Spawn" );
				bot.Sleep( 750 );
			}
			if ( ! bot.Inventory.ContainsTempItem( "Leatherwing Hide", 10 ) ) {
				if ( bot.Map.Name != "pines" )
					bot.Player.Join( "pines" );
				
				bot.Player.HuntForItem( "Leatherwing", "Leatherwing Hide", 10, true );
				bot.Player.Jump( "Enter", "Spawn" );
				bot.Sleep( 750 );
			}
			if ( ! bot.Inventory.ContainsTempItem( "Silver Brush" ) ) {
				if ( bot.Map.Name != "lycan" )
					bot.Player.Join( "lycan" );
				
				bot.Player.HuntForItem( "Chaos Vampire Knight|Vampire Knight", "Silver Brush", 1, true );
				bot.Player.Jump( "Enter", "Spawn" );
				bot.Sleep( 750 );
			}
			if ( ! bot.Inventory.ContainsTempItem( "Brass Awl" ) ) {
				if ( bot.Map.Name != "mobius" )
					bot.Player.Join( "mobius" );
				
				bot.Player.HuntForItem( "Cyclops Raider|Cyclops Raider", "Brass Awl", 1, true );
				bot.Player.Jump( "Enter", "Spawn" );
				bot.Sleep( 750 );
			}
			if ( ! bot.Inventory.ContainsTempItem( "Slate Stone Sharpener" ) ) {
				if ( bot.Map.Name != "darkoviaforest" )
					bot.Player.Join( "darkoviaforest" );
				
				bot.Player.HuntForItem( "Lich of The Stone", "Slate Stone Sharpener", 1, true );
				bot.Player.Jump( "Enter", "Spawn" );
				bot.Sleep( 750 );
			}
			if ( ! bot.Inventory.ContainsTempItem( "Shining Lacquer Finish" ) ) {
				if ( bot.Map.Name != "airstorm" )
					bot.Player.Join( "airstorm" );
				
				bot.Player.HuntForItem( "Lightning Ball", "Shining Lacquer Finish", 1, true );
				bot.Player.Jump( "Enter", "Spawn" );
				bot.Sleep( 750 );
			}
			if ( ! bot.Inventory.ContainsTempItem( "Leather Case" ) ) {
				if ( bot.Map.Name != "sandport" )
					bot.Player.Join( "sandport" );
				
				bot.Player.HuntForItem( "Tomb Robber", "Leather Case", 1, true );
				bot.Player.Jump( "Enter", "Spawn" );
				bot.Sleep( 750 );
			}
			if ( ! bot.Inventory.Contains( "WolfClaw Hammer" ) ) {
				if ( bot.Map.Name != "safiria" )
					bot.Player.Join( "safiria" );
				
				bot.Player.HuntForItem( "Chaos Lycan", "WolfClaw Hammer", 1 );
				bot.Player.Jump( "Enter", "Spawn" );
				bot.Sleep( 750 );
			}
			
			if ( bot.Quests.CanComplete( 2162 ) )
				bot.Quests.EnsureComplete( 2162, -1, false, 5 );
		}
	}
}

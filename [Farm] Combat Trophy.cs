using RBot;

public class Script {
	public void ScriptMain( ScriptInterface bot ){
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		bot.Options.InfiniteRange = true;
		bot.Options.PrivateRooms = true;
		
		bot.Drops.Add( "Combat Trophy" );
		bot.Drops.Start();
		
		bot.Skills.Add( 1, 1 );
		bot.Skills.Add( 2, 1 );
		bot.Skills.Add( 3, 1 );
		bot.Skills.Add( 4, 1 );
		bot.Skills.StartTimer();
		
		while ( true ) {
			bot.Player.Join( "battleon" );
			
			bot.Wait.ForMapLoad( "battleon" );
			
			bot.Player.Join( "bludrutbrawl", "Enter0", "Spawn" );
			
			bot.Wait.ForMapLoad( "bludrutbrawl" );
			
			bot.Player.WalkTo( 767, 388 );
			bot.Player.WalkTo( 823, 258 );
			
			bot.SendPacket( "%xt%zm%mtcid%64980%5%" );
			bot.SendPacket( "%xt%zm%mtcid%64980%5%" );
			
			bot.Wait.ForCellChange( "Morale0C" );
			
			bot.Sleep( 1000 );
			
			bot.Player.WalkTo( 672, 413 );
			bot.Player.WalkTo( 844, 254 );
			
			bot.SendPacket( "%xt%zm%mtcid%64980%4%" );
			bot.SendPacket( "%xt%zm%mtcid%64980%4%" );
			
			bot.Wait.ForCellChange( "Morale0B" );
			
			bot.Sleep( 1000 );
			
			bot.Player.WalkTo( 767, 388 );
			bot.Player.WalkTo( 823, 258 );
			
			bot.SendPacket( "%xt%zm%mtcid%64980%7%" );
			bot.SendPacket( "%xt%zm%mtcid%64980%7%" );
			
			bot.Wait.ForCellChange( "Morale0A" );
			
			bot.Sleep( 1000 );
			
			bot.Player.WalkTo( 672, 413 );
			bot.Player.WalkTo( 844, 254 );
			
			bot.SendPacket( "%xt%zm%mtcid%64980%9%" );
			bot.SendPacket( "%xt%zm%mtcid%64980%9%" );
			
			bot.Wait.ForCellChange( "Crosslower" );
			
			bot.Sleep( 1000 );
			
			bot.Player.WalkTo( 495, 378 );
			bot.Player.WalkTo( 490, 257 );
			
			bot.SendPacket( "%xt%zm%mtcid%64980%14%" );
			bot.SendPacket( "%xt%zm%mtcid%64980%14%" );
			
			bot.Wait.ForCellChange( "Crossupper" );
			
			bot.Sleep( 1000 );
			
			bot.Player.WalkTo( 624, 305 );
			bot.Player.WalkTo( 852, 276 );
			
			bot.SendPacket( "%xt%zm%mtcid%64980%18%" );
			bot.SendPacket( "%xt%zm%mtcid%64980%18%" );
			
			bot.Wait.ForCellChange( "Resource1A" );
			
			bot.Sleep( 1000 );
			
			bot.Player.Kill( "Team B Restorer" );
			bot.Player.Kill( "Team B Restorer" );
			
			bot.Sleep( 2000 );
			
			bot.Player.WalkTo( 695, 355 );
			bot.Player.WalkTo( 835, 258 );
			
			bot.SendPacket( "%xt%zm%mtcid%64980%20%" );
			bot.SendPacket( "%xt%zm%mtcid%64980%20%" );
			
			bot.Wait.ForCellChange( "Resource1B" );
			
			bot.Sleep( 1000 );
			
			bot.Player.Kill( "Team B Restorer" );
			bot.Player.Kill( "Team B Restorer" );
			
			bot.Sleep( 3000 );
			
			bot.Player.WalkTo( 679, 448 );
			bot.Player.WalkTo( 176, 356 );
			bot.Player.WalkTo( 137, 255 );
			
			bot.SendPacket( "%xt%zm%mtcid%65086%21%" );
			bot.SendPacket( "%xt%zm%mtcid%65086%21%" );
			
			bot.Wait.ForCellChange( "Resource1A" );
			
			bot.Sleep( 1000 );
			
			bot.Player.WalkTo( 232, 347 );
			bot.Player.WalkTo( 131, 257 );
			
			bot.SendPacket( "%xt%zm%mtcid%65086%19%" );
			bot.SendPacket( "%xt%zm%mtcid%65086%19%" );
			
			bot.Wait.ForCellChange( "Crossupper" );
			
			bot.Sleep( 1000 );
			
			bot.Player.WalkTo( 488, 364 );
			bot.Player.WalkTo( 485, 476 );
			
			bot.SendPacket( "%xt%zm%mtcid%65086%17%" );
			bot.SendPacket( "%xt%zm%mtcid%65086%17%" );
			
			bot.Wait.ForCellChange( "Crosslower" );
			
			bot.Player.WalkTo( 769, 411 );
			bot.Player.WalkTo( 839, 254 );
			
			bot.SendPacket( "%xt%zm%mtcid%65086%15%" );
			bot.SendPacket( "%xt%zm%mtcid%65086%15%" );
			
			bot.Wait.ForCellChange( "Morale1A" );
			
			bot.Sleep( 1000 );
			
			bot.Player.Kill( "Team B Brawler");
			
			bot.Sleep( 2000 );
			
			bot.Player.WalkTo( 666, 281 );
			bot.Player.WalkTo( 851, 255 );
			
			bot.SendPacket( "%xt%zm%mtcid%65086%23%" );
			bot.SendPacket( "%xt%zm%mtcid%65086%23%" );
			
			bot.Wait.ForCellChange( "Morale1B" );
			
			bot.Sleep( 1000 );
			
			bot.Player.Kill( "Team B Brawler" );
			
			bot.Sleep( 2000 );
			
			bot.Player.WalkTo( 561, 376 );
			bot.Player.WalkTo( 837, 255 );
			
			bot.SendPacket( "%xt%zm%mtcid%65599%25%" );
			bot.SendPacket( "%xt%zm%mtcid%65599%25%" );
			
			bot.Wait.ForCellChange( "Morale1C" );
			
			bot.Sleep( 1000 );
			
			bot.Player.Kill( "Team B Brawler" );
			
			bot.Sleep( 2000 );
			
			bot.Player.WalkTo( 468, 380 );
			bot.Player.WalkTo( 478, 261 );
			
			bot.SendPacket( "%xt%zm%mtcid%66338%28%" );
			bot.SendPacket( "%xt%zm%mtcid%66338%28%" );
			
			bot.Wait.ForCellChange( "Captain1" );
			
			bot.Sleep( 1000 );
			
			bot.Player.Kill( "Team B Captain" );
			
			bot.Sleep( 5000 );
			
			bot.Wait.ForDrop( "Combat Trophy" );
			
			bot.Wait.ForPickup( "Combat Trophy" );
		}
	}
}

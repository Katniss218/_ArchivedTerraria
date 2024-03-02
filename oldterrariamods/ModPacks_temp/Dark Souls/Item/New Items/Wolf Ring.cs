public static void Effects(Player player) 
{

      player.AddBuff("Firesoul", 60, false);   
      player.spawnMax = true;
      
for(int num39 = 0; num39 < 10; num39++)
	{
		if (player.buffType[num39] == 36) //36 is broken armor
		{
		player.buffType[num39] = 0;
		player.buffTime[num39] = 0;
		
		break;
		}
	}
	
	  for(int num38 = 0; num38 < 10; num38++)
	{
		if (player.buffType[num38] == 24) //24 is on fire
		{
		player.buffType[num38] = 0;
		player.buffTime[num38] = 0;
		
		break;
		}
	}


	for(int num36 = 0; num36 < 10; num36++)
	{
		if (player.buffType[num36] == 30) //30 is bleeding
		{
		player.buffType[num36] = 0;
		player.buffTime[num36] = 0;
		
		break;
		}
	}
      

      if(Main.bloodMoon)
	{
	player.statDefense += 23;
	}
	else
	{
	player.statDefense += 16;
	}

}
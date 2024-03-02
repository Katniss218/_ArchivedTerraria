
public static void UseItem(Player player, int playerID)
{

player.AddBuff(2, 7200, false);   

for(int num36 = 0; num36 < 10; num36++)
	{
		if (player.buffType[num36] == 20)
		{
		player.buffType[num36] = 0;
		player.buffTime[num36] = 0;
		
		break;
		}
	}

for(int num37 = 0; num37 < 10; num37++)
	{
		if (player.buffType[num37] == 30)
		{
		player.buffType[num37] = 0;
		player.buffTime[num37] = 0;
		
		break;
		}
	}


for(int num31 = 0; num31 < 10; num31++)
	{
		if (player.buffType[num31] == 31)
		{
		player.buffType[num31] = 0;
		player.buffTime[num31] = 0;
		
		break;
		}
	}


for(int num38 = 0; num38 < 10; num38++)
	{
		if (player.buffType[num38] == 36)
		{
		player.buffType[num38] = 0;
		player.buffTime[num38] = 3600;
		
		break;
		}
	}

}


public static void Effects(Player player) 
{
    player.AddBuff(2, 7200, false);
}


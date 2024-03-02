
public static void UseItem(Player player, int playerID)
{
   

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

}
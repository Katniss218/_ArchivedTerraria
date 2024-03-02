public void UpdatePlayer (Player player)
	{
	if (!player.lavaWet)
		{
		player.accFlipper = true;
		player.breath = player.breathMax;
		}
	if (player.wet)
		{
		player.gills = true;
		}
	}
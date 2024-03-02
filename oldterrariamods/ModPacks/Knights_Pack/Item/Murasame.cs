public void FrameEffect (Player player)
	{
	float light = Lighting.Brightness((int)(player.position.X + player.width / 2) / 16, (int)(player.position.Y + player.height / 5) / 16);
	if (light >= 0.6f && light < 1f)
		{
		player.AddBuff("Photosynthesis", 1);
		}
	else
		{
		if (light >= 1f)
			{
			player.AddBuff("Imerasynthesis", 1);
			}
		}
	}
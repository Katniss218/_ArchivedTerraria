public int timer = 0;
public void Effects(Player P, int buffIndex, int buffType, int buffTime)
{
	int sw = (int)(Main.screenWidth);
	int sh = (int)(Main.screenHeight);
	int sx = (int)(Main.screenPosition.X);
	int sy = (int)(Main.screenPosition.Y);
	for (int x = sx; x < sx + sw; x++)
	{
		for (int y = sy; y < sy + sh; y++)
		{
			if (!Main.tile[(int)(x / 16), (int)(y / 16)].active)
			{
				if (y > (int)Main.rockLayer)
				{
					timer++;
					if (timer % 180 == 0)
					{
						Lighting.addLight((int)(x / 16), (int)(y / 16), 0.7f, 0.7f, 0.7f);
						timer = 0;
					}
				}
			}
		}
	}
	P.findTreasure = true;
	P.detectCreature = true;
}

public void UseItemEffect(Player player) 
{
    Lighting.addLight((int)((player.itemLocation.X + 6f + player.velocity.X) / 16f), (int)((player.itemLocation.Y - 14f) / 16f), 0.0f, 0.5f, 0.5f);
}

public Color GetAlpha(Color newColor)
{
	float num = (float)(255 - item.alpha) / 255f;
	int r = (int)((float)newColor.R * num);
	int g = (int)((float)newColor.G * num);
	int b = (int)((float)newColor.B * num);
	int num2 = (int)newColor.A - item.alpha;
	if (num2 < 0)
	{
		num2 = 0;
	}
	if (num2 > 255)
	{
		num2 = 255;
	}
    return Color.White;
	return new Color(r, g, b, num2);
}

public Color GetColor(Color newColor)
{
	int num = (int)(item.color.R - (255 - newColor.R));
	int num2 = (int)(item.color.G - (255 - newColor.G));
	int num3 = (int)(item.color.B - (255 - newColor.B));
	int num4 = (int)(item.color.A - (255 - newColor.A));
	if (num < 0)
	{
		num = 0;
	}
	if (num > 255)
	{
		num = 255;
	}
	if (num2 < 0)
	{
		num2 = 0;
	}
	if (num2 > 255)
	{
		num2 = 255;
	}
	if (num3 < 0)
	{
		num3 = 0;
	}
	if (num3 > 255)
	{
		num3 = 255;
	}
	if (num4 < 0)
	{
		num4 = 0;
	}
	if (num4 > 255)
	{
		num4 = 255;
	}
	return new Color(num, num2, num3, num4);
}
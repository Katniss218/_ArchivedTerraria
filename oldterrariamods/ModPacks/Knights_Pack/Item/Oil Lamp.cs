public bool HeldItemEffects(Player player)
	{
	if (!player.wet)
		{
		Lighting.addLight((int)player.Center.X/16,(int)player.Center.Y/16,1f,0.95f,0.8f);
		player.itemLocation.Y = player.Center.Y + 12f;
		player.itemLocation.X = player.itemLocation.X - (float)(player.direction * 6f);
		return true;
		}
	else
		{
		return false;
		}
	}


public void UpdateItem(int itemIndex, ref bool LetUpdate,ref int MovementType,ref int LavaImmunity)
	{
	Lighting.addLight((int)((Main.item[itemIndex].position.X + (float)(Main.item[itemIndex].width/2))/16), (int)((Main.item[itemIndex].position.Y + (float)(Main.item[itemIndex].height/2))/16), 1f, 0.95f, 0.8f);
	}
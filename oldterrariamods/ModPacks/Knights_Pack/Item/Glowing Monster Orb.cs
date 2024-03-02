public void UpdateItem(int itemIndex, ref bool LetUpdate,ref int MovementType,ref int LavaImmunity)
	{
	Lighting.addLight((int)((Main.item[itemIndex].position.X + (float)(Main.item[itemIndex].width/2))/16), (int)((Main.item[itemIndex].position.Y + (float)(Main.item[itemIndex].height/2))/16), 0.2f, 0f, 0.15f);
	}
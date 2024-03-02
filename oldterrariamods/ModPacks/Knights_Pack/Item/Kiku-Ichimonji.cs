public bool HeldItemEffects(Player player)
	{
	Lighting.addLight((int)player.Center.X/16,(int)player.Center.Y/16, 1f, 0.6f, 0.8f);
	player.detectCreature = true;
	player.itemLocation.Y = player.Center.Y + 8f;
	player.itemLocation.X = player.itemLocation.X - (float)(player.direction * 15f);
	return true;
	}

public void UseItemEffect(Player player, Rectangle rectangle)
	{
	player.itemLocation.Y = player.Center.Y;
	if (player.direction == 1)
		{
		player.itemLocation.X = player.position.X + player.width;
		}
	else
		{
		player.itemLocation.X = player.position.X;
		}
	}

public void UpdateItem(int itemIndex, ref bool LetUpdate,ref int MovementType,ref int LavaImmunity)
	{
	Lighting.addLight((int)((Main.item[itemIndex].position.X + (float)(Main.item[itemIndex].width/2))/16), (int)((Main.item[itemIndex].position.Y + (float)(Main.item[itemIndex].height/2))/16), 1f, 0.6f, 0.8f);
	}

public void DamageNPC (Player myPlayer, NPC npc, ref int damage, ref float knockback)
	{
	if (npc.type != 1 && npc.type != 10 && npc.type != 11 && npc.type != 12 && npc.type != 16 && npc.type != 22 && npc.type != 26 && npc.type != 27 && npc.type != 28 && npc.type != 29 && npc.type != 42 && npc.type != 43 && npc.type != 46 && npc.type != 48 && npc.type != 49 && npc.type != 50 && npc.type != 51 && npc.type != 55 && npc.type != 56 && npc.type != 58 && npc.type != 61 && npc.type != 63 && npc.type != 64 && npc.type != 65 && npc.type != 67 && npc.type != 69 && npc.type != 74 && npc.type != 75 && npc.type != 80 && npc.type != 84 && npc.type != 86 && npc.type != 93 && npc.type != 95 && npc.type != 96 && npc.type != 97 && npc.type != 102 && npc.type != 103 && npc.type != 111 && npc.type != 120 && npc.type != 122 && npc.type != 137 && npc.type != 138 && npc.type != 141)
		{
		if (Main.rand.Next(3) == 0)
			{
			npc.AddBuff ("Sacred Fire", 840);
			}
		}
	}

// Creatures immune to sacred fire:
// * Natural slimes.
// * Humanoids, including goblins and the Guide (as he is the only NPC that can be harmed).
// * Natural enemies like bats, non-corrupt fish and bunnies, man-eating plants, jellyfish, etc.
// * All hallow enemies.
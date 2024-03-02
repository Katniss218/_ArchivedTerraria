
public void ModifyPlayerDrawColors(Player player,ref bool OF,ref float r,ref float g,ref float b,ref float a)
	{
	r *= 0.8f;
	g *= 0.9f;
	b *= 1f;
	}

public static void Effects (Player player)
	{
	player.moveSpeed *= 0.5f;
	if (Main.rand.Next(10)==0)
		{
		int dust = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, 76, player.velocity.X, 0, 100, new Color(), 1.2f);
		Main.dust[dust].noGravity = false;
		}
	}

public static void NPCEffects (NPC npc)
	{
	npc.velocity.X *= 0.5f;
	if (Main.rand.Next(10)==0)
		{
		int dust = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 76, npc.velocity.X, 0, 100, new Color(), 1.2f);
		Main.dust[dust].noGravity = false;
		}
	}
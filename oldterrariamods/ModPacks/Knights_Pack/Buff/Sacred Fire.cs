
public static void Effects (Player player)
	{
	player.lifeRegen = -3;
	if (Main.rand.Next(3)==0)
		{
		int dust = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, 71, player.velocity.X, -4f, 100, new Color(), 1.2f);
		Main.dust[dust].noGravity = true;
		}
	}

public static void NPCEffects (NPC npc)
	{
	npc.lifeRegen = -3;
	if (Main.rand.Next(3)==0)
		{
		int dust = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 71, npc.velocity.X, -4f, 100, new Color(), 1.2f);
		Main.dust[dust].noGravity = true;
		}
	}
public void Effects(Player player)
{
	int i2 = (int)(player.position.X + (float)(player.width / 2) + (float)(8 * player.direction)) / 16;
	int j2 = (int)(player.position.Y + 2f) / 16;
	Lighting.addLight(i2,j2,3,3,3);
	player.pStone = true;
	player.longInvince = true;
	player.findTreasure = true;
	player.detectCreature = true;
}

public void DealtPlayer(Player P,double DMG,NPC N)
{
	P.immuneTime += 40;
}
public void DamageNPC(Player player, NPC npc, ref int damage, ref float knockback)
{
	if (player.head == Config.itemDefs.byName["Berserker Headpiece"].headSlot && player.body == Config.itemDefs.byName["Berserker Bodyarmor"].bodySlot && player.legs == Config.itemDefs.byName["Berserker Cuisses"].legSlot)
	{
		if (Main.rand.Next(18) == 0)
		{
			npc.AddBuff("Oblivion", 120);
		}
	}
}
public void SetBonus(Player player)
{
	player.setBonus = "Weapons inflict the Oblivion debuff";
	player.ShadowTail = true;
	player.ShadowAura = true;
	if (player.controlRight)
	{
		int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width-20, player.height, 65, 0, 0, 100, Color.White, 2f);
        	Main.dust[dust].noGravity = true;
		Main.dust[dust].OverrideTexture = Main.goreTexture[Config.goreID["Berserker Dust"]]; //Custom Dust
		Main.dust[dust].frame = new Rectangle(0,0,10,10);//(frametopleftcornerx,frametopleftcornery,framewidth,frameheight)
	}
	if (player.controlLeft)
	{
		int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width+20, player.height, 65, 0, 0, 100, Color.White, 2f);
	        Main.dust[dust].noGravity = true;
		Main.dust[dust].OverrideTexture = Main.goreTexture[Config.goreID["Berserker Dust"]]; //Custom Dust
		Main.dust[dust].frame = new Rectangle(0,0,10,10);//(frametopleftcornerx,frametopleftcornery,framewidth,frameheight)
	}
	if (player.controlJump)
	{
		int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width+20, player.height+20, 65, 0, 0, 100, Color.White, 2f);
	        Main.dust[dust].noGravity = true;
		Main.dust[dust].OverrideTexture = Main.goreTexture[Config.goreID["Berserker Dust"]]; //Custom Dust
		Main.dust[dust].frame = new Rectangle(0,0,10,10);//(frametopleftcornerx,frametopleftcornery,framewidth,frameheight)
	}
}
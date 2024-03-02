public void SetBonus(Player player)
{
	player.setBonus = "Triggers a flaming explosion when attacked by an enemy.";
}


public void DealtPlayer(Player player, double damage, NPC npc)
{
if (player.armor[0].type == Config.itemDefs.byName["Phoenix Helmet"].type && player.armor[1].type == Config.itemDefs.byName["Phoenix Armor"].type && player.armor[2].type == Config.itemDefs.byName["Phoenix Greaves"].type && !player.wet)
{
for (int i=0; i < 30; i++)
{
	int dust = Dust.NewDust(new Vector2((float) player.position.X-60, (float) player.position.Y-60), player.width+120, player.height+120, 6, Main.rand.Next(-20,20)/10, Main.rand.Next(-20,20)/10, 5, Color.White, 6f);
	//Main.dust[dust].noGravity = true;
}
foreach (NPC npc2 in Main.npc)
{
if (!npc2.friendly && !npc2.dontTakeDamage)
{
Vector2 npcposition = new Vector2(npc2.position.X+(npc2.width/2),npc2.position.Y+(npc2.height/2));
Vector2 playerposition = new Vector2(player.position.X+(player.width/2),player.position.Y+(player.height/2));
if (npcposition.X >= playerposition.X-76 && npcposition.X <= playerposition.X+76 && npcposition.Y >= playerposition.Y-84 && npcposition.Y <= playerposition.Y+84)
{
npc2.AddBuff(24, 180, false);
if (npcposition.X > playerposition.X) npc2.StrikeNPC(10, 6, 1);
else npc2.StrikeNPC(10, 6, -1);
}
}
}
}
}

public void PlayerFrame(Player player)
{
	if (player.legs == Config.itemDefs.byName["Phoenix Greaves"].legSlot && player.body == Config.itemDefs.byName["Phoenix Armor"].bodySlot && player.head == Config.itemDefs.byName["Phoenix Helmet"].headSlot && Main.rand.Next(3)==0)
	{
	Color color = new Color();
	int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width, player.height, 6, Main.rand.Next(-5,5), Main.rand.Next(-5,5), 200, color, 4.0f);
	Main.dust[dust].noGravity = true;
	Main.dust[dust].noLight = true;
	}
}
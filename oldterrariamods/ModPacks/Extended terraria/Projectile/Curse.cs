public void AI()
{
	Projectile P = projectile;
	P.ai[0]++;
	Rectangle proj = new Rectangle((int)P.Center.X - 100, (int)P.Center.Y - 100, 200, 200);
	if (P.ai[0] == 1 || P.ai[0] == 50)
	{
		foreach (NPC N in Main.npc)
		{
			if (!N.active || N.dontTakeDamage || N.friendly || N.life < 1) continue;
			Rectangle npc = ModGeneric.NewRect(N);
			if (proj.Intersects(npc))
			{
				N.StrikeNPC((int)(Main.player[P.owner].inventory[Main.player[P.owner].selectedItem].damage * Main.player[P.owner].magicDamage), 0f, (N.Center.X < P.Center.X ? -1 : 1));
			}
			break;
		}
	}
}
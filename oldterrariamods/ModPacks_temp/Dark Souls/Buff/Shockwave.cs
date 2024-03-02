private int fallStart_old = -1;

public void Effects(Player P, int buffIndex, int buffType, int buffTime)
{
	if (Main.rand.Next(50) == 0)
	{
		int D = Dust.NewDust(P.position, P.width, P.height, 9, (P.velocity.X * 0.2f) + (P.direction * 3), P.velocity.Y * 1.2f, 60, new Color(), 1f);
		Main.dust[D].noGravity = true;
		Main.dust[D].velocity.X *= 1.2f;
		Main.dust[D].velocity.X *= 1.2f;
	}
	if (Main.rand.Next(50) == 0)
	{
		int D2 = Dust.NewDust(P.position, P.width, P.height, 9, (P.velocity.X * 0.2f) + (P.direction * 3), P.velocity.Y * 1.2f, 60, new Color(), 1f);
		Main.dust[D2].noGravity = true;
		Main.dust[D2].velocity.X *= -1.2f;
		Main.dust[D2].velocity.X *= 1.2f;
	}
	if (Main.rand.Next(50) == 0)
	{
		int D3 = Dust.NewDust(P.position, P.width, P.height, 9, (P.velocity.X * 0.2f) + (P.direction * 3), P.velocity.Y * 1.2f, 60, new Color(), 1f);
		Main.dust[D3].noGravity = true;
		Main.dust[D3].velocity.X *= 1.2f;
		Main.dust[D3].velocity.X *= -1.2f;
	}
	if (Main.rand.Next(50) == 0)
	{
		int D4 = Dust.NewDust(P.position, P.width, P.height, 9, (P.velocity.X * 0.2f) + (P.direction * 3), P.velocity.Y * 1.2f, 60, new Color(), 1f);
		Main.dust[D4].noGravity = true;
		Main.dust[D4].velocity.X *= -1.2f;
		Main.dust[D4].velocity.X *= -1.2f;
	}
	int sw = (int)(Main.screenWidth);
	int sh = (int)(Main.screenHeight);
	int sx = (int)(Main.screenPosition.X);
	int sy = (int)(Main.screenPosition.Y);
	//bool wings = false;
	//if (ModPlayer.HasItemInArmor(492) || ModPlayer.HasItemInArmor(493) || ModPlayer.HasItemInExtraSlots(492) || ModPlayer.HasItemInExtraSlots(493))
	//{
	//	wings = true;
	//}
	if (fallStart_old == -1) fallStart_old = P.fallStart;
	int fall_dist = 0;
	if (P.velocity.Y == 0f) // && !wings) // detect landing from a fall
		fall_dist = (int)((float)((int)(P.position.Y / 16f) - fallStart_old) * P.gravDir);
	Vector2 p_pos = P.position+new Vector2(P.width,P.height)/2f;

	if (fall_dist > 3) // just fell
	{
		for (int k = 0; k < Main.npc.Length; k++)
		{ // iterate through NPCs
			NPC N = Main.npc[k];
			if (!N.active || N.dontTakeDamage || N.friendly || N.life < 1) continue;
			Vector2 n_pos = new Vector2(N.position.X + (float)N.width * 0.5f, N.position.Y + (float)N.height * 0.5f); // NPC location
			int HitDir = -1;
			if (n_pos.X > p_pos.X) HitDir = 1;
			if ((N.position.X >= sx) && (N.position.X <= sx+sw) && (N.position.Y >= sy) && (N.position.Y <= sy+sh))
			{ // on screen
				N.StrikeNPC(2*fall_dist, 5f, HitDir);
				if(Main.netMode!=0) NetMessage.SendData(28,-1,-1,"",k,2*fall_dist,10f,HitDir,0); // for multiplayer support
				// optionally add debuff here
			} // END on screen
		} // END iterate through NPCs
	} // END just fell
	fallStart_old=P.fallStart;
}

public void ModifyPlayerDrawColors(Player P, bool OverrideFire, ref float r, ref float g, ref float b, ref float a)
{
	OverrideFire = true;
	r *= 0.7372f;
	g *= 0.5176f;
	b *= 0.3686f;
}
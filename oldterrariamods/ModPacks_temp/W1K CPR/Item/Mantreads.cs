public static int timerNextHit = 0;

public static void Effects(Player player)
{
	bool Detected = false;
	if (timerNextHit > 0) timerNextHit--;
	if (player.velocity.Y < 2f && player.gravDir == 1) player.fallStart = (int) (player.position.Y / 16f);
	if (player.velocity.Y > -2f && player.gravDir == -1) player.fallStart = (int) (player.position.Y / 16f);
	//Main.NewText(""+((int)(player.position.Y / 16f) - player.fallStart));
	if (!ModPlayer.DragonMorph)
	{
		foreach(NPC npc in Main.npc)
		{
			if (npc.active && player.gravDir == 1f && !npc.friendly && player.Left.X < npc.Right.X && player.Right.X > npc.Left.X && player.Bottom.Y > npc.Top.Y-20f && player.Bottom.Y < npc.Top.Y) Detected = true;
			if (npc.active && player.gravDir == -1f && !npc.friendly && player.Left.X < npc.Right.X && player.Right.X > npc.Left.X && player.Top.Y < npc.Bottom.Y+20f && player.Top.Y > npc.Bottom.Y) Detected = true;
			if (Detected)
			{
				int num21 = (int)(player.position.Y / 16f) - player.fallStart;
				player.velocity.Y = (npc.velocity.Y/2f)-(10*player.gravDir);
				num21 = (int)((float)num21 * player.gravDir);
				if (!player.noFallDmg && player.wings == 0) num21 = num21*2;
				if (num21 > 200) num21 = 200;
				if ((player.noFallDmg || player.wings != 0) && num21 > 100) num21 = 100;
				if (timerNextHit <= 0)
				{
					npc.StrikeNPC(num21, 0, 0);
					timerNextHit = 5;
				}
				player.fallStart = (int) (player.position.Y / 16f);
				break;
			}
		}
	}
}
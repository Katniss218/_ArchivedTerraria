#region debuff
public void DamagePlayer(Player player, ref int damage) //hook works!
{
	if (Main.rand.Next(2) == 0)
	{
				player.AddBuff(30, 1800, false); //bleeding
                player.AddBuff(24, 600, false); //on fire
				
    }
}
#endregion

public void AI()
{
	npc.AI(true);

}
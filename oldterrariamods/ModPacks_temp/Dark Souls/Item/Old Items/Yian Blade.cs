public void DamageNPC(Player myPlayer,NPC npc, ref int damage, ref float knockback){
if(Main.rand.Next(18)==0){
myPlayer.HealEffect(damage/2); 
myPlayer.statLife+=(damage/2);
}
}

public static void UseItemEffect(Player player, Rectangle rectangle) {
    Color color = new Color();
    int dust = Dust.NewDust(new Vector2((float) rectangle.X, (float) rectangle.Y), rectangle.Width, rectangle.Height, 15, (player.velocity.X * 0.2f) + (player.direction * 2), player.velocity.Y * 0.2f, 100, color, 1f);
    Main.dust[dust].noGravity = false;
}

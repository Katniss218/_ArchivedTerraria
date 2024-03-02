public void UseItemEffect(Player player, Rectangle rectangle) {
Color color = new Color();
	//This is the same general effect done with the Fiery Greatsword
	int dust = Dust.NewDust(new Vector2((float) rectangle.X, (float) rectangle.Y), rectangle.Width, rectangle.Height, 24, (player.velocity.X * 0.2f) + (player.direction * 3), player.velocity.Y * 0.2f, 100, color, 1.9f);
	Main.dust[dust].noGravity = true;
 if(Main.rand.Next(10)==0){
  player.Hurt(Main.rand.Next(6,10),0,false,false," has turned into a dead body");

}
}

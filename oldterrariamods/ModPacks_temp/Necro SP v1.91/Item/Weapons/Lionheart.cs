public static void UseItemEffect(Player player, Rectangle rectangle) {
    Color color = new Color();
    int dust = Dust.NewDust(new Vector2((float) rectangle.X, (float) rectangle.Y), rectangle.Width, rectangle.Height, 59, (player.velocity.X * 0.2f) + (player.direction * 3), player.velocity.Y * 0.2f, 100, color, 1.8f);
    Main.dust[dust].noGravity = true;
}


public void UseItem(Player player, int playerID) {
        {
        {
        {

                    int spread = 30;
             
                    float num48 = 14f;
                    float speedX = ((Main.mouseX + Main.screenPosition.X) - (player.position.X + 

                    player.width * 0.5f))+Main.rand.Next(-spread, spread);
                    float speedY = ((Main.mouseY + Main.screenPosition.Y) - (player.position.Y + 

                    player.height * 0.5f))+Main.rand.Next(-spread, spread);
		            float speedX1 = ((Main.mouseX + Main.screenPosition.X) - (player.position.X + 

                    player.width * 0.5f))+Main.rand.Next(-spread, spread);
                    float speedY1 = ((Main.mouseY + Main.screenPosition.Y) - (player.position.Y + 

                    player.height * 0.5f))+Main.rand.Next(-spread, spread);
		            float speedX2 = ((Main.mouseX + Main.screenPosition.X) - (player.position.X + 

                    player.width * 0.5f))+Main.rand.Next(-spread, spread);
                    float speedY2 = ((Main.mouseY + Main.screenPosition.Y) - (player.position.Y + 

                    player.height * 0.5f))+Main.rand.Next(-spread, spread);
		            float speedX3 = ((Main.mouseX + Main.screenPosition.X) - (player.position.X + 

                    player.width * 0.5f))+Main.rand.Next(-spread, spread);
                    float speedY3 = ((Main.mouseY + Main.screenPosition.Y) - (player.position.Y + 

                    player.height * 0.5f))+Main.rand.Next(-spread, spread);
                    float num51 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
                    num51 = num48 / num51;
                    speedX *= num51;
                    speedY *= num51;
                    speedX1 *= num51;
                    speedY1 *= num51;
                    speedX2 *= num51;
                    speedY2 *= num51;
                    speedX3 *= num51;
                    speedY3 *= num51;
             
                    if ((player.direction == -1) && ((Main.mouseX + Main.screenPosition.X) > 

                    (player.position.X + player.width * 0.5f)))
                    {
                            player.direction = 1;
                    }
                    if ((player.direction == 1) && ((Main.mouseX + Main.screenPosition.X) < 

                    (player.position.X + player.width * 0.5f)))
                    {
                            player.direction = -1;
                    }
             
                    if (player.direction == 1) player.itemRotation = (float) Math.Atan2((Main.mouseY + 

                    Main.screenPosition.Y)-(player.position.Y + player.height * 0.5f),
     
                    (Main.mouseX + Main.screenPosition.X) - (player.position.X + player.width * 0.5f));
                    else player.itemRotation = (float) Math.Atan2((player.position.Y + player.height * 

                    0.5f)-(Main.mouseY + Main.screenPosition.Y),(player.position.X +
     
                    player.width * 0.5f)-(Main.mouseX + Main.screenPosition.X));   
                   
             
	

	                Projectile.NewProjectile(
                    (float) player.position.X + (player.width * 0.5f),
                    (float) player.position.Y + (player.height * 0.5f),
                    (float) speedX2,
                    (float) speedY2,
                    "Gun Blade Bullet",
                    (int) (item.damage*player.magicDamage),
                    player.inventory[player.selectedItem].knockBack,
                    playerID
                    );
    }
}
}
}
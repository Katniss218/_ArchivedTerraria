public void AI()
{
    projectile.direction = Main.player[projectile.owner].direction;
    Main.player[projectile.owner].heldProj = projectile.whoAmI;
    Main.player[projectile.owner].itemTime = Main.player[projectile.owner].itemAnimation;
    projectile.position.X = Main.player[projectile.owner].position.X + (float)(Main.player[projectile.owner].width / 2) - (float)(projectile.width / 2);
    projectile.position.Y = Main.player[projectile.owner].position.Y + (float)(Main.player[projectile.owner].height / 2) - (float)(projectile.height / 2);
    if (projectile.ai[0] == 0f) //use item
    {
        projectile.ai[0] = 3f;
        projectile.netUpdate = true;
    }
    if (Main.player[projectile.owner].itemAnimation < Main.player[projectile.owner].itemAnimationMax / 3)
    {
        projectile.ai[0] -= 1.25f; //go away from player
    }
    else
    {
        projectile.ai[0] += 0.95f; //get back
    }
    projectile.position += projectile.velocity * projectile.ai[0];
    if (Main.player[projectile.owner].itemAnimation == 0)
    {
        projectile.Kill(); //kill
    }
    projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 2.355f;
    if (projectile.spriteDirection == -1)
    {
        projectile.rotation -= 1.57f;
    }
    Color newColor;
    if (Main.rand.Next(5) == 0)
    {
        int arg_54B5_3 = 15; //dust type 1
        newColor = default(Color);
        Dust.NewDust(projectile.position, projectile.width, projectile.height, arg_54B5_3, 0f, 0f, 150, newColor, 1.4f);
    }
    int arg_550C_3 = 15; //dust type 2
    newColor = default(Color);
    int num116 = Dust.NewDust(projectile.position, projectile.width, projectile.height, arg_550C_3, projectile.velocity.X * 0.2f + (float)(projectile.direction * 3), projectile.velocity.Y * 0.2f, 100, newColor, 1.2f);
    Main.dust[num116].noGravity = true;
    Dust expr_552E_cp_0 = Main.dust[num116];
    expr_552E_cp_0.velocity.X = expr_552E_cp_0.velocity.X / 2f;
    Dust expr_554C_cp_0 = Main.dust[num116];
    expr_554C_cp_0.velocity.Y = expr_554C_cp_0.velocity.Y / 2f;
    int arg_55A4_3 = 15; //dust type 3
    newColor = default(Color);
    num116 = Dust.NewDust(projectile.position - projectile.velocity * 2f, projectile.width, projectile.height, arg_55A4_3, 0f, 0f, 150, newColor, 1.4f);
    Dust expr_55B8_cp_0 = Main.dust[num116];
    expr_55B8_cp_0.velocity.X = expr_55B8_cp_0.velocity.X / 5f;
    Dust expr_55D6_cp_0 = Main.dust[num116];
    expr_55D6_cp_0.velocity.Y = expr_55D6_cp_0.velocity.Y / 5f;
    return;
}
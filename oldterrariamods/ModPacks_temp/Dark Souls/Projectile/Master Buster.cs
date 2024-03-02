

public void AI() {

this.projectile.alpha = 0;


if (Main.rand.Next(5) < 1) {
int dust = Dust.NewDust(this.projectile.position, 64, 0, 45, Main.rand.Next(10)-5, Main.rand.Next(10)-5, 255, Color.White, 10.0f);
Main.dust[dust].noGravity = true;
Main.dust[dust].rotation = this.projectile.rotation; 
}



}

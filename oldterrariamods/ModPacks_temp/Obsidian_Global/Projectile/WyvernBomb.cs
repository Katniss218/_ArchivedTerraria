public void Kill(){
int style = Config.projDefs.byName["WyvernBone"].type;
int dmg = Main.rand.Next(15)+5;

if (Main.netMode != 2){
   Projectile.NewProjectile(this.projectile.position.X, this.projectile.position.Y, 5, -Main.rand.Next(10)-5, style, dmg, 0, Main.myPlayer)  ;
   Projectile.NewProjectile(this.projectile.position.X, this.projectile.position.Y, 5, -Main.rand.Next(10)-5, style, dmg, 0, Main.myPlayer)   ;  
   Projectile.NewProjectile(this.projectile.position.X, this.projectile.position.Y, 5, -Main.rand.Next(10)-5, style, dmg, 0, Main.myPlayer)   ; 
   Projectile.NewProjectile(this.projectile.position.X, this.projectile.position.Y, 5, -Main.rand.Next(10)-5, style, dmg, 0, Main.myPlayer)   ;  
   Projectile.NewProjectile(this.projectile.position.X, this.projectile.position.Y, 5, -Main.rand.Next(10)-5, style, dmg, 0, Main.myPlayer)   ;  


 Projectile.NewProjectile(this.projectile.position.X, this.projectile.position.Y, 2, -Main.rand.Next(10)-5, style, dmg, 0, Main.myPlayer)  ;
   Projectile.NewProjectile(this.projectile.position.X, this.projectile.position.Y, 2, -Main.rand.Next(10)-5, style, dmg, 0, Main.myPlayer)   ;  
   Projectile.NewProjectile(this.projectile.position.X, this.projectile.position.Y, 3, -Main.rand.Next(10)-5, style, dmg, 0, Main.myPlayer)   ; 
   Projectile.NewProjectile(this.projectile.position.X, this.projectile.position.Y, 3, -Main.rand.Next(10)-5, style, dmg, 0, Main.myPlayer)   ;  
   Projectile.NewProjectile(this.projectile.position.X, this.projectile.position.Y, 4, -Main.rand.Next(10)-5, style, dmg, 0, Main.myPlayer)   ;  


   Projectile.NewProjectile(this.projectile.position.X, this.projectile.position.Y, 0, -Main.rand.Next(10)-5, style, dmg, 0, Main.myPlayer)   ;  
   Projectile.NewProjectile(this.projectile.position.X, this.projectile.position.Y, 0, -Main.rand.Next(10)-5, style, dmg, 0, Main.myPlayer)   ;  

   Projectile.NewProjectile(this.projectile.position.X, this.projectile.position.Y, -4, -Main.rand.Next(10)-5, style, dmg, 0, Main.myPlayer)  ;
   Projectile.NewProjectile(this.projectile.position.X, this.projectile.position.Y, -3, -Main.rand.Next(10)-5, style, dmg, 0, Main.myPlayer)   ;  
   Projectile.NewProjectile(this.projectile.position.X, this.projectile.position.Y, -6, -Main.rand.Next(10)-5, style, dmg, 0, Main.myPlayer)   ; 
   Projectile.NewProjectile(this.projectile.position.X, this.projectile.position.Y, -2, -Main.rand.Next(10)-5, style, dmg, 0, Main.myPlayer)   ;  
   Projectile.NewProjectile(this.projectile.position.X, this.projectile.position.Y, -2, -Main.rand.Next(10)-5, style, dmg, 0, Main.myPlayer)   ; 


   Projectile.NewProjectile(this.projectile.position.X, this.projectile.position.Y, -5, -Main.rand.Next(10)-5, style, dmg, 0, Main.myPlayer)  ;
   Projectile.NewProjectile(this.projectile.position.X, this.projectile.position.Y, -5, -Main.rand.Next(10)-5, style, dmg, 0, Main.myPlayer)   ;  
   Projectile.NewProjectile(this.projectile.position.X, this.projectile.position.Y, -5, -Main.rand.Next(10)-5, style, dmg, 0, Main.myPlayer)   ; 
   Projectile.NewProjectile(this.projectile.position.X, this.projectile.position.Y, -5, -Main.rand.Next(10)-5, style, dmg, 0, Main.myPlayer)   ;  
   Projectile.NewProjectile(this.projectile.position.X, this.projectile.position.Y, -5, -Main.rand.Next(10)-5, style, dmg, 0, Main.myPlayer)   ;  
}
this.projectile.active=false;
}

public void Kill(){
   
int style = Config.projDefs.byName["RMagicBowArrow"].type;
int myID = Main.myPlayer;
int dmg = Main.rand.Next(30)+15;
//int arrow = ;
//int style = 2;

   Projectile.NewProjectile(this.projectile.position.X-150, this.projectile.position.Y-950, 2, Main.rand.Next(10)+5, style, dmg, 0, myID)  ;
   Projectile.NewProjectile(this.projectile.position.X-100, this.projectile.position.Y-550, 0, Main.rand.Next(10)+5, style, dmg, 0, myID)   ;  
   Projectile.NewProjectile(this.projectile.position.X-50, this.projectile.position.Y-550, 0, Main.rand.Next(10)+5, style, dmg, 0, myID)   ; 

   Projectile.NewProjectile(this.projectile.position.X, this.projectile.position.Y-550, 0, Main.rand.Next(10)+5, style, dmg, 0, myID)   ;  

   Projectile.NewProjectile(this.projectile.position.X+50, this.projectile.position.Y-550, 0, Main.rand.Next(10)+5, style, dmg, 0, myID)   ;  
   Projectile.NewProjectile(this.projectile.position.X+100, this.projectile.position.Y-550, 0, Main.rand.Next(10)+5, style, dmg, 0, myID)   ;  
   Projectile.NewProjectile(this.projectile.position.X+150, this.projectile.position.Y-550, -2, Main.rand.Next(10)+5, style, dmg, 0, myID)   ;  


int rdm = Main.rand.Next(15)*15;
int vector = Main.rand.Next(20)/10;

   Projectile.NewProjectile(this.projectile.position.X-rdm, this.projectile.position.Y-750, vector, Main.rand.Next(10)+5, style, dmg, 0, myID)   ;
   Projectile.NewProjectile(this.projectile.position.X-rdm, this.projectile.position.Y-750, vector, Main.rand.Next(10)+5, style, dmg, 0, myID)   ;  
   Projectile.NewProjectile(this.projectile.position.X-rdm, this.projectile.position.Y-750, vector, Main.rand.Next(10)+5, style, dmg, 0, myID)   ; 

   Projectile.NewProjectile(this.projectile.position.X, this.projectile.position.Y-750, 0, Main.rand.Next(10)+5, style, dmg, 0, myID)   ;  

   Projectile.NewProjectile(this.projectile.position.X+rdm, this.projectile.position.Y-750, -vector, Main.rand.Next(10)+5, style, dmg, 0, myID)   ;  
   Projectile.NewProjectile(this.projectile.position.X+rdm, this.projectile.position.Y-750, -vector, Main.rand.Next(10)+5, style, dmg, 0, myID)   ;  
   Projectile.NewProjectile(this.projectile.position.X+rdm, this.projectile.position.Y-750, -vector, Main.rand.Next(10)+5, style, dmg, 0, myID)   ;  
  
  
this.projectile.active = false;
}
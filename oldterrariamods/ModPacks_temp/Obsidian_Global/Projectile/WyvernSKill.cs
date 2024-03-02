public void Initialize(){
int x = Main.rand.Next(5);

if(x==0){
this.projectile.scale=0.5f;
}
if(x==1){
this.projectile.scale=0.65f;
}
if(x==2){
this.projectile.scale=0.9f;
}
if(x==3){
this.projectile.scale=1.1f;
}
if(x==4){
this.projectile.scale=1.2f;
}

}
int AIStyle = 0;
int timer =  0;


public void AI(){



if(timer<0){
timer--;
}

if(timer<-10){
timer=0;
}

bool flag = false;
for(int i=0; i<Main.npc.Length; i++){
float differenceXX = ((Main.npc[i].position.X )- this.npc.position.X);
float differenceYY = ((Main.npc[i].position.Y )-  this.npc.position.Y);

if( (differenceXX > 30f || differenceXX < -30f || differenceYY > 30f || differenceYY < -30f) ){

}else if ( Main.npc[i].type!=this.npc.type && Main.npc[i].townNPC == false){


if(timer==0){
Main.npc[i].StrikeNPC(10,5, this.npc.direction);
timer--;
}

}
}

float differenceX = ((this.npc.position.X )- (Main.player[Main.myPlayer].position.X));
float differenceY = ((this.npc.position.Y )- (Main.player[Main.myPlayer].position.Y));

if( differenceX > 750f || differenceX < -750f && (differenceY > 10f || differenceY < -10f)){

AIStyle = 2;

}else if( differenceX > 15f || differenceX < -15f && (differenceY > 15f || differenceY < -15f)){

AIStyle = 0;
				
}else{

AIStyle =1;

}


if(AIStyle == 0){
	this.npc.TargetClosest(true);
   
				if (!Main.dayTime || this.npc.life != this.npc.lifeMax || (double)this.npc.position.Y > Main.worldSurface * 16.0)
				{
					flag = true;
				}
			
				if (this.npc.ai[2] > 1f)
				{
					this.npc.ai[2] -= 1f;
				}
				if (this.npc.wet)
				{
					if (this.npc.collideY)
					{
						this.npc.velocity.Y = -2f;
					}
					if (this.npc.velocity.Y < 0f && this.npc.ai[3] == this.npc.position.X)
					{
						this.npc.direction *= -1;
						this.npc.ai[2] = 200f;
					}
					if (this.npc.velocity.Y > 0f)
					{
						this.npc.ai[3] = this.npc.position.X;
					}
					if (this.npc.type == 59)
					{
						if (this.npc.velocity.Y > 2f)
						{
							this.npc.velocity.Y = this.npc.velocity.Y * 0.9f;
						}
						else
						{
							if (this.npc.directionY < 0)
							{
								this.npc.velocity.Y = this.npc.velocity.Y - 0.8f;
							}
						}
						this.npc.velocity.Y = this.npc.velocity.Y - 0.5f;
						if (this.npc.velocity.Y < -10f)
						{
							this.npc.velocity.Y = -10f;
						}
					}
					else
					{
						if (this.npc.velocity.Y > 2f)
						{
							this.npc.velocity.Y = this.npc.velocity.Y * 0.9f;
						}
						this.npc.velocity.Y = this.npc.velocity.Y - 0.5f;
						if (this.npc.velocity.Y < -4f)
						{
							this.npc.velocity.Y = -4f;
						}
					}
					if (this.npc.ai[2] == 1f && flag)
					{
	
					}
				}
				this.npc.aiAction = 0;
				if (this.npc.ai[2] == 0f)
				{
					this.npc.ai[0] = -100f;
					this.npc.ai[2] = 1f;

				}
				if (this.npc.velocity.Y == 0f)
				{
					if (this.npc.ai[3] == this.npc.position.X)
					{
						this.npc.direction *= -1;
						this.npc.ai[2] = 200f;
					}
					this.npc.ai[3] = 0f;
					this.npc.velocity.X = this.npc.velocity.X * 0.8f;
					if ((double)this.npc.velocity.X > -0.1 && (double)this.npc.velocity.X < 0.1)
					{
						this.npc.velocity.X = 0f;
					}
					if (flag)
					{
						this.npc.ai[0] += 1f;
					}
					this.npc.ai[0] += 1f;
					if (this.npc.type == 59)
					{
						this.npc.ai[0] += 2f;
					}
					if (this.npc.type == 71)
					{
						this.npc.ai[0] += 3f;
					}
					if (this.npc.type == 138)
					{
						this.npc.ai[0] += 2f;
					}
					if (this.npc.type == 81)
					{
						if (this.npc.scale >= 0f)
						{
							this.npc.ai[0] += 4f;
						}
						else
						{
							this.npc.ai[0] += 1f;
						}
					}
					if (this.npc.ai[0] >= 0f)
					{
						this.npc.netUpdate = true;
						if (flag && this.npc.ai[2] == 1f)
						{
							this.npc.TargetClosest(true);
						}
						if (this.npc.ai[1] == 2f)
						{
							this.npc.velocity.Y = -8f;
							if (this.npc.type == 59)
							{
								this.npc.velocity.Y = this.npc.velocity.Y - 2f;
							}
							this.npc.velocity.X = this.npc.velocity.X + (float)(3 * this.npc.direction);
							if (this.npc.type == 59)
							{
								this.npc.velocity.X = this.npc.velocity.X + 0.5f * (float)this.npc.direction;
							}
							this.npc.ai[0] = -200f;
							this.npc.ai[1] = 0f;
							this.npc.ai[3] = this.npc.position.X;
						}
						else
						{
							this.npc.velocity.Y = -6f;
							this.npc.velocity.X = this.npc.velocity.X + (float)(2 * this.npc.direction);
							if (this.npc.type == 59)
							{
								this.npc.velocity.X = this.npc.velocity.X + (float)(2 * this.npc.direction);
							}
							this.npc.ai[0] = -120f;
							this.npc.ai[1] += 1f;
						}
						if (this.npc.type == 141)
						{
							this.npc.velocity.Y = this.npc.velocity.Y * 1.3f;
							this.npc.velocity.X = this.npc.velocity.X * 1.2f;
							return;
						}
					}
					else
					{
						if (this.npc.ai[0] >= -30f)
						{
							this.npc.aiAction = 1;
							return;
						}
					}
				}
				else
				{
					if (this.npc.target < 255 && ((this.npc.direction == 1 && this.npc.velocity.X < 3f) || (this.npc.direction == -1 && this.npc.velocity.X > -3f)))
					{
						if ((this.npc.direction == -1 && (double)this.npc.velocity.X < 0.1) || (this.npc.direction == 1 && (double)this.npc.velocity.X > -0.1))
						{
							this.npc.velocity.X = this.npc.velocity.X + 0.2f * (float)this.npc.direction;
							return;
						}
						this.npc.velocity.X = this.npc.velocity.X * 0.93f;
						return;
					}
				}
}else if(AIStyle == 1){

if(this.npc.velocity.Y == 0){
this.npc.velocity.X =0;
}

if(Main.rand.Next(50)==0){
this.npc.velocity.Y -= 1;
AIStyle = 0;
}

}else if(AIStyle ==2){
int num = Dust.NewDust(this.npc.position, this.npc.width, this.npc.height, 14, 0f, 0f, this.npc.alpha, this.npc.color, 1f);
						Dust dust = Main.dust[num];
						Dust expr_1A2 = dust;
						expr_1A2.velocity *= 0.3f;
this.npc.position.X = Main.player[Main.myPlayer].position.X;
this.npc.position.Y = Main.player[Main.myPlayer].position.Y - 20;
int num2 = Dust.NewDust(this.npc.position, this.npc.width, this.npc.height, 14, 0f, 0f, this.npc.alpha, this.npc.color, 1f);
						Dust dust2 = Main.dust[num2];
						Dust expr_1A22 = dust2;
						expr_1A22.velocity *= 0.3f;
}
}


public void Initialize(){


this.npc.displayName = "Slimy";

if(ModPlayer.hasPet == false){

ModPlayer.pet = this.npc;
ModPlayer.hasPet = true;
}else{

ModPlayer.pet.StrikeNPC(999,2, this.npc.direction);
ModPlayer.pet = this.npc;
ModPlayer.hasPet = true;

}

}

public void NPCLoot(){
//Main.NewText("dead");
ModPlayer.hasPet = false;
}


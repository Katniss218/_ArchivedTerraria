float CHARGE = 0;
int Pindex = -1;
Color Color1 = Color.White;
Color Color2 = Color.Blue;
int DT = 15;
float dustSpeed = 1f;
bool DrawLazer = true;
public void AI() {
    CHARGE++;
    Projectile P = projectile;
    Player O = Main.player[P.owner];
    if(CHARGE == 99) {
        Pindex = Projectile.NewProjectile(P.position.X + P.width / 2, P.position.Y + P.height / 2, P.velocity.X, P.velocity.Y, Config.projDefs.byName["Focus Beam 2"].type, (int)50 + (O.rangedCrit / 2), 3f, P.owner);
        Main.PlaySound(2, (int)P.position.X, (int)P.position.Y, SoundHandler.soundID["Pulse"]);
    }
    if(CHARGE > 101) CHARGE = 101;
    float MY = Main.mouseY + Main.screenPosition.Y;
    float MX = Main.mouseX + Main.screenPosition.X;
    if (Main.myPlayer == P.owner) {
        if (O.channel) {
            float num119 = 0f;
            if (O.inventory[O.selectedItem].shoot == P.type) {
                num119 = O.inventory[O.selectedItem].shootSpeed * P.scale;
            }
            Vector2 vector14 = new Vector2(O.position.X + (float)O.width * 0.5f, O.position.Y + (float)O.height * 0.5f);
            float num120 = MX - vector14.X;
            float num121 = MY - vector14.Y;
            float num122 = (float)Math.Sqrt((double)(num120 * num120 + num121 * num121));
            num122 = (float)Math.Sqrt((double)(num120 * num120 + num121 * num121));
            num122 = num119 / num122;
            num120 *= num122;
            num121 *= num122;
            if (num120 != P.velocity.X || num121 != P.velocity.Y) {
                P.netUpdate = true;
            }
            P.velocity.X = num120;
            P.velocity.Y = num121;
            P.timeLeft = 20;
        }
        else {
            P.Kill();
            return;
        }
    }
    P.scale = CHARGE / 100;
    int Times = 1 + (DrawLazer ? 0 : 1);
    while (Times > 0) {
        Times--;
        int d = Dust.NewDust(P.position - new Vector2(5, 5), 1, 1, DT, 1f, 1f, (int)(P.scale * 255f), Color2, P.scale * 3f);
        int d2 = Dust.NewDust(P.position - new Vector2(5, 5), 1, 1, DT, 0, 0, (int)(P.scale * 255f), Color2, P.scale * 3f);
        Main.dust[d].noGravity = true;
        Main.dust[d].rotation = P.rotation;
        Main.dust[d2].noGravity = true;
        Main.dust[d2].rotation = P.rotation;
        if (P.scale < 1.0) {
            float v2 = 1 - P.scale;
            Color Color3 = new Color(0, 0, 0, 0);
            Color3.A = (byte)((Color2.A * P.scale + Color1.A * v2 ) / 2);
            Color3.R = (byte)((Color2.R * P.scale + Color1.R * v2) / 2);
            Color3.G = (byte)((Color2.G * P.scale + Color1.G * v2) / 2);
            Color3.B = (byte)((Color2.B * P.scale + Color1.B * v2) / 2);
            Main.dust[d].color = Color3;
            Main.dust[d2].color = Color3;
        }
        else {
            Main.dust[d].velocity += P.velocity * dustSpeed + O.velocity;
            Main.dust[d2].velocity += P.velocity * dustSpeed + O.velocity;
        }
    }
    float targetrotation = (float)Math.Atan2((MY - O.position.Y), (MX - O.position.X));
    P.rotation = targetrotation;
    //Main.NewText(O.itemRotation + ", " + P.rotation);
    O.itemTime = 2;
    O.itemAnimation = 2;
    float Dist = 60;
    P.position = new Vector2(O.itemLocation.X + (float)((float)Math.Cos(targetrotation) * Dist) * 0.66f, O.itemLocation.Y + (float)((float)Math.Sin(targetrotation) * Dist) * 0.66f);
    if (P.velocity.X < 0) {
        P.direction = -1;
    }
    else {
        P.direction = 1;
    }
    P.spriteDirection = P.direction;
    O.heldProj = P.whoAmI;
    O.direction = P.direction;
    O.itemRotation = (float)Math.Atan2((MY - O.position.Y) * O.direction, (MX - O.position.X) * O.direction) - 0.05f * O.direction;
    if (Pindex != -1 && Main.projectile[Pindex].active)
        Main.projectile[Pindex].RunMethod("TotalRotate", P.position - new Vector2(3f * O.direction, 3f * O.gravDir), new Vector2((float)Math.Cos(targetrotation), (float)Math.Sin(targetrotation)));
    P.width = (int)(20f * P.scale);
    P.height = (int)(20f * P.scale);
}
public void Kill() {
    Projectile tP = projectile;
    foreach (Projectile P in Main.projectile) {
        if (P.active) {
            if (P.type == Config.projDefs.byName["Focus Beam 2"].type && P.owner == tP.owner)
                P.Kill();
        }
    }
    tP.active = false;
    //return;
}
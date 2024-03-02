public void AI() {
    this.projectile.alpha = 255-(this.projectile.timeLeft*2)-(int)(25*this.projectile.scale);
    if (this.projectile.alpha < 100) this.projectile.alpha = 0;
}

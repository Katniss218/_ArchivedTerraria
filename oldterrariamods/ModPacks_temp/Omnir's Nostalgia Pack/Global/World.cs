public static bool CheckingMyCollision;
public Vector2 TileCollision(Vector2 Result,Vector2 Position,Vector2 Velocity,int Width,int Height,bool fallThrough,bool fall2) 
{
    if(CheckingMyCollision) Result = Velocity;
    CheckingMyCollision = false;
    return Result;
}
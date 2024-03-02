public bool CanUse(Player P)
{
    if (P.controlUseTile || P.controlHook || P.controlUseItem) {
        return true;
    }
    return false;
}

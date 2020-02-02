namespace GGJ.AnimationLogic
{
    public class OnLaserBeamReachedCenter : EventCallbacks.Event<OnLaserBeamReachedCenter>
    {
        public OnLaserBeamReachedCenter() : base("")
        {
            FireEvent(this);
        }
    }
}

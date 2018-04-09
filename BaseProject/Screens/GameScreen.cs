namespace BaseProject
{
    public class GameScreen : Screen
    {


        public GameScreen()
            : base()
        {

        }

        public override void Create()
        {

        }

        public override void Update(float time)
        {
            UiManager.Update(time);
            TimerManager.Update(time);
        }

        public override void Draw()
        {
            Batch.Begin();
            UiManager.Draw(Batch);
            Batch.End();
        }
    }
}
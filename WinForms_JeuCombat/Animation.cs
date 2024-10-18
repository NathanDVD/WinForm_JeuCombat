namespace WinForms_JeuCombat
{
    internal class AnimationClass
    {
        //Bounce function here
        public static async void BounceFunction(Control control, Point targetPos, Point targetPos2, int speed)
        {

            while (control.Location.Y > targetPos.Y)//< to end position
            {
                speed += 1;//Incremental speed
                control.Location = new Point(control.Location.X, control.Location.Y - speed);//Change position with speed
                await Task.Delay(20);//Wait 20ms without freezing program
            }

            speed = -10; //Inverse speed to create bounce effect
            while (control.Location.Y < targetPos2.Y)
            {
                speed += 1;
                control.Location = new Point(control.Location.X, control.Location.Y - speed);
                await Task.Delay(20);
            }
            speed = 10;

            //When finished remove menu
            control.Location = targetPos;
        }

        public static async void CharacterAnim(PictureBox characterImage, int direction)
        {
            Point startLocation = characterImage.Location;
            characterImage.Location = new Point(startLocation.X + (200 * direction), startLocation.Y);

            await Task.Delay(200);

            characterImage.Location = startLocation;
        }
    }
}

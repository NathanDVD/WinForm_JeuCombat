using System.DirectoryServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace WinForms_JeuCombat
{
    internal class AnimationClass
    {
        private static int speed;

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

        public static async void CharacterAnim(PictureBox characterImage, int xDirection, string action)
        {
            
            if (action == "Attack")
            {
                Animate(characterImage, xDirection, 0, action);//Animate one way

                await Task.Delay(500);//Wait

                Animate(characterImage, -xDirection, 0, action);//Reverse the animation
            }
            else if(action == "Defend")
            {
                Animate(characterImage, 0, -1, action);//Animate one way

                await Task.Delay(500);

                Animate(characterImage, 0, 1, action);//Reverse the animation
            }
            else
            {
                
            }
        }
        public async static void Animate(PictureBox characterImage, int xDirection, int yDirection, string action)
        {
            Point location = characterImage.Location;
            Point startLocation = location; //Set start location

            int targetX = startLocation.X + (200 * xDirection);//Calculate end locations
            int targetY = startLocation.Y + (100 * yDirection);

            speed = 1;//Reset speed

            if (xDirection != 0)
            {
                while ((xDirection == 1 && startLocation.X < targetX) || (xDirection == -1 && startLocation.X > targetX))
                {
                    speed += 2;//Incremental speed
                    startLocation.X += xDirection * speed;//Move in the direction based on xDirection (-1 to 1)
                    characterImage.Location = new Point(startLocation.X, startLocation.Y);
                    await Task.Delay(20);//Wait
                }
            }
            else
            {
                while ((yDirection == 1 && startLocation.Y < targetY) || (yDirection == -1 && startLocation.Y > targetY))
                {
                    speed += 2;//Incremental speed
                    startLocation.Y += yDirection * speed;//Move in direction based on yDirection (-1 to 1)
                    characterImage.Location = new Point(startLocation.X, startLocation.Y);
                    await Task.Delay(20);//Wait
                }
            }
        }
    }
}

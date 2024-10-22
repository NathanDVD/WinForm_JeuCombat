using System.Diagnostics;

namespace WinForms_JeuCombat
{
    internal class AnimationClass
    {
        private static float speed;



        //<<<<<<<<<<<<<<<<<<<<<<<<<<----------------------------------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        //
        //Bounce function used primarily for the menu buttons. Needs a Control, 2 target locations and a float to control the movement speed.
        //The function will loop until the 1st destination is reached (adding more speed), it also converts a PointF(float) into a Point(int), then
        //go in the other direction (2nd destination) to create this "bounce" effect, then will continue in the primary direction.
        //
        //___________________________________________________________________________________________________________
        public static async void BounceFunction(Control control, PointF targetPos, PointF targetPos2, float speed)
        {
            // Move upwards until reaching the target position (bounce start)
            while (control.Location.Y > targetPos.Y)
            {
                speed += 0.5f;
                float newY = control.Location.Y - speed;

                Debug.WriteLine(newY + " / " + (int)newY);

                control.Location = new Point(control.Location.X, (int)newY);//Convert to integer Point
                await Task.Delay(20); //Wait
            }

            //Reverse speed to create bounce effect
            speed = -11;
            while (control.Location.Y < targetPos2.Y)
            {
                speed += 1.1f;
                float newY = control.Location.Y - speed;
                control.Location = new Point(control.Location.X, (int)newY); // Convert to integer Point
                await Task.Delay(20);
            }
            speed = 10;//Reset speed
        }


        //<<<<<<<<<<<<<<<<<<<<<<<<<<----------------------------------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        //
        //Uses the animate function to move the character according to the action that was chosen.
        //Character animations  --> Faire ici le chagement de frame
        //
        //___________________________________________________________________________________________________________
        public static async void CharacterAnim(PictureBox characterImage, int xDirection, Form1.ActionChoice action)
        {
           
            if (action == Form1.ActionChoice.Attack)  //MOVEMENT
            {
                Animate(characterImage, xDirection, 0);//Animate one way

                await Task.Delay(500);//Wait

                Animate(characterImage, -xDirection, 0);//Reverse the animation
            }
            else if(action == Form1.ActionChoice.Defend)  //JUMP
            {
                Animate(characterImage, 0, -1);//Animate one way

                await Task.Delay(500);

                Animate(characterImage, 0, 1);//Reverse the animation
            }

        }


        //<<<<<<<<<<<<<<<<<<<<<<<<<<----------------------------------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        //
        //Animation logic :
        //Take image location, set a new location every 20ms by the chosen offset multiplied by the speed(which is incremental)
        //in the chosen direction, only if the xDirection and yDirection are not 0.
        //It also works with anything that has a location parameter, you just need to change PictureBox to Control.
        //
        //___________________________________________________________________________________________________________
        public async static void Animate(PictureBox characterImage, int xDirection, int yDirection)
        {
            Point location = characterImage.Location;
            Point startLocation = location;//Set start location

            int targetX = startLocation.X + (200 * xDirection);//Calculate end locations
            int targetY = startLocation.Y + (100 * yDirection);

            speed = 1;//Reset speed

            if (xDirection != 0)
            {
                //While loop to move the image until it reaches the set destination (for the X axis)
                while ((xDirection == 1 && startLocation.X < targetX) || (xDirection == -1 && startLocation.X > targetX))
                {
                    speed += 2;//Incremental speed
                    startLocation.X += xDirection * (int)speed;//Move in the direction based on xDirection (-1 to 1)
                    characterImage.Location = new Point(startLocation.X, startLocation.Y);
                    await Task.Delay(20);//Wait
                }
            }
            else
            {
                //While loop to move the image until it reaches the set destination (for the Y axis)
                while ((yDirection == 1 && startLocation.Y < targetY) || (yDirection == -1 && startLocation.Y > targetY))
                {
                    speed += 2;//Incremental speed
                    startLocation.Y += yDirection * (int)speed;//Move in direction based on yDirection (-1 to 1)
                    characterImage.Location = new Point(startLocation.X, startLocation.Y);
                    await Task.Delay(20);//Wait
                }
            }
        }
    }
}

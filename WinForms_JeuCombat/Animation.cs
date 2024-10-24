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
        //Uses the XMovement function to move the character according to the action that was chosen.
        //Character animations  --> Faire ici le chagement de frame
        //
        //___________________________________________________________________________________________________________
        public static async void CharacterAnim(Form1.Characters character, PictureBox characterImage, int xDirection, Form1.ActionChoice action)
        {
            Image baseImage = (Image)character.idle_frame.Clone();//Clone the base image

            if (action == Form1.ActionChoice.Attack)//MOVEMENT
            {
                //Setup the image to use
                Image attackImage = (Image)character.attack_frame.Clone(); // Clone the attack frame
                if (characterImage.Name == "ComputerBox")
                {
                    attackImage.RotateFlip(RotateFlipType.Rotate180FlipY);
                } //AI Flip

                characterImage.BackgroundImage = attackImage;//Set image
                await Task.Delay(500);//Wait

                //Go back to base frame
                characterImage.BackgroundImage = baseImage; //Switch(-> idle frame)
            }
            else if (action == Form1.ActionChoice.Defend)
            {
                //Defend action, maybe pass (useless for moment)
            }
            else if (action == Form1.ActionChoice.Spell)
            {
                //Setup the image to use
                Image spellImage = (Image)character.spell_frame.Clone(); // Clone the spell frame
                if (characterImage.Name == "ComputerBox")
                {
                    spellImage.RotateFlip(RotateFlipType.Rotate180FlipY);
                }

                characterImage.BackgroundImage = spellImage;

                await Task.Delay(500);

                //Go back to base frame
                characterImage.BackgroundImage = baseImage;
            }
        }


        
    }
}

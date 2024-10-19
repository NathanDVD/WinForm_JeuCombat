using System.Diagnostics;
using System.Media;
using System.Windows.Forms;

namespace WinForms_JeuCombat
{
    public partial class Form1 : Form
    {
        List<Button> characterButtonList = new List<Button>();
        List<Image> imageList = new List<Image>();
        List<Image> enemyList = new List<Image>();
        List<Image> playerList = new List<Image>();
        List<Button> optionButtonList = new List<Button>();

        private bool canChange = true;
        private bool choseCharacter = false;
        public bool choseAction = false;

        private int buttonOffset = 0;

        private Button choiceButton;

        private SoundPlayer sPlayer;
        private SoundPlayer mSoundPlayer;


        public Form1()
        {
            InitializeComponent();//Start the WinForm

            //Load the sounds and songs
            sPlayer = new SoundPlayer("./Sounds/8-Bit_FightingGame_Music.wav");
            sPlayer.Load();
            //Here too
            mSoundPlayer = new SoundPlayer("./Sounds/Game_Start.wav");
            mSoundPlayer.Load();

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Get half of screen height and width + half of button height and width to find the perfect center of the screen
            PlayButton.Location = new Point((this.Width / 2) - (PlayButton.Width / 2), (this.Height / 2) - (PlayButton.Height / 2));
            QuitButton.Location = new Point((this.Width / 2) - (QuitButton.Width / 2), (this.Height / 2 + 150) - (QuitButton.Height / 2));

            label1.Location = new Point((this.Width / 2) - (label1.Width / 2), 150);

            textBox1.Location = new Point(-1000, 0);


            //Add character choice buttons to list
            characterButtonList.AddRange(new Button[] { DamagerButton, HealerButton, TankButton, AssasinButton });
            //Set all the images for the buttons
            imageList.AddRange(new List<Image>() { 
                Image.FromFile("./Images/damager_selection.png"),
                Image.FromFile("./Images/healer_selection.png"),
                Image.FromFile("./Images/tank_selection.png"),
                Image.FromFile("./Images/assassin_selection.png") 
            });
            playerList.AddRange(new List<Image>() {
                Image.FromFile("./Images/damager.png"),
                Image.FromFile("./Images/healer.png"),
                Image.FromFile("./Images/tank.png"),
                Image.FromFile("./Images/assassin.png")
            });
            enemyList.AddRange(new List<Image>() {
                Image.FromFile("./Images/damager_inverse.png"),
                Image.FromFile("./Images/healer_inverse.png"),
                Image.FromFile("./Images/tank_inverse.png"),
                Image.FromFile("./Images/assassin_inverse.png")
            });

            //List of all the option buttons to display later
            optionButtonList.AddRange(new Button[] {AttackButton, DefendButton, SpellButton});
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            mSoundPlayer.Play();//Play sound

            //ANimate controls leaving screen
            AnimationClass.BounceFunction(PlayButton, new Point(0, 250), new Point(0, 500), 1);
            AnimationClass.BounceFunction(QuitButton, new Point(0, 500), new Point(0, 550), 1);
            AnimationClass.BounceFunction(label1, new Point(0, 100), new Point(0, 400), 1);

            buttonOffset = 0;//Offset

            await Task.Delay(2000);//Wait 2 seconds

            //Set all character choice buttons position
            foreach (Button button in characterButtonList)
            {
                button.Size = new Size(356, 496);//Set the button size to the image's
                button.Image = imageList[int.Parse(button.Tag.ToString())-1];//Select image according to button tag
                button.Location = new Point((this.Width / 5 +  buttonOffset) - (button.Width / 2), (this.Height / 2 + 100) - (button.Height / 2));
                buttonOffset += 400;//Add offset between images

                //Create the select buttons
                Button selButton = new Button();
                selButton.Name = "selButton" + (int.Parse(button.Tag.ToString()) - 1);//Set name according to button button tag + "selButton"
                //Set parameters for select buttons

                selButton.Click += characterChoice_Click;  selButton.Tag = button.Tag;//Set button tag to match button and add click Event
                selButton.Location = new Point(button.Location.X + 50, button.Location.Y + 550);selButton.Size = new Size(275,113);//Set position and size
                selButton.FlatStyle = FlatStyle.Flat;//Set type of button
                selButton.BackColor = Color.Transparent;
                selButton.FlatAppearance.BorderSize = 0; selButton.FlatAppearance.MouseOverBackColor = Color.Transparent; selButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
                selButton.Image = Image.FromFile("./Images/Button_Select.png");//Set image
                this.Controls.Add(selButton);//Actually show the image, else it is not added during runtime
            }

            textBox1.Location = new Point((this.Width / 2) - (textBox1.Width / 2), 150);

            await Task.Delay(1000);

            sPlayer.PlayLooping();//Loops the song selected

            //Before the game starts
            textBox1.Text += "Choisissez un personnage:\r\n1 - Damager\r\n2 - Healer\r\n3 - Tank\r\n4 - Assasin\r\n";
        }


        //If clicked exit the app
        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();//Exit the app
        }

        //If clicked start the game
        private void characterChoice_Click(object sender, EventArgs e)
        {
            buttonOffset = 100;
            //Move the buttons on the window
            foreach (Button button in optionButtonList)
            {
                button.Location = new Point((this.Width / 3 + buttonOffset) - (button.Width / 2), (this.Height / 2 + 500) - (button.Height / 2));
                buttonOffset += 200;
            }

            Button clickedButton = sender as Button;//Button clicked that sent triggered the event

            MainFunction(textBox1, clickedButton);//Launch main function
        }

        private void actionChoice_Click(object sender, EventArgs e)
        {
            Button cButton = sender as Button;

            Debug.WriteLine($"Clicked button Tag: {cButton.Tag}");

            choiceButton = cButton;

            choseAction = true;
        }

        
        //Here ends the form section, no more Form controls (buttons, label, textbox ect...)
        //The following code is the logic of the game
        //
        //
        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<------------------------------------------------------------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
        //
        //
        //
        //Big chunk of code ahead : 
        public enum ActionChoice
        {
            Attack = 1,
            Defend = 2,
            Spell = 3,
        }

        //Dictionnaire contenant données des classes de personnage -> chaque valeur est elle-même un dictionnaire représentant le personnage
        static Dictionary<string, Dictionary<string, object>> character = new Dictionary<string, Dictionary<string, object>>()
        {
            {
                "Damager", new Dictionary<string, object>()
                {
                    { "Name", "Damager" },
                    { "HP", 3 },
                    { "Force", 2 },
                    { "Action", ActionChoice.Defend},
                    { "Poisoned", false}
                }
            },
            {
                "Healer", new Dictionary<string, object>()
                {
                    { "Name", "Healer" },
                    { "HP", 4 },
                    { "Force", 1 },
                    { "Action", ActionChoice.Defend },
                    { "Poisoned", false}
                }
            },
            {
                "Tank", new Dictionary<string, object>()
                {
                    { "Name", "Tank" },
                    { "HP", 5 },
                    { "Force", 1 },
                    { "Action", ActionChoice.Defend },
                    { "Poisoned", false}
                }
            },
            {
                "Assassin", new Dictionary<string, object>()
                {
                    { "Name", "Assassin" },
                    { "HP", 3 },
                    { "Force", 1 },
                    { "Action", ActionChoice.Defend },
                    { "Poisoned", false}
                }
            },
        };

        public void MainFunction(TextBox tBox, Button button)
        {
            //--------- INITIALISATION -----------
            bool isEnd = false;

            Random rnd = new Random();

            // Choix personnage joueur
            Dictionary<string, object> playerCharacter = new Dictionary<string, object>(character[PlayerChooseCharacter(tBox, button, PlayerBox)]);
            PlayerBox.Location = new Point((this.Width / 2 - 200) - (PlayerBox.Width / 2), (this.Height / 2 + 300) - (PlayerBox.Height / 2));

            // Choix personnage AI
            Dictionary<string, object> AICharacter = new Dictionary<string, object>(character[AIChooseCharacter(ComputerBox)]);
            ComputerBox.Location = new Point((this.Width / 2 + 200) - (ComputerBox.Width / 2), (this.Height / 2 + 300) - (ComputerBox.Height / 2));

            //Affichage choix personnages
            tBox.Text += $"\r\nJoueur : {playerCharacter["Name"]}\r\nIA : {AICharacter["Name"]}";

            //------------- BOUCLE DU JEU  ----------------

            //On affiche l'état du jeu(faire fonction)
            DisplayHealth(playerCharacter, AICharacter, tBox);

            while (!isEnd)
            {
                Debug.WriteLine(choseAction);
                while (!choseAction)
                {
                    Application.DoEvents();//Does not freeze the app waiting for the user input
                }

                choseAction = false;

                //Choix adction joueur
                PlayerChooseAction(playerCharacter, tBox, choiceButton, PlayerBox);

                //Choix action IA
                AIChooseAction(AICharacter, ComputerBox);

                //Combat (round)
                Fight(playerCharacter, AICharacter, tBox);

                //On affiche l'état du jeu
                DisplayHealth(playerCharacter, AICharacter, tBox);
                //Conditions de fin
                isEnd = isEndGame(playerCharacter, AICharacter, tBox);

            }
        }

        //---------------------------------------------


        //Fonction combat appelé à chaque tour
        static void Fight(Dictionary<string, object> player, Dictionary<string, object> ai, TextBox tBox)
        {
            //Si cible empoisonnée au tour préc = - 1 HP et on retire empoisonnement
            if (isPoisoned(player))
            {
                tBox.Text += ("\r\nPoison : - 1 HP"); //pour test
                TakeDamage(player, 1);
                Poisoned(player, false);
            }
            else if (isPoisoned(ai))
            {
                tBox.Text += ("\r\nPoison : - 1 HP"); //pour test
                TakeDamage(ai, 1);
                Poisoned(ai, false);
            }

            //Display
            ShowPlayerAction((ActionChoice)player["Action"], tBox);
            ShowAIAction((ActionChoice)ai["Action"], tBox);

            //Play
            PlayAction(player, ai, true, tBox);
            PlayAction(ai, player, false, tBox);

        }

        //Fonction jouant l'action
        static void PlayAction(Dictionary<string, object> actionPlayer, Dictionary<string, object> otherPlayer, bool isPlayer, TextBox tBox)
        {
            //GET ACTIONS
            ActionChoice actionPlayerChoice = (ActionChoice)actionPlayer["Action"];
            ActionChoice otherPlayerChoice = (ActionChoice)otherPlayer["Action"];

            if (actionPlayerChoice == ActionChoice.Spell) //SPELL
            {
                if ((string)actionPlayer["Name"] == "Healer") //HEAL
                {
                    Heal(actionPlayer, tBox);
                }
                else if ((string)actionPlayer["Name"] == "Assassin") //Dagues empoisonnées
                {
                    //Empoisonne : - 1 HP au prochain tour
                    Poisoned(otherPlayer, true);

                    tBox.Text += ("\r\nAttaque shuriken : - 1 HP, État empoisonnée"); //pour test

                    //Si cible ne défend pas : - 1ptn de dégat sur le moment
                    if (otherPlayerChoice != ActionChoice.Defend)
                    {
                        TakeDamage(otherPlayer, 1);
                    }
                }
                else if ((string)actionPlayer["Name"] == "Tank") //POWERFULL ATTACK
                {
                    //Spell effect (powerfull att)
                    int boostedDamage = (int)actionPlayer["Force"] + 1;
                    actionPlayer["HP"] = (int)actionPlayer["HP"] - 1;

                    //OTHER RAGE
                    if (((string)otherPlayer["Name"] == "Damager") && (otherPlayerChoice == ActionChoice.Spell))
                    {
                        otherPlayer["HP"] = (int)otherPlayer["HP"] - boostedDamage;
                        actionPlayer["HP"] = (int)actionPlayer["HP"] - boostedDamage;

                    }
                    else if (otherPlayerChoice == ActionChoice.Defend) //OTHER DEFEND
                    {
                        otherPlayer["HP"] = (int)otherPlayer["HP"] - (boostedDamage - 1);
                    }
                    else  //REST (Attack, Heal, powerfull attack...)
                    {
                        otherPlayer["HP"] = (int)otherPlayer["HP"] - boostedDamage;
                    }

                }
            }
            else if (actionPlayerChoice == ActionChoice.Attack) //ATTACK
            {
                //Cas où l'autre fait rage (damager)
                if (((string)otherPlayer["Name"] == "Damager") && (otherPlayerChoice == ActionChoice.Spell))
                {
                    otherPlayer["HP"] = (int)otherPlayer["HP"] - ((int)actionPlayer["Force"]);
                    actionPlayer["HP"] = (int)actionPlayer["HP"] - ((int)actionPlayer["Force"]);

                }
                else if (otherPlayerChoice == ActionChoice.Defend) //Cas où l'autre défend
                {
                    return;
                }
                else //le reste (attaque, heal, powerfull attack etc...)
                {
                    otherPlayer["HP"] = (int)otherPlayer["HP"] - ((int)actionPlayer["Force"]);
                }
            }
        }


        //Choix action joueur
        static void PlayerChooseAction(Dictionary<string, object> player, TextBox tBox, Button button, PictureBox plrBox)
        {
            int action_player_choice = 0;

            tBox.Text += ("\r\nChoisissez une action:\r\n1 - Attack\r\n2 - Defend\r\n3 - Spell");

            action_player_choice = int.Parse(button.Tag.ToString());

            Debug.WriteLine($"Clicked button Tag: {button.Tag}");
            Debug.WriteLine(action_player_choice);

            player["Action"] = (ActionChoice)action_player_choice;


            //----------------------------------------------------------------------------------------------
            AnimationClass.CharacterAnim(plrBox, 1, player["Action"].ToString());
        }

        //Choix d'action IA
        static async void AIChooseAction(Dictionary<string, object> ai, PictureBox compBox)
        {
            Random rand = new Random();
            int choiceNb = Enum.GetValues(typeof(ActionChoice)).Length;

            ai["Action"] = (ActionChoice)rand.Next(1, choiceNb + 1);

            await Task.Delay(500);

            //----------------------------------------------------------------------------------------------
            AnimationClass.CharacterAnim(compBox, -1, ai["Action"].ToString());
        }

        public string PlayerChooseCharacter(TextBox tBox, Button pChoiceButton, PictureBox plrBox)
        {
            List<string> classList = new List<string>() { "Damager", "Healer", "Tank", "Assassin" };
            int character_player_choice = 0;
            while (character_player_choice < 1 || character_player_choice > classList.Count)
            {
                //tBox.Text += ("Choisissez un personnage:\r\n1 - Damager\r\n2 - Healer\r\n3 - Tank\r\n4 - Assassin\r\n");

                if (!choseCharacter)
                {
                    character_player_choice = int.Parse(pChoiceButton.Tag.ToString());
                    choseCharacter = true;

                    this.Controls.Remove(DamagerButton); this.Controls.Remove(this.Controls["selButton0"]);
                    this.Controls.Remove(HealerButton); this.Controls.Remove(this.Controls["selButton1"]);
                    this.Controls.Remove(TankButton); this.Controls.Remove(this.Controls["selButton2"]);
                    this.Controls.Remove(AssasinButton); this.Controls.Remove(this.Controls["selButton3"]);

                    plrBox.Image = playerList[character_player_choice-1];//-1 because the tags starts at 1, not 0
                }
            }
            return classList[character_player_choice - 1];
        }

        //Choix d'action IA
        public string AIChooseCharacter(PictureBox compBox)
        {
            List<string> classList = new List<string>() { "Damager", "Healer", "Tank", "Assassin" };
            Random rand = new Random();
            int rand_index = rand.Next(0, classList.Count);

            compBox.Image = enemyList[rand_index];

            return classList[rand_index];
        }


        //Détecte fin de jeu
        static bool isEndGame(Dictionary<string, object> playerCharacter, Dictionary<string, object> aiCharacter, TextBox tBox)
        {
            //Conditions de fin
            bool playerIsDead = (int)playerCharacter["HP"] <= 0;
            bool AIisDead = (int)aiCharacter["HP"] <= 0;

            if (playerIsDead && AIisDead)
            {
                tBox.Text += ("\r\nEgalité !");
                return true;
            }
            else if (AIisDead)
            {
                tBox.Text += ("\r\nLe joueur a gagné !");
                return true;
            }
            else if (playerIsDead)
            {
                tBox.Text += ("\r\nl'AI a gagné !");
                return true;
            }
            else return false;
        }

        //----- Fonction spell
        static void Heal(Dictionary<string, object> charact, TextBox tBox)
        {
            int _health = (int)charact["HP"] + 2;
            //Vérifie qu'on ne dépasse pas la santé max
            charact["HP"] = Math.Min(_health, (int)character[(string)charact["Name"]]["HP"]);
        }

        //---- Fonction affichage
        static void ShowPlayerAction(ActionChoice action, TextBox tBox)
        {
            tBox.Text += ($"\r\nPlayer choice : {action.ToString()}");
        }

        static void ShowAIAction(ActionChoice action, TextBox tBox)
        {
            tBox.Text += ($"\r\nAI choice : {action.ToString()}");
        }

        static void DisplayHealth(Dictionary<string, object> player, Dictionary<string, object> ai, TextBox tBox)
        {
            tBox.Text += $"\r\nHP joueur : {player["HP"]}/{character[(string)player["Name"]]["HP"]}";
            tBox.Text += $"\r\nHP IA : {ai["HP"]}/{character[(string)ai["Name"]]["HP"]}";
        }

        static void TakeDamage(Dictionary<string, object> character, int damage)
        {
            //Retrait HP
            character["HP"] = (int)character["HP"] - 1;
        }

        static void Poisoned(Dictionary<string, object> character, bool b)
        {
            character["Poisoned"] = b;
        }

        static bool isPoisoned(Dictionary<string, object> character)
        {
            return (bool)character["Poisoned"];
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.SelectionStart = textBox1.TextLength;//Set text start(the first line to show
            textBox1.ScrollToCaret();//Scroll to bottom
        }
    }
}

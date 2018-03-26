using AMissão.WinApp.Armas;
using AMissão.WinApp.Inimigos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMissão.WinApp
{
    public partial class Inicial : Form
    {
        private Game game;
        private Random random = new Random();
        public Inicial()
        {
            InitializeComponent();
            game = new Game(new Rectangle(78, 57, 420, 155));
            game.NewLevel(random);
            UpdateCharacters();
        }

        private void UpdateCharacters()
        {
            PBPlayer.Location = game.PlayerLocation;
            lblptsVidaJogador.Text = game.PlayerHitPoints.ToString();

            bool showBat = false;
            bool showGhost = false;
            bool showZombie = false;
            int enemiesShown = 0;

            foreach (Enemy enemy in game.Enemies)
            {
                if (enemy is Bat)
                {
                    picBat.Location = enemy.Location;
                    lblptsVidaMorcego.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showBat = true;
                        enemiesShown++;
                    }
                }
                else if (enemy is Ghost)
                {
                    picGhost.Location = enemy.Location;
                    lblptsVidaFantasma.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showGhost = true;
                        enemiesShown++;
                    }
                }
                else
                {
                    picZombie.Location = enemy.Location;
                    lblptsVidaZumbi.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showZombie = true;
                        enemiesShown++;
                    }
                }
            }

            if (showBat == false)
            {
                picBat.Visible = false;
                lblptsVidaMorcego.Text = "";
            }
            else
                picBat.Visible = true;

            if (showGhost == false)
            {
                picGhost.Visible = false;
                lblptsVidaFantasma.Text = "";
            }
            else
                picGhost.Visible = true;

            if (showZombie == false)
            {
                picZombie.Visible = false;
                lblptsVidaZumbi.Text = "";
            }
            else
                picZombie.Visible = true;

            picArmaArco.Visible = false;
            picArmaBastao.Visible = false;
            picArmaEspada.Visible = false;
            picArmaPocaoAzul.Visible = false;
            picArmaPocaoVermelha.Visible = false;

            Control weaponControl = null;
            Control inventoryControl = null;
            switch (game.WeaponInRoom.Name)
            {
                case "Sword":
                    weaponControl = picArmaEspada;
                    inventoryControl = picEspada;
                    break;
                case "BluePotion":
                    weaponControl = picArmaPocaoAzul;
                    inventoryControl = picPocaoAzul;
                    break;
                case "Bow":
                    weaponControl = picArmaArco;
                    inventoryControl = picArco;
                    break;
                case "Mace":
                    weaponControl = picArmaBastao;
                    inventoryControl = picBastao;
                    break;
                case "RedPotion":
                    weaponControl = picArmaPocaoVermelha;
                    inventoryControl = picPocaoVermelha;
                    break;
                default:
                    break;
            }            

            if (game.CheckPlayerInventory("Sword"))
            {
                picEspada.Visible = true;
            }
            if (game.CheckPlayerInventory("BluePotion"))
            {
                picPocaoAzul.Visible = true;
            }
            if (game.CheckPlayerInventory("RedPotion"))
            {
                picPocaoVermelha.Visible = true;
            }
            if (game.CheckPlayerInventory("Bow"))
            {
                picArco.Visible = true;
            }
            if (game.CheckPlayerInventory("Mace"))
            {
                picBastao.Visible = true;
            }

            weaponControl.Location = game.WeaponInRoom.Location;
            if (game.WeaponInRoom.PickedUp)
            {
                weaponControl.Visible = false;

                if (game.WeaponInRoom is BluePotion)
                {
                    BluePotion potion = game.WeaponInRoom as BluePotion;
                    if (potion.Used == false)
                        inventoryControl.Visible = true;
                    else
                        inventoryControl.Visible = false;
                }
                else if (game.WeaponInRoom is RedPotion)
                {
                    RedPotion potion = game.WeaponInRoom as RedPotion;
                    if (potion.Used == false)
                        inventoryControl.Visible = true;
                    else
                        inventoryControl.Visible = false;
                }
                else
                {
                    inventoryControl.Visible = true;
                }
            }
            else
            {
                weaponControl.Visible = true;
                inventoryControl.Visible = false;
            }
            if (game.PlayerHitPoints <= 0)
            {
                MessageBox.Show("Você Morreu");
                Application.Exit();
            }
            if (enemiesShown < 1)
            {
                MessageBox.Show("Você derrotou todos os inimigos neste nivel");
                game.NewLevel(random);
                UpdateCharacters();
            }
        }

        private void btnMoveEsquerda_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Left, random);
            UpdateCharacters();
        }

        private void btnMovCima_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Up, random);
            UpdateCharacters();
        }

        private void btnMovDireita_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Right, random);
            UpdateCharacters();
        }

        private void btnMovBaixo_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Down, random);
            UpdateCharacters();
        }

        private void btnAtaEsquerda_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Left, random);
            UpdateCharacters();
        }

        private void btnAtaCima_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Up, random);
            if (picPocaoAzul.BorderStyle == BorderStyle.FixedSingle || picPocaoVermelha.BorderStyle == BorderStyle.FixedSingle)
            {
                btnAtaCima.Text = "Para Cima";
                btnAtaEsquerda.Visible = true;
                btnAtaDireita.Visible = true;
                btnAtaBaixo.Visible = true;
            }
            UpdateCharacters();            
        }

        private void btnAtaBaixo_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Down, random);
            UpdateCharacters();
        }

        private void btnAtaDireita_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Right, random);
            UpdateCharacters();
        }

        private void picEspada_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Sword"))
            {
                game.Equip("Sword");
            }
            picEspada.BorderStyle = BorderStyle.FixedSingle;
            UpdateFixedBorderInventory();
        }

        private void picPocaoAzul_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("BluePotion"))
            {
                UpdateButtons();
                game.Equip("BluePotion");
            }
            picPocaoAzul.BorderStyle = BorderStyle.FixedSingle;
            UpdateFixedBorderInventory();
        }

        private void picArco_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Bow"))
            {
                game.Equip("Bow");
            }
            picArco.BorderStyle = BorderStyle.FixedSingle;
            UpdateFixedBorderInventory();
        }

        private void picPocaoVermelha_Click(object sender, EventArgs e)
        {            
            if (game.CheckPlayerInventory("RedPotion"))
            {
                UpdateButtons();
                game.Equip("RedPotion");
            }
            picPocaoVermelha.BorderStyle = BorderStyle.FixedSingle;
            UpdateFixedBorderInventory();
        }

        private void UpdateButtons()
        {
            btnAtaEsquerda.Visible = false;
            btnAtaDireita.Visible = false;
            btnAtaBaixo.Visible = false;
            btnAtaCima.Text = "Beber";
        }
        private void picBastao_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Mace"))
            {
                game.Equip("Mace");
            }
            picBastao.BorderStyle = BorderStyle.FixedSingle;
            UpdateFixedBorderInventory();
        }

        private void UpdateFixedBorderInventory()
        {
            string weapomEquiped = game.GetEquippedWeapon();
            switch (weapomEquiped)
            {
                case "Sword":
                    picPocaoAzul.BorderStyle = BorderStyle.None;
                    picArco.BorderStyle = BorderStyle.None;
                    picPocaoVermelha.BorderStyle = BorderStyle.None;
                    picBastao.BorderStyle = BorderStyle.None;
                    break;
                case "BluePotion":
                    picEspada.BorderStyle = BorderStyle.None;
                    picArco.BorderStyle = BorderStyle.None;
                    picPocaoVermelha.BorderStyle = BorderStyle.None;
                    picBastao.BorderStyle = BorderStyle.None;
                    break;
                case "Bow":
                    picEspada.BorderStyle = BorderStyle.None;
                    picPocaoAzul.BorderStyle = BorderStyle.None;
                    picPocaoVermelha.BorderStyle = BorderStyle.None;
                    picBastao.BorderStyle = BorderStyle.None;
                    break;
                case "Mace":
                    picEspada.BorderStyle = BorderStyle.None;
                    picPocaoAzul.BorderStyle = BorderStyle.None;
                    picArco.BorderStyle = BorderStyle.None;
                    picPocaoVermelha.BorderStyle = BorderStyle.None;
                    break;
                case "RedPotion":
                    picPocaoAzul.BorderStyle = BorderStyle.None;
                    picArco.BorderStyle = BorderStyle.None;
                    picArco.BorderStyle = BorderStyle.None;
                    picBastao.BorderStyle = BorderStyle.None;
                    break;
                default:
                    break;
            }
        }
    }
}

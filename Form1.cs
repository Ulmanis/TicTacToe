﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        bool xPlayerTurn = true;
        int turnCount = 0;

        public Form1()
        {
            InitializeComponent();
            InitializeGrid();
            InitializeCells();
        }

        private void InitializeGrid()
        {
            Grid.BackColor = Color.LightCoral;
            Grid.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
        }

        private void RestartGame()
        {
            InitializeCells();
            turnCount = 0;
            xPlayerTurn = true;
        }

        private void InitializeCells()
        {
            string labelName;
            for(int i = 1; i <= 9; i++)
            {
                labelName = "pictureBox" + i;
                Grid.Controls[labelName].Tag = String.Empty;
                Grid.Controls[labelName].BackColor = Color.Transparent;
            }
        }

        private void Player_Click(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;

            if(pic.Tag != String.Empty)
            {
                return;
            }



            if (xPlayerTurn)
            {
                pic.Tag = "X";
            }
            else
            {
                pic.Tag = "O";
            }

            turnCount++;
            PlaySound("beep_sound");
            CheckForWin();
            CheckForDraw();
            xPlayerTurn = !xPlayerTurn;
            
        }

        private void CheckForWin()
        {
            if (
                (pictureBox1.Tag == pictureBox2.Tag && pictureBox2.Tag == pictureBox3.Tag && pictureBox1.Tag != String.Empty) ||
                (pictureBox4.Tag == pictureBox5.Tag && pictureBox5.Tag == pictureBox6.Tag && pictureBox4.Tag != String.Empty) ||
                (pictureBox7.Tag == pictureBox8.Tag && pictureBox8.Tag == pictureBox9.Tag && pictureBox7.Tag != String.Empty) ||
                (pictureBox1.Tag == pictureBox4.Tag && pictureBox4.Tag == pictureBox7.Tag && pictureBox1.Tag != String.Empty) ||
                (pictureBox2.Tag == pictureBox5.Tag && pictureBox5.Tag == pictureBox8.Tag && pictureBox2.Tag != String.Empty) ||
                (pictureBox3.Tag == pictureBox6.Tag && pictureBox6.Tag == pictureBox9.Tag && pictureBox3.Tag != String.Empty) ||
                (pictureBox1.Tag == pictureBox5.Tag && pictureBox5.Tag == pictureBox9.Tag && pictureBox1.Tag != String.Empty) ||
                (pictureBox3.Tag == pictureBox5.Tag && pictureBox5.Tag == pictureBox7.Tag && pictureBox3.Tag != String.Empty)
                )
            {
                GameOver();
            }
        }

        private void CheckForDraw()
        {
            if(turnCount == 9)
            {
                MessageBox.Show("Bruh y'all stupid lmao");
                InitializeCells();
                RestartGame();
            }
        }

        private void GameOver()
        {
            string winner;
            if (xPlayerTurn)
            {
                winner = "X";
            }
            else
            {
                winner = "O";
            }
            WinnerCellsChangeColor();
            MessageBox.Show(winner + " wins!");

            InitializeCells();
            RestartGame();
        }
        private void WinnerCellsChangeColor()
        {
            if (pictureBox1.Tag == pictureBox2.Tag && pictureBox1.Tag == pictureBox3.Tag && pictureBox1.Tag != "")
            {
                ChangeCellColors(pictureBox1, pictureBox2, pictureBox3, Color.Purple);
            }
            else if (pictureBox4.Tag == pictureBox5.Tag && pictureBox4.Tag == pictureBox6.Tag && pictureBox4.Tag != "")
            {
                ChangeCellColors(pictureBox4, pictureBox5, pictureBox6, Color.Purple);
            }
            else if (pictureBox7.Tag == pictureBox8.Tag && pictureBox7.Tag == pictureBox9.Tag && pictureBox7.Tag != "")
            {
                ChangeCellColors(pictureBox7, pictureBox8, pictureBox9, Color.Purple);
            }
            else if (pictureBox1.Tag == pictureBox4.Tag && pictureBox1.Tag == pictureBox7.Tag && pictureBox1.Tag != "")
            {
                ChangeCellColors(pictureBox1, pictureBox4, pictureBox7, Color.Purple);
            }
            else if (pictureBox2.Tag == pictureBox5.Tag && pictureBox2.Tag == pictureBox8.Tag && pictureBox2.Tag != "")
            {
                ChangeCellColors(pictureBox2, pictureBox5, pictureBox8, Color.Purple);
            }
            else if (pictureBox3.Tag == pictureBox6.Tag && pictureBox3.Tag == pictureBox9.Tag && pictureBox3.Tag != "")
            {
                ChangeCellColors(pictureBox3, pictureBox6, pictureBox9, Color.Purple);
            }
            else if (pictureBox1.Tag == pictureBox5.Tag && pictureBox1.Tag == pictureBox9.Tag && pictureBox1.Tag != "")
            {
                ChangeCellColors(pictureBox1, pictureBox5, pictureBox9, Color.Purple);
            }
            else if (pictureBox3.Tag == pictureBox5.Tag && pictureBox3.Tag == pictureBox7.Tag && pictureBox3.Tag != "")
            {
                ChangeCellColors(pictureBox3, pictureBox5, pictureBox7, Color.Purple);
            }

        }
        private void ChangeCellColors(PictureBox firstPictureBox, PictureBox secondPictureBox, PictureBox thirdPictureBox, Color color)
        {
            firstPictureBox.BackColor = color;
            secondPictureBox.BackColor = color;
            thirdPictureBox.BackColor = color;
        }
        private void PlaySound(string soundName)
        {
            System.IO.Stream str = (System.IO.Stream)Properties.Resources.ResourceManager.GetObject(soundName);
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
            snd.Play();
        }
    }
}
